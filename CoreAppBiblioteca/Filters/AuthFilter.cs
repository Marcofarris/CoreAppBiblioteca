using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAppBiblioteca.Filters
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           if(context.HttpContext.Session.Get("LogSession") == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
