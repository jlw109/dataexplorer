﻿using System.Windows;

namespace DataExplorer.Presentation.Core.Canvas.Events
{
    public class CanvasZoomOutEventArgs
    {
        private readonly Point _point;

        public CanvasZoomOutEventArgs(Point point)
        {
            _point = point;
        }

        public Point Point
        {
            get { return _point; }
        }
    }
}