using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProductsAndCategoriesContext _context;
		public HomeController(ProductsAndCategoriesContext context)
		{
			_context = context;
		}

        [HttpGet("~/products/new")]
        public IActionResult NewProduct()
        {
            return View("NewProduct");
        }

        [HttpGet("~/categories/new")]
        public IActionResult NewCategory()
        {
            return View("NewCategory");
        }

        [HttpGet("~/products/{Product_Id}")]
        public IActionResult Product(int Product_Id)
        {
            Product this_product = _context.products.Include(p => p.Links).ThenInclude(l => l.Category).SingleOrDefault(p => p.ProductId == Product_Id);
            List<Category> AC = _context.categories.Include(c => c.Links).ThenInclude(l => l.Product).ToList();
            ViewBag.AllCategories = AC;
            return View("Product", this_product);
        }

        [HttpGet("~/categories/{Category_Id}")]
        public IActionResult Category(int Category_Id)
        {
            Category this_category = _context.categories.Include(c => c.Links).ThenInclude(l => l.Product).SingleOrDefault(c => c.CategoryId == Category_Id);
            List<Product> AP = _context.products.Include(c => c.Links).ThenInclude(l => l.Category).ToList();
            ViewBag.AllProducts = AP;
            return View("Category", this_category);
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct(Product this_product)
        {
            Product new_product = new Product
            {
                Name = this_product.Name,
                Description = this_product.Description,
                Price = this_product.Price
            };
            _context.products.Add(new_product);
            _context.SaveChanges();
            return Redirect("~/products/"+new_product.ProductId);
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(string Name)
        {
            Category new_category = new Category
            {
                Name = Name
            };
            _context.categories.Add(new_category);
            _context.SaveChanges();
            return Redirect("~/categories/"+new_category.CategoryId);
        }


        [HttpPost("addcattoprod")]
        public IActionResult AddCatToProd(int productid, int categoryid)
        {
            Link new_link = new Link
            {
                ProductId = productid,
                CategoryId = categoryid
            };
            _context.links.Add(new_link);
            _context.SaveChanges();
            return Redirect("~/products/"+productid);
        }

        [HttpPost("addprodtocat")]
        public IActionResult AddProdToCat(int productid, int categoryid)
        {
            Link new_link = new Link
            {
                ProductId = productid,
                CategoryId = categoryid
            };
            _context.links.Add(new_link);
            _context.SaveChanges();
            return Redirect("~/categories/"+categoryid);
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

namespace ProductsAndCategories
{
	public static class SessionExtensions
	{
		public static void SetObjectAsJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		public static T GetObjectFromJson<T>(this ISession session, string key)
		{
			string value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}
}