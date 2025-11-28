using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.OpenTelemetryCollector.Properties;
using Analogy.LogViewer.Template.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelPrimaryFactory : PrimaryFactoryWinForms
    {
        internal static readonly Guid Id = new Guid("8a1c829a-54e9-408f-a7f7-f94e526876a9");
        public override Guid FactoryId { get; set; } = Id;

        public override string Title { get; set; } = "Open Telemetry";
        public override Image? SmallImage { get; set; } = Resources.Analogy_otel_icon16x16;
        public override Image? LargeImage { get; set; } = Resources.Analogy_otel_icon32x32;

        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("New Data provider", AnalogChangeLogType.None, "Lior Banai", new DateTime(2025, 11, 28), ""),
        };
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Analogy Otel Collector Data Source";
    }
}