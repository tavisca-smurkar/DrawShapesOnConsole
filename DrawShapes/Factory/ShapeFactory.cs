using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
namespace Factory
{
    public class ShapeFactory
    {
        public static Line GetLine()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Line>();
            container.RegisterType<Point>();
            Line line = container.Resolve<Line>();
            line.pointOne = container.Resolve<Point>();
            line.pointTwo = container.Resolve<Point>();
            return line;
        }



        public static Rectangle GetRectangle()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Rectangle>();
            container.RegisterType<Point>();
            Rectangle rectangle = container.Resolve<Rectangle>();
            rectangle.pointOne = container.Resolve<Point>();
            rectangle.pointTwo = container.Resolve<Point>();
            return rectangle;
        }



        public static Circle GetCircle()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<Circle>();
            Circle circle = container.Resolve<Circle>();
            circle.pointOne = container.Resolve<Point>();
            return circle;
        }
    }
}
