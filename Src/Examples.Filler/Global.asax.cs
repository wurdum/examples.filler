using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;

namespace Examples.Filler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BinderConfig.RegisterBinders(ModelBinders.Binders);
            AutofacConfig.RegisterContainer();

            FluentValidationModelValidatorProvider.Configure(c => c.ValidatorFactory = new AutofacValidatorFactory());
        }
    }
}