namespace Workaholic.ProductService.Domain;

public class Category
{
    public Category()
    {
        SubCategories = new List<SubCategory>();
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public virtual List<SubCategory> SubCategories { get; set; }
}