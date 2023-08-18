namespace INOW.API.Core
{
    public class AppDependencyResolver
    {
        private static AppDependencyResolver resolver;

        private readonly IServiceProvider serviceProvider;

        public static AppDependencyResolver Current
        {
            get
            {
                if (resolver == null)
                    throw new Exception("AppDependencyResolver not initialized. You should initialize it in Startup class");
                return resolver;
            }
        }

        public static void Init(IServiceProvider services)
        {
            resolver = new AppDependencyResolver(services);
        }

        public object GetService(Type serviceType)
        {
            return this.serviceProvider.GetService(serviceType);
        }

        public object GetScoped(Type serviceType)
        {
            using IServiceScope scope = this.serviceProvider.CreateScope();
            using IServiceScope factory = this.serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            return factory.ServiceProvider.GetService(serviceType);
        }

        public object GetScoped(string serviceName)
        {
            Type serviceType = this.GetType().Assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(serviceName));

            if (serviceType != null)
            {
                return this.GetScoped(serviceType);
            }

            return null;
        }

        private AppDependencyResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}
