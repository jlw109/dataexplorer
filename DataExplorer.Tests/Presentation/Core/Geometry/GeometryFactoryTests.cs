﻿using System.Windows;
using DataExplorer.Presentation.Core.Geometry;
using NUnit.Framework;

namespace DataExplorer.Tests.Presentation.Core.Geometry
{
    [TestFixture]
    public class GeometryFactoryTests
    {
        private GeometryFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new GeometryFactory();
        }

        [Test]
        public void TestCreateCircleShouldCreateCircleBasedOnExtent()
        {
            var extent = new Rect(1, 2, 3, 4);
            var result = _factory.CreateCircle(extent);
            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(2));
            Assert.That(result.Radius, Is.EqualTo(1.5d));
        }
    }
}
