using System;
using System.Collections.Generic;
using System.Text;

namespace Analogy.LogViewer.OpenTelemetryCollector
{
    internal class GRPCSettings
    {
        public string GRPCAddress { get; set; }
        public int SelfHostingServerPort { get; set; }

        public GRPCSettings()
        {
            GRPCAddress = "http://localhost:4317";
            SelfHostingServerPort = 4317;
        }
    }
}