namespace AdminUI.Models.BlogCategory;

public class UpdateBlogCategoryCommandVM
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
