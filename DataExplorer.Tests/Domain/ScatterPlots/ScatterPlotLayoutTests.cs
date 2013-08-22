﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Events;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Tests.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Tests.Domain.ScatterPlots
{
    [TestFixture]
    public class ScatterPlotLayoutTests
    {
        private ScatterPlotLayout _layout;
        private Column _xAxisColumn;
        private Column _yAxisColumn;

        [SetUp]
        public void SetUp()
        {
            _xAxisColumn = new ColumnBuilder().Build();
            _yAxisColumn = new ColumnBuilder().Build();
            _layout = new ScatterPlotLayout()
            {
                XAxisColumn = _xAxisColumn,
                YAxisColumn = _yAxisColumn
            };
        }

        [Test]
        public void TestGetXAxisColumnShouldReturnXAxisColumn()
        {
            var result = _layout.XAxisColumn;
            Assert.That(result, Is.EqualTo(_xAxisColumn));
        }

        [Test]
        public void TestSetXAxisColumnShouldSetXAxisColumn()
        {
            var column = new ColumnBuilder().Build();
            _layout.XAxisColumn = column;
            Assert.That(_layout.XAxisColumn, Is.EqualTo(column));
        }

        [Test]
        public void TestSetXAxisColumnShouldRaiseScatterPlotLayoutChangedEvent()
        {
            var column = new ColumnBuilder().Build();
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotLayoutChangedEvent>(p => { wasRaised = true; });
            _layout.XAxisColumn = column;
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }

        [Test]
        public void TestGetYAxisColumnShouldReturnYAxisColumn()
        {
            var result = _layout.YAxisColumn;
            Assert.That(result, Is.EqualTo(_yAxisColumn));
        }

        [Test]
        public void TestSetYAxisColumnShouldSetYAxisColumn()
        {
            var column = new ColumnBuilder().Build();
            _layout.YAxisColumn = column;
            Assert.That(_layout.YAxisColumn, Is.EqualTo(column));
        }

        [Test]
        public void TestSetYAxisColumnShouldRaiseScatterPlotLayoutChangedEvent()
        {
            var column = new ColumnBuilder().Build();
            var wasRaised = false;
            DomainEvents.Register<ScatterPlotLayoutChangedEvent>(p => { wasRaised = true; });
            _layout.YAxisColumn = column;
            Assert.That(wasRaised, Is.True);
            DomainEvents.ClearHandlers();
        }
    }
}
