namespace Shared;

public class Entity<T> :IEntity<T>
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public T Id { get; set; }
}