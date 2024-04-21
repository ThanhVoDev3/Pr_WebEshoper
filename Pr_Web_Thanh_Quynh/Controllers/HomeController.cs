using Pr_Web_Thanh_Quynh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;

namespace Pr_Web_Thanh_Quynh.Controllers
{
    public class HomeController : Controller
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


    }
}