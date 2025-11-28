using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.Interfaces.WinForms.Factories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class OtelMetricsUserControlFactory : IAnalogyCustomUserControlsFactoryWinForms
    {
        public Guid FactoryId { get; set; } = OtelPrimaryFactory.Id;
        public string Title { get; set; } = "Metrics Viewer";

        public IEnumerable<IAnalogyCustomUserControlWinForms> UserControls { get; } = new List<IAnalogyCustomUserControlWinForms>
        {
            new MetricsUserControl(),
        };
    }

    public class MetricsUserControl : IAnalogyCustomUserControlWinForms
    {
        public Task InitializeUserControl(Control hostingControl, ILogger logger)
        {
            return Task.CompletedTask;
        }

        public Task UserControlRemoved()
        {
            return Task.CompletedTask;
        }

        public UserControl UserControl => new ExampleUserControlUC();
        public Guid Id { get; set; } = new Guid("ec1264aa-d503-4888-9772-572faa3f9a0c");
        public Image? SmallImage { get; set; }
        public Image? LargeImage { get; set; }
        public string Title { get; set; } = "Otelp Metric User Control";
        public AnalogyToolTipWithImages? ToolTip { get; set; }
    }
}