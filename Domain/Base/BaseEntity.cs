namespace Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool IsActive { get; set; } = true;
}
