using Microsoft.Extensions.DependencyInjection;
using MicroShop.Core.Configuration;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace MicroShop.Core.Features.Telemetry
{
    public static class Registration
    {
        public static MicroShopCoreBuilder WithTelemetry(this MicroShopCoreBuilder builder, Action<TelemetryConfiguration> configuration)
        {
            TelemetryConfiguration telemetryConfiguration = new TelemetryConfiguration();

            configuration.Invoke(telemetryConfiguration);

            builder.Services.AddOpenTelemetry().WithTracing(builder =>
            {
                builder
                .AddAspNetCoreInstrumentation()
                .ConfigureResource(resource =>
                {
                    resource.AddService(telemetryConfiguration.ServiceName, serviceVersion: telemetryConfiguration.ServiceVersion);
                })
                .AddConsoleExporter();
            });

            return builder;
        }
    }
}
