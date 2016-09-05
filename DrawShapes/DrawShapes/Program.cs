using CanvasPainting;
using Entities;
using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validatiors;
using log4net;
using log4net.Config;

namespace DrawShapes
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            try
            {


                XmlConfigurator.Configure();
                bool validPointCoordinate = false;
                int lengthOfCanvas = 0;
                int heightOfCanvas = 0;
                int choice = 0;
                bool validChoice = false;
                Canvas canvas = new Canvas();
                do
                {
                    Console.WriteLine("Enter the size of Canvas");
                    string heightString = Console.ReadLine();
                    validPointCoordinate = NumberValidator.ValidateNumber(heightString);
                    if (validPointCoordinate) heightOfCanvas = int.Parse(heightString);
                    string lengthString = Console.ReadLine();
                    validPointCoordinate = NumberValidator.ValidateNumber(lengthString);
                    if (validPointCoordinate) lengthOfCanvas = int.Parse(lengthString);


                } while (!validPointCoordinate);


                canvas.size = new string[heightOfCanvas, lengthOfCanvas];
                canvas.shapeList = new List<Shape>();

                do
                {
                    do
                    {

                        Console.WriteLine("Enter you Choice !");
                        Console.WriteLine("1. Line");
                        Console.WriteLine("2. Rectangle");
                        Console.WriteLine("3. Circle");



                        choice = 0;

                        validChoice = int.TryParse(Console.ReadLine(), out choice);

                    } while (choice < 0 || choice > 3);

                    if (validChoice)
                    {
                        switch (choice)
                        {
                            //Line
                            case 1:
                                Shape line = ShapeFactory.GetLine();

                                //Point One
                                Console.WriteLine("Enter the coordinates of first point");

                                Console.WriteLine("Enter the positive x coordinate (number).");
                            xCoordinatePointOneLabel:
                                String xCoordinate = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(xCoordinate);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("X coordinate of first point of the line is not valid !");
                                    goto xCoordinatePointOneLabel;
                                }
                                else
                                {
                                    line.pointOne.X = int.Parse(xCoordinate);
                                }

                                Console.WriteLine("Enter the positive y coordinate (number).");
                            yCoordinatePointOneLabel:
                                String yCoordinate = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(yCoordinate);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("y coordinate of first point of the line is not valid !");
                                    goto yCoordinatePointOneLabel;
                                }
                                else
                                {
                                    line.pointOne.Y = int.Parse(yCoordinate);
                                }

                                //Second One
                                Console.WriteLine("Enter the coordinates of second point");

                                Console.WriteLine("Enter the positive x coordinate (number).");
                            xCoordinatePointTwoLabel:
                                xCoordinate = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(xCoordinate);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("X coordinate of second point is not valid !");
                                    goto xCoordinatePointTwoLabel;
                                }
                                else
                                {
                                    line.pointTwo.X = int.Parse(xCoordinate);
                                }

                                Console.WriteLine("Enter the positive y coordinate (number).");
                            yCoordinatePointTwoLabel:
                                yCoordinate = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(yCoordinate);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("y coordinate of second point is not valid !");
                                    goto yCoordinatePointTwoLabel;
                                }
                                else
                                {
                                    line.pointTwo.Y = int.Parse(yCoordinate);
                                    canvas.shapeList.Add(line);
                                    CanvasPainter.CreateCanvas(canvas);
                                    logger.Info("Line drawn Successfully");
                                }


                                break;




                            //Rectangle
                            case 2:

                                //Point One
                                Shape rectangle = ShapeFactory.GetRectangle();
                                Console.WriteLine("Enter the coordinates of first point");

                                Console.WriteLine("Enter the positive x coordinate (number).");
                            xCoordinateRectanglePointOneLabel:
                                String xCoordinateOfRectangle = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(xCoordinateOfRectangle);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("X coordinate of first point of the rectangle is not valid !");
                                    goto xCoordinateRectanglePointOneLabel;
                                }
                                else
                                {
                                    rectangle.pointOne.X = int.Parse(xCoordinateOfRectangle);
                                }

                                Console.WriteLine("Enter the positive y coordinate (number).");
                            yCoordinateRectanglePointOneLabel:
                                String yCoordinateOfRectangle = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(yCoordinateOfRectangle);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("y coordinate of first point of the rectangle is not valid !");
                                    goto yCoordinateRectanglePointOneLabel;
                                }
                                else
                                {
                                    rectangle.pointOne.Y = int.Parse(yCoordinateOfRectangle);
                                }

                                //Second One
                                Console.WriteLine("Enter the coordinates of second point");

                                Console.WriteLine("Enter the positive x coordinate (number).");
                            xCoordinateRectanglePointTwoLabel:
                                xCoordinateOfRectangle = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(xCoordinateOfRectangle);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("X coordinate of second point of the rectangle is not valid !");
                                    goto xCoordinateRectanglePointTwoLabel;
                                }
                                else
                                {
                                    rectangle.pointTwo.X = int.Parse(xCoordinateOfRectangle);
                                }

                                Console.WriteLine("Enter the positive y coordinate (number).");
                            yCoordinateRectanglePointTwoLabel:
                                yCoordinateOfRectangle = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(yCoordinateOfRectangle);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("y coordinate of second point of the rectangle is not valid !");
                                    goto yCoordinateRectanglePointTwoLabel;
                                }
                                else
                                {
                                    rectangle.pointTwo.Y = int.Parse(yCoordinateOfRectangle);
                                    canvas.shapeList.Add(rectangle);
                                    CanvasPainter.CreateCanvas(canvas);
                                    logger.Info("Reactangle drawn Successfully");
                                }



                                break;


                            //Circle
                            case 3:


                                Shape circle = ShapeFactory.GetCircle();
                            tryCircle:





                                //Centre of Circle
                                Console.WriteLine("Enter the X coordinate of Centre");
                            xCentreLabel:
                                string xCoordinateOfCentre = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(xCoordinateOfCentre);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("x coordinate of centre is not valid");
                                    goto xCentreLabel;
                                }
                                else
                                {
                                    circle.pointOne.X = int.Parse(xCoordinateOfCentre);
                                }

                                Console.WriteLine("Enter the Y coordinate of Centre");
                            yCentreLabel:
                                string yCoordinateOfCentre = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(yCoordinateOfCentre);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("y coordinate of centre is not valid");
                                    goto yCentreLabel;
                                }
                                else
                                {
                                    circle.pointOne.Y = int.Parse(yCoordinateOfCentre);
                                }

                                //Radius
                                Console.WriteLine("Enter the radius of the circle.");
                            radiusLabel:
                                string radius = Console.ReadLine();
                                validPointCoordinate = NumberValidator.ValidateNumber(radius);
                                if (!validPointCoordinate)
                                {
                                    logger.Error("radius of circle is not valid");
                                    goto radiusLabel;
                                }
                                else
                                {
                                    circle.radius = int.Parse(radius);
                                }

                                if (!(circle.radius <= Math.Min(circle.pointOne.Y, circle.pointOne.X)))
                                {
                                    logger.Error("radius should be less than or equal to the minimum of x and y coordinate of centre.");
                                    goto tryCircle;
                                }
                                else
                                {
                                    canvas.shapeList.Add(circle);
                                    CanvasPainter.CreateCanvas(canvas);
                                    logger.Info("Circle drawn Successfully");
                                }

                                break;
                        }

                    }


                    Console.WriteLine("Do you want to continue? (y/n)");

                } while (Console.ReadLine() != "n");

            }
            catch(Exception ae)
            {
                logger.Error(ae.Message);
            }

        }

        
    }

}