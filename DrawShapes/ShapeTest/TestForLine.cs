using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Factory;
using CanvasPainting;
using System.Collections.Generic;
namespace ShapeTest
{
    [TestClass]
    public class TestForLine
    {
        [TestMethod]
        public void TestDrawCanvas()
        {
            Shape shape = ShapeFactory.GetLine();
            shape.pointOne.X = 10;
            shape.pointOne.Y = 10;
            shape.pointTwo.X = 50;
            shape.pointTwo.Y = 50;
            Canvas canvas = new Canvas();
            canvas.size = new string[10,10];
            canvas.shapeList = new List<Shape>();
            canvas.shapeList.Add(shape);
            CanvasPainter.CreateCanvas(canvas);
        }
    }
}
