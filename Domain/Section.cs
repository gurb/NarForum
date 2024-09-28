using Domain.Base;

namespace Domain
{
    public class Section: BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}
