using Microsoft.AspNetCore.Mvc;

namespace CooperSystem.API
{
    public class CultureRouteAttribute : RouteAttribute
    {
        public CultureRouteAttribute(string template)
            : base($"{{culture}}/{template}")
        {
        }
    }
}
