using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogViewer.OpenTelemetryCollector.Properties;
using Analogy.LogViewer.Template.WinForms;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.OpenTelemetryCollector.IAnalogy
{
    public class ExampleUserSettingsFactory : TemplateUserSettingsFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = OtelpPrimaryFactory.Id;
        public override Guid Id { get; set; } = new Guid("d16cac0d-5dab-4afd-940f-f9fb79184115");
        public override UserControl DataProviderSettings { get; set; }
        public override string Title { get; set; } = "Otel User Settings";
        public override Image? SmallImage { get; set; } = Resources.Analogy_image_16x16;
        public override Image? LargeImage { get; set; } = Resources.Analogy_image_32x32;
        public override AnalogyToolTip ToolTip { get; set; } = new AnalogyToolTipWithImages("Otel user settings", "", "", Resources.Analogy_image_16x16, Resources.Analogy_image_32x32);

        public override void CreateUserControl(ILogger logger)
        {
            DataProviderSettings = new UserControl();
        }

        public override Task SaveSettingsAsync()
        {
            return Task.CompletedTask;
        }
    }
}