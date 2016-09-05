using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Factory;
using System.Collections.Generic;
using CanvasPainting;

namespace ShapeTest
{
    [TestClass]
    public class TestForRectangle
    {
        [TestMethod]
        public void TestDrawCanvas()
        {
            Shape shape = ShapeFactory.GetRectangle();
            shape.pointOne.X = 1;
            shape.pointOne.Y = 1;
            shape.pointTwo.X = 5;
            shape.pointTwo.Y = 5;
            Canvas canvas = new Canvas();
            canvas.size = new string[10, 10];
            canvas.shapeList = new List<Shape>();
            canvas.shapeList.Add(shape);
            CanvasPainter.CreateCanvas(canvas);
        }
    }
}
