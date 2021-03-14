using Geo.Contracts.Inputs;
using Geo.Contracts.Payloads;
using Geo.Core.Helpers;
using Geo.Core.Settings;
using Geo.Database;
using Geo.Domain;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geo.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class AuthMutations
    {
        private readonly JwtSettings _jwtSettings;

        public AuthMutations(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings; 
        }

        [UseDbContext(typeof(GeoDbContext))]
        public async Task<AuthenticationPayload> RegisterAsync(RegisterUserInput input, [ScopedService] GeoDbContext context)
        {
            var existingUser = context.Users
                .Where(i => i.Email.ToLower() == input.Email.ToLower())
                .SingleOrDefault();

            if (existingUser != null)
            {
                return new AuthenticationPayload(null, "User with this email address already exists");
            }


            var salt = HashHelper.GenerateSalt();
            var newUser = new User
            {
                Email = input.Email,
                Salt = salt,
                Hash = HashHelper.GenerateHash(salt, input.Password)
            };

            var createdUser = await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            return GenerateAuthenticationResultForUser(newUser);
        }

        [UseDbContext(typeof(GeoDbContext))]
        public AuthenticationPayload Login(LoginUserInput input, [ScopedService] GeoDbContext context)
        {
            var user = context.Users
                .Where(i => i.Email.ToLower() == input.Email.ToLower())
                .SingleOrDefault();

            if (user == null)
            {
                return new AuthenticationPayload(null, "User with this email address doesn't exists");
            }

            var hash = HashHelper.GenerateHash(user.Salt, input.Password);
            if (hash != user.Hash)
            {
                return new AuthenticationPayload(null, "Wrong password");
            }

            return GenerateAuthenticationResultForUser(user);
        }

        private AuthenticationPayload GenerateAuthenticationResultForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);



            return new AuthenticationPayload(tokenHandler.WriteToken(token), null);
        }
    }
}
