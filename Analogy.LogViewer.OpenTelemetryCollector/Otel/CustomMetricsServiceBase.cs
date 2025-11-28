#if NET
using Grpc.Core;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Proto.Collector.Metrics.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.OpenTelemetryCollector.Otel
{
    public class CustomMetricsServiceBase(ILogger<CustomMetricsServiceBase> logger) : MetricsService.MetricsServiceBase
    {
        public override Task<ExportMetricsServiceResponse> Export(ExportMetricsServiceRequest request, ServerCallContext context)
        {
            foreach (var resourceMetric in request.ResourceMetrics)
            {
                foreach (var scopeMetric in resourceMetric.ScopeMetrics)
                {
                    foreach (var matric in scopeMetric.Metrics)
                    {
                        Console.WriteLine($"Received matric: {matric.Name}");
                    }
                }
            }

            return Task.FromResult(new ExportMetricsServiceResponse());
        }
    }
}
#endif