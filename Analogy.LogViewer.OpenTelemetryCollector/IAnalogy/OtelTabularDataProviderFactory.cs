using Analogy.Interfaces;
using Analogy.LogViewer.Template.WinForms;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelTabularDataProviderFactory : DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = OtelPrimaryFactory.Id;
        public override string Title { get; set; } = "Analogy Otel tabular Data";

        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider>
        {
            new OtelMetricsOnlineDataProvider(),
        };
    }
}