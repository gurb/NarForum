namespace NarForumAdmin.Models.Heading
{
    public class UpdateHeadingCommandVM
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
