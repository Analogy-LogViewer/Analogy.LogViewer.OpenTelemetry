using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.OpenTelemetry.IAnalogy
{
    public class OtelMetricOnDemandPlottingFactory : IAnalogyOnDemandPlottingFactory
    {
        public Guid Id { get; set; } = new Guid("2f59de24-aaab-4de0-9269-ef681f8f3ee6");
        public string Title { get; set; } = "on Demand Metric Plotting";
        public List<IAnalogyOnDemandPlotting> OnDemandPlottingGenerators { get; set; }
        public event EventHandler<IAnalogyOnDemandPlotting>? OnAddedOnDemandPlottingGenerator;
        public event EventHandler<IAnalogyOnDemandPlotting>? OnRemovedOnDemandPlottingGenerator;

        public OtelMetricOnDemandPlottingFactory()
        {
            OnDemandPlottingContainer.Instance.SetFactory(this);
            OnDemandPlottingGenerators = new List<IAnalogyOnDemandPlotting>();
        }

        public void AddedOnDemandPlottingGenerator(IAnalogyOnDemandPlotting plotGenerator)
        {
            OnDemandPlottingGenerators.Add(plotGenerator);
            OnAddedOnDemandPlottingGenerator?.Invoke(this, plotGenerator);
        }
    }
}