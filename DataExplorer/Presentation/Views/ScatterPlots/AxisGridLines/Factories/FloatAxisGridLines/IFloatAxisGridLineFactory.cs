﻿using System.Collections.Generic;
using DataExplorer.Domain.ScatterPlots;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Factories.FloatAxisGridLines
{
    public interface IFloatAxisGridLineFactory
    {
        IEnumerable<AxisGridLine> Create();
    }
}