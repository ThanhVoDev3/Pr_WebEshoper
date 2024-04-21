using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Pr_Web_Thanh_Quynh.Models;
using PagedList;

namespace Pr_Web_Thanh_Quynh.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDBContext dbContext = new ProductDBContext();

        // GET: Product/Index
        public ActionResult Index(int categoryId = 2)
        {
            ProductDBContext dBContext = new ProductDBContext();
            List<Product> Listproducts = dBContext.Products.Include(c => c.Category).Where(p => p.CatId == categoryId).ToList();
            return View(Listproducts);
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = dbContext.Products
                                    .Include(p => p.Category)
                                    .FirstOrDefault(p => p.ProId == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/GetCategory
        public ActionResult GetCategory()
        {
            var categories = dbContext.Categories.ToList();
            return PartialView("_Menu_left", categories);
        }

        // POST: Product/AddToCart
        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            var product = dbContext.Products.Find(productId);
            if (product == null)
            {
                return HttpNotFound();
            }

            if (Session["Cart"] == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart(product, quantity));
                Session["Cart"] = cart;
            }
            else
            {
                List<Cart> cart = (List<Cart>)Session["Cart"];
                int index = cart.FindIndex(c => c.Product.ProId == productId);
                if (index != -1)
                {
                    cart[index].Quantity += quantity;
                }
                else
                {
                    cart.Add(new Cart(product, quantity));
                }
                Session["Cart"] = cart;
            }

            return Json(new { success = true });
        }
    }
}
