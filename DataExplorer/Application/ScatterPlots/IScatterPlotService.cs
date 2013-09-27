﻿using System.Collections.Generic;
using System.Windows;

namespace DataExplorer.Application.ScatterPlots
{
    public interface IScatterPlotService
    {
        Rect GetViewExtent();
        void SetViewExtent(Rect viewExtent);
        List<PlotDto> GetPlots();
        void ZoomIn(Point center);
        void ZoomOut(Point center);
        void Pan(Vector vector);
    }
}