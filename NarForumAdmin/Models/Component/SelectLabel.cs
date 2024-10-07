namespace NarForumAdmin.Models.Component
{
    public class SelectLabel
    {
        public bool IsSelect { get; set; }
        public string Text { get; set; } = string.Empty;
        public Guid? Id { get; set; } = Guid.Empty;
        public Guid? IntId { get; set; }
    }
}
