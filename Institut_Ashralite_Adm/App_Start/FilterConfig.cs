using System.Web;
using System.Web.Mvc;

namespace Institut_Ashralite_Adm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
