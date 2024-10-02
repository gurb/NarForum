namespace GurbForumUser.Client.Models.Category
{
    public class UpdateCategoryCommandVM
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
    }
}
