using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Collections;

namespace MVCSample.Filters
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //var user = filterContext.Controller.ControllerContext.HttpContext.User;

            // var person = Tuple.Create(1, "Steve", "Jobs",12);
            // Console.WriteLine(person.Item4); // returns 1
            // person.Item2; // returns "Steve"
            // person.Item3; // returns "Jobs"

            //Parent obj = new Parent();

            Console.Write("Done Executing");
        }
        
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.Controller.ControllerContext.HttpContext.User;

            Console.Write("Begin Executing");
        }
    }




    public class PublisherClass
    {
        public delegate string Generate(string param1, string param2);
        public event Generate userAction;
        public string result = "";
        public void Click(string a, string b)
        {
            result = userAction(a, b);
        }
    }

    public class SubscriberClass
    {
        PublisherClass _p1;
        public SubscriberClass()
        {
            _p1 = new PublisherClass();
            _p1.userAction += EventHandler;
        }

        public void Click()
        {
            _p1.Click("ACe", "Spa");
            Console.WriteLine("test=");
           // _p1.Click("Ace", "Spa");
        }


       string EventHandler(string f1, string f2)
        {
            return "Combine " + f1 + f2;
        }

    }


    public class Custome : IEnumerable<string>
    {
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Beste : IEnumerator
    {
        public object Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}