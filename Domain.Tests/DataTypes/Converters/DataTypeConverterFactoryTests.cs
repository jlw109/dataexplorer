﻿using System;
using System.Windows.Media.Imaging;
using DataExplorer.Domain.DataTypes.Converters;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.DataTypes.Converters
{
    [TestFixture]
    public class DataTypeConverterFactoryTests
    {
        private DataTypeConverterFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new DataTypeConverterFactory();
        }

        [Test]
        public void TestCreateStringToBooleanConverter()
        {
            var result = _factory.Create(typeof(String), typeof(Boolean));
            Assert.That(result, Is.TypeOf<StringToBooleanConverter>());
        }

        [Test]
        public void TestCreateStringToDateTimeConverter()
        {
            var result = _factory.Create(typeof(String), typeof(DateTime));
            Assert.That(result, Is.TypeOf<StringToDateTimeConverter>());
        }

        [Test]
        public void TestCreateStringToIntegerConverter()
        {
            var result = _factory.Create(typeof(String), typeof(Int32));
            Assert.That(result, Is.TypeOf<StringToIntegerConverter>());
        }

        [Test]
        public void TestCreateStringToFloatConverter()
        {
            var result = _factory.Create(typeof(String), typeof(Double));
            Assert.That(result, Is.TypeOf<StringToFloatConverter>());
        }

        [Test]
        public void TestCreateStringShouldUsePathThroughConverter()
        {
            var result = _factory.Create(typeof(String), typeof(String));
            Assert.That(result, Is.TypeOf<PassThroughConverter>());
        }

        [Test]
        public void TestCreateBitmapImageShouldUsePathThroughConverter()
        {
            var result = _factory.Create(typeof(String), typeof(BitmapImage));
            Assert.That(result, Is.TypeOf<PassThroughConverter>());
        }

        [Test]
        public void TestCreateWithInvalidTypeThrowsException()
        {
            Assert.That(() => _factory.Create(typeof(object), typeof(object)), Throws.ArgumentException);
        }
    }
}
