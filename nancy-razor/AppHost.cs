using System;
using System.Diagnostics;
using Microsoft.Owin.Hosting;
using Owin;
using Topshelf;

namespace nancy_razor
{
    public interface IAppHost
    {
    }

    public class AppHost : IAppHost
    {
        public AppHost()
        {
            const string url = @"http://localhost:5060/nancy/";

            HostFactory.Run(
                ts =>
                {
                    ts.Service<StartOptions>(
                        service =>
                        {
                            IDisposable owinMost = null;

                            service.ConstructUsing(settings => new StartOptions(url));

                            service.WhenStarted(
                                options =>
                                {
                                    owinMost = Host(options);

                                    Trace.WriteLine($"Listening on {url}");
                                });

                            service.WhenStopped(callback => { owinMost?.Dispose(); });
                        });

                    ts.RunAsLocalSystem();
                    ts.SetDisplayName("nancy-razor");
                    ts.SetServiceName("nancy-razor");
                });
        }

        private static readonly Func<StartOptions, IDisposable> Host =
            options => WebApp.Start(options, appBuilder =>
            {
                appBuilder.UseNancy();
            });
    }
}
