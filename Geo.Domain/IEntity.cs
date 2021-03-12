namespace Geo.Domain
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
