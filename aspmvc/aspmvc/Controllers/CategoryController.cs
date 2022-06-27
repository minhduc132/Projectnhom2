using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspmvc.Controllers
{
    public class CategoryController : Controller
    {
        //GET: Category
        public ActionResult Index()
        {
            ViewBag.Message = "Category Management ";

            return View();
        }

        //public string Index()
        //{
        //    return "This is my <b>default<b> action.....";
        //}

        public string Welcome(string name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello" + name + ",NumTimes is:" + numTimes);
        }
    }
 }