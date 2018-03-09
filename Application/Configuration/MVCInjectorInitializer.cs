[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Application.Configuration.MVCInjectorInitializer), "Initialize")]

namespace Application.Configuration
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.Web;
    using Application.Context;
    using Application.Repositories;

    public static class MVCInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterDependencies(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        static void RegisterDependencies(Container container)
        {
            container.Register<IContext>(() => new Context.AppContext(), Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>();
            container.Register<ITodoRepository, TodoRepository>();
        }

    }
}