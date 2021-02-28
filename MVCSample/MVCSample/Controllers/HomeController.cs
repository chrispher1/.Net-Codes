using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCSample.Models;
using MVCSample.Filters;
namespace MVCSample.Controllers
{
    [HandleError]
    
    public class HomeController : Controller
    {
        //[Authorize]
        //[CustomAuthorization]
        [CustomAction]
        [CustomAuthentication]
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Itest objVirtual = new VirtualClass();
            ViewBag.Message = "Calling vitrual method=" + objVirtual.b();
            return View();
        }

        //[Authorize]
        //[CustomAuthorization]
        [CustomAuthentication]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public PartialViewResult DisplayPartialView()
        {
            return PartialView("PartialViewForActionMethods");
        }
    }

    public class Parent
    {
        int ComputeAverage()
        {
            return 100;
        }

        public virtual string DisplayMessage()
        {
            return "I am the parent class ";
        }
    }

    public class Child1 : Parent
    {
        public override string DisplayMessage()
        {
            return "I am the child1 class ";
        }
    }

    public class Child2 : Child1
    {
        public override string DisplayMessage()
        {
            return "I am the child2 class ";
        }
    }

    abstract class AbstractParent
    {
        public virtual string ShowMessage()
        {
            return "I am the AbstractParent";
        }
    }

    class AbstractChild : AbstractParent
    {
        public override string ShowMessage()
        {
            return "I am the AbstractChild";
        }
    }

    interface Itest
    {
        string b();
    }

    class VirtualClass : Itest
    {
        public virtual string b()
        {
            return "This is a virtual method";
        }
    }

    public abstract class AbstractClass: Itest
    {
        public abstract string b();
    }

    public abstract class AbstractOverride: AbstractClass
    {

    }
}