using Geo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.Database
{
    public partial class GeoDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            var BosniaAndHerzegovinaId = Guid.NewGuid();
            var CroatiaId = Guid.NewGuid();

            modelBuilder.Entity<Country>()
                .HasData
                (
                    new Country { Id = BosniaAndHerzegovinaId, Name = "Bosnia and Herzegovina", Abbreviation = "BA" },
                    new Country { Id = CroatiaId, Name = "Country", Abbreviation = "HR"}
                );

            var SarajevoId = Guid.NewGuid();
            var MostarId = Guid.NewGuid();
            var ZagrebId = Guid.NewGuid();
            var SplitId = Guid.NewGuid();

            modelBuilder.Entity<City>()
                .HasData
                (
                    new City { Id = SarajevoId, Name = "Sarajevo", CountryId = BosniaAndHerzegovinaId},
                    new City { Id = MostarId, Name = "Mostar", CountryId = BosniaAndHerzegovinaId},
                    new City { Id = ZagrebId, Name = "Zagreb", CountryId = CroatiaId},
                    new City { Id = SplitId, Name = "Split", CountryId = CroatiaId}
                );
        }
    }
}
