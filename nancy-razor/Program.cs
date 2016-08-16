using nancy_razor.IOC;
using SimpleInjector;

namespace nancy_razor
{
    internal class Program
    {
        private static void Main()
        {
            var container = new Container();
            AppRegistry.ScanCurrentAssembly(container);
            container.GetInstance<IAppHost>();
        }
    }
}
