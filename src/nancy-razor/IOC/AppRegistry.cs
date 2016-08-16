using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace nancy_razor.IOC
{
    internal class AppRegistry
    {
        public static void ScanCurrentAssembly(Container container)
        {
            var exclusions = new List<string> { "Router" };

            var repositoryAssembly = Assembly.GetExecutingAssembly();

            var registrations =
                repositoryAssembly.GetExportedTypes()
                    .Where(type => !exclusions.Contains(type.Name) && type.GetInterfaces().Any())
                    .Select(type => new { Service = type.GetInterfaces().Single(), Implementation = type });

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
            }
        }
    }
}
