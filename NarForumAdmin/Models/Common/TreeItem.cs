namespace NarForumAdmin.Models.Common
{
    public class TreeItem
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public bool IsExpanded { get; set; } = false;
        public bool IsSelected { get; set; } = false;
        public List<TreeItem> Children { get; set; } = new List<TreeItem>();
    }
}
