#if NET
using Analogy.LogViewer.OpenTelemetryCollector.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    internal class OtelGrpcHosting
    {
        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, UserSettingsManager.UserSettings.Settings.SelfHostingServerPort,
                            listenOptions =>
                            {
                                listenOptions.Protocols = HttpProtocols.Http2;
                            });
                    });
                    webBuilder.UseStartup<Startup>();

                    //webBuilder.ConfigureKestrel((context, options) =>
                    //    {
                    //        options.Configure()
                    //            .Endpoint("Http", listenOptions =>
                    //            {
                    //                listenOptions.ListenOptions.Protocols = HttpProtocols.Http2;
                    //            });
                    //    })
                    //    .UseUrls(UserSettingsManager.UserSettings.Settings.SelfHostingServerAddress)
                    //    .UseStartup<Startup>();
                });
    }
}
#endif