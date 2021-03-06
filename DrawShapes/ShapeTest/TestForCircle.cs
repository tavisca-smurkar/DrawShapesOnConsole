﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Factory;
using CanvasPainting;
using System.Collections.Generic;

namespace ShapeTest
{
    [TestClass]
    public class TestForCircle
    {
        [TestMethod]
        public void TestDrawCanvas()
        {
            Shape shape = ShapeFactory.GetCircle();
            shape.pointOne.X = 10;
            shape.pointOne.Y = 10;
            shape.radius = 2;
            Canvas canvas = new Canvas();
            canvas.size = new string[10, 10];
            canvas.shapeList = new List<Shape>();
            canvas.shapeList.Add(shape);
            CanvasPainter.CreateCanvas(canvas);
        }
    }
}
