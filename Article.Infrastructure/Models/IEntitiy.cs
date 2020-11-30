namespace Article.Infrastructure
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
