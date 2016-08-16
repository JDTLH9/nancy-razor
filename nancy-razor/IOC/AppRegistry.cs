using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace nancy_razor.IOC
{
    internal class AppRegistry
    {
        public static void ScanCurrentAssembly(Container container)
        {
            var repositoryAssembly = Assembly.GetExecutingAssembly();

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.GetInterfaces().Any() && type.Name != "Router"
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }
    }
}
