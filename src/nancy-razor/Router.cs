using nancy_razor.Controllers;
using Nancy;

namespace nancy_razor
{
    public class Router : NancyModule
    {
        private readonly IHelloWorldController _helloWorldController;

        public Router(IHelloWorldController helloWorldController)
        {
            _helloWorldController = helloWorldController;

            Get["/hello-world"] = o => View["HelloWorld", _helloWorldController.GetGreeting()];
        }
    }
}
