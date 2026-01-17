namespace Dependency_Injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new DependencyContainer();
            container.AddSingleton<ServiceConsumer>();
            container.AddTransient<HelloService>();
            container.AddTransient<MessageService>();

            var resolver = new DependencyResolver(container);

            var service1 = resolver.getService<ServiceConsumer>();
            Console.WriteLine(service1.Print());
            var service2 = resolver.getService<ServiceConsumer>();
            Console.WriteLine(service2.Print());
            var service3 = resolver.getService<ServiceConsumer>();
            Console.WriteLine(service3.Print());
        }
    }
}
