using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCSample.Filters
{
    public class CustomAuthenticationAttribute: FilterAttribute, IAuthenticationFilter
    {
     public void OnAuthentication(AuthenticationContext filterContext)
        {
            var u = filterContext.HttpContext.User;
            
            if (!u.Identity.IsAuthenticated)
            {
                Console.WriteLine("Not Authenticated");
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
        //
        // Summary:
        //     Adds an authentication challenge to the current System.Web.Mvc.ActionResult.
        //
        // Parameters:
        //   filterContext:
        //     The context to use for the authentication challenge.
       public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var u = filterContext.HttpContext.User;
            if (!u.Identity.IsAuthenticated)
            {
                Console.WriteLine("Not Authenticated");
                
            }
                

        }

    }
}