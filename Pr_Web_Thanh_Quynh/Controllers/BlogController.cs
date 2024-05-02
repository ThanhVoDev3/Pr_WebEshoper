using Pr_Web_Thanh_Quynh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pr_Web_Thanh_Quynh.Controllers
{
    public class BlogController : Controller
    {
        private readonly ProductDBContext dbContext = new ProductDBContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blogs = dbContext.Blogs.ToList();
            return View(blogs);
        }

        public ActionResult Details(int id)
        {
            var blog = dbContext.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
    }
}
