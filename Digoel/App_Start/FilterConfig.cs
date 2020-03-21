using System.Web;
using System.Web.Mvc;
using Digoel.Filters;

namespace Digoel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());    //Default filter
            filters.Add(new MyLogginFilterAttribute()); //Filter for Recaptcha
        }
    }
}
