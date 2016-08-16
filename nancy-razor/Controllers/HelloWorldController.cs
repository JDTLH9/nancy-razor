using nancy_razor.Models;

namespace nancy_razor.Controllers
{
    public interface IHelloWorldController
    {
        HelloWorldModel GetGreeting();
    }

    public class HelloWorldController : IHelloWorldController
    {
        public HelloWorldModel GetGreeting()
        {
            var model = new HelloWorldModel {Greeting = "World!"};

            return model;
        }
    }
}
