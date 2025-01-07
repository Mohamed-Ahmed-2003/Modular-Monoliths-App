namespace Shared;

public interface IEntity<T> :IEntity
{
    public T Id { get; set; }
}

public interface IEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
}