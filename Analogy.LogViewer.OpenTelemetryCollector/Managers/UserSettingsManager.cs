using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector.Managers
{
    internal class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public string GRPCFileSetting { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.LogViewer.OpenTelemetryCollector", "AnalogyOpenTelemetryCollectorSettings.json");
        public GRPCSettings Settings { get; set; }

        public UserSettingsManager()
        {
            if (File.Exists(GRPCFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(GRPCFileSetting);
                    Settings = System.Text.Json.JsonSerializer.Deserialize<GRPCSettings>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogError(ex, "Error loading user setting file: {error}", ex);
                    Settings = new GRPCSettings();
                }
            }
            else
            {
                Settings = new GRPCSettings();
            }
        }
        public void Save()
        {
            try
            {
                string dir = Path.GetDirectoryName(GRPCFileSetting);
                Directory.CreateDirectory(dir);
                File.WriteAllText(GRPCFileSetting, System.Text.Json.JsonSerializer.Serialize(Settings));
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogCritical($"Unable to save file {GRPCFileSetting}: {ex}");
            }
        }
    }
}