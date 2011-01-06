using System.Web.Mvc;
using System.Web.Routing;
using CQRS.Core.Commands;
using CQRS.Core.Events;

namespace CQRS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("AddTransaction", "Transactions/Add/{bankAccountId}", new { controller = "Transactions", action = "Add" });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            var bus = new CommandBus();
            var commands = new CommandHandlers();
            bus.RegisterHandler<PostTransactionCommand>(commands.Handle);
            ServiceLocator.CommandBus = bus;

            var events = new EventHandlers();
            DomainEvents.Register<AccountLockedEvent>(events.Handle);
            DomainEvents.Register<AccountOverdrawnEvent>(events.Handle);
            DomainEvents.Register<TransationPostedEvent>(events.Handle);
        }
    }
}