using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateACookie()
        {
            HttpCookie mycookie = new HttpCookie("UserTestCookie");
            mycookie["Username"] = "TestUser1";
            mycookie["Email"] = "testuser@mail.com";
            mycookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(mycookie);
            ViewBag.Msg = "Sucessfully created cookie";
            return View();
        }

        public ActionResult ReadCookie()
        {
            HttpCookie myCookie = Request.Cookies["UserTestCookie"];
            if(myCookie != null)
            {
                ViewBag.Username = myCookie["Username"];
                ViewBag.Email = myCookie["Email"];
            }
            else
            {
                ViewBag.Msg = "Cookie not found";
            }
            return View();
        }
        public ActionResult DeleteCookie()
        {
            HttpCookie myCookie = Request.Cookies["UserTestCookie"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddDays(-1);
                ViewBag.Msg = "Sucessfully deleted cookie";
                Response.Cookies.Add(myCookie);
            }
            else
            {
                ViewBag.Msg = "Cookie not found";
            }
                return View();
        }
    }
}