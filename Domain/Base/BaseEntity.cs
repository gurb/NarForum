namespace Domain.Base;

public abstract class BaseEntity
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public bool IsActive { get; set; } = true;
}
