[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Application.Configuration.APIInjectorInitializer), "Initialize")]

namespace Application.Configuration
{
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector;
    using System.Web.Http;
    using Application.Context;
    using Application.Repositories;

    public static class APIInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            RegisterDependencies(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        static void RegisterDependencies(Container container)
        {
            container.Register<IContext>(() => new Context.AppContext(), Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>();
            container.Register<ITodoRepository, TodoRepository>();
        }
    }
}