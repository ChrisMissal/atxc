namespace Core
{
    public interface IEntity : ITenanted
    {
        int Id { get; }

        string Slug { get; }
    }
}