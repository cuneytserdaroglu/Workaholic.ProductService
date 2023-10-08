namespace Workaholic.ProductService.Domain;

public class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string SubCategoryName { get; set; }
    public int Quantity { get; set; }
}