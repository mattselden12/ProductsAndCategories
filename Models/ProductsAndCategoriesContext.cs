using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models
{
	public class ProductsAndCategoriesContext : DbContext
	{
	// base() calls the parent class' constructor passing the "options" parameter along
	public ProductsAndCategoriesContext(DbContextOptions<ProductsAndCategoriesContext> options) : base(options) { }
	}
}
