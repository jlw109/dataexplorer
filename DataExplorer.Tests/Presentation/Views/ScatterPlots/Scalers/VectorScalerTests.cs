﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Presentation.Views.ScatterPlots.Calculations;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Views.ScatterPlots.Renderers
{
    [TestFixture]
    public class VectorScalerTests
    {
        private VectorScaler _scaler;

        [SetUp]
        public void SetUp()
        {
            _scaler = new VectorScaler();
        }

        [Test]
        public void TestScaleVectorShouldScaleVector()
        {
            var vector = new Vector(0, 0);
            var controlSize = new Size(10, 10);
            var viewExtent = new Rect(0, 0, 10, 10);
            var result = _scaler.ScaleVector(vector, controlSize, viewExtent);
            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(0));
        }
    }
}
