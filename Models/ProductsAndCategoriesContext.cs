using Microsoft.EntityFrameworkCore;
namespace ProductsAndCategories.Models
{
	public class ProductsAndCategoriesContext : DbContext
	{
	// base() calls the parent class' constructor passing the "options" parameter along
	public ProductsAndCategoriesContext(DbContextOptions<ProductsAndCategoriesContext> options) : base(options) { }

	public DbSet<Product> products {get;set;}
	public DbSet<Category> categories {get;set;}
	public DbSet<Link> links {get;set;}
	}
}
