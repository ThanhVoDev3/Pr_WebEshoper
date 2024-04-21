using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pr_Web_Thanh_Quynh.Models; // Import the correct namespace for the Blog model

namespace Pr_Web_Thanh_Quynh.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            // Assuming you have a data context class named BlogContext
            using (var db = new BlogContext())
            {
                // Retrieve all blog posts from the database
                var blogPosts = db.Blog.ToList();

                // Pass the list of blog posts to the view
                return View(blogPosts);
            }
        }
    }
}
