﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Domain.Views;

namespace DataExplorer.Application.ScatterPlot
{
    public class ScatterPlotService : IScatterPlotService, IHandler<ScatterPlotChangedEvent>
    {
        private readonly IViewRepository _viewRepository;
        private readonly IScatterPlotAdapter _adapter;

        public event ScatterPlotChangedEventHandler ScatterPlotChanged;

        public ScatterPlotService(
            IViewRepository viewRepository,
            IScatterPlotAdapter adapter)
        {
            _viewRepository = viewRepository;
            _adapter = adapter;
        }

        public Rect GetViewExtent()
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            return scatterPlot.GetViewExtent();
        }

        public void SetViewExtent(Rect viewExtent)
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            scatterPlot.SetViewExtent(viewExtent);
        }

        public List<PlotDto> GetPlots()
        {
            var scatterPlot = _viewRepository.GetScatterPlot();

            var plots = scatterPlot.GetPlots();

            var plotDtos = _adapter.Adapt(plots);

            return plotDtos;
        }

        public void Handle(ScatterPlotChangedEvent args)
        {
            if (ScatterPlotChanged != null)
                ScatterPlotChanged(this, EventArgs.Empty);
        }
    }
}
