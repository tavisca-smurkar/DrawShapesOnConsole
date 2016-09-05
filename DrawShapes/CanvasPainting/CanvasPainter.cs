using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasPainting
{
    public class CanvasPainter
    {
        public static void CreateCanvas(Canvas canvas)
        {
            for (int canvasVerticalBorder = 0; canvasVerticalBorder < canvas.size.GetLength(0); canvasVerticalBorder++)
            {
                for (int canvasHorizontalBorder = 0; canvasHorizontalBorder < canvas.size.GetLength(1); canvasHorizontalBorder++)
                {
                    if (canvasVerticalBorder == 0 || canvasVerticalBorder == canvas.size.GetLength(0) - 1)
                    {
                        canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "X";
                    }
                    else if (canvasHorizontalBorder == 0 || canvasHorizontalBorder == canvas.size.GetLength(1) - 1)
                    {
                        canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "X";
                    }
                    else
                    {
                        foreach (var shape in canvas.shapeList)
                        {
                            //For Line
                            if (shape is Line)
                            {

                                int slope = 0;
                                if (shape.pointTwo.X - shape.pointOne.X == 0) slope = -1;
                                else if (shape.pointTwo.Y - shape.pointOne.Y == 0) slope = 0;
                                else
                                {
                                    slope = (shape.pointTwo.Y - shape.pointOne.Y) / (shape.pointTwo.X - shape.pointOne.X);
                                }

                                if (canvasHorizontalBorder >= 1 + shape.pointOne.X && canvasHorizontalBorder <= shape.pointTwo.X + 1 && canvasVerticalBorder >= 1 + shape.pointOne.Y && canvasVerticalBorder <= shape.pointTwo.Y + 1)
                                {

                                    canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "*";
                                    if (shape.pointOne.X != shape.pointTwo.X)
                                    {
                                        shape.pointOne.X++;
                                    }
                                    if (shape.pointOne.Y != shape.pointTwo.Y)
                                    {
                                        shape.pointOne.Y += slope;
                                    }
                                }
                                else
                                {
                                    if (canvas.size[canvasVerticalBorder, canvasHorizontalBorder] != "*")
                                    {
                                        canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = " ";
                                    }
                                }
                            }

                            // For Reactangle
                            if (shape is Rectangle)
                            {
                                if ((canvasVerticalBorder == shape.pointOne.Y + 1 || canvasVerticalBorder == shape.pointTwo.Y + 1) && (canvasHorizontalBorder >= shape.pointOne.X + 1 && canvasHorizontalBorder <= shape.pointTwo.X + 1))
                                {
                                    canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "*";
                                }
                                else if ((canvasHorizontalBorder == shape.pointOne.X + 1 || canvasHorizontalBorder == shape.pointTwo.X + 1) && (canvasVerticalBorder >= shape.pointOne.X + 1 && canvasVerticalBorder <= shape.pointTwo.X + 1))
                                {
                                    canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "*";
                                }
                                else
                                {
                                    if (canvas.size[canvasVerticalBorder, canvasHorizontalBorder] != "*")
                                    {
                                        canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = " ";
                                    }
                                }
                            }

                            if (shape is Circle)
                            {
                                if (Math.Sqrt(Math.Pow(Math.Abs(canvasVerticalBorder - shape.pointOne.Y - 1 ), 2) + Math.Pow(Math.Abs(canvasHorizontalBorder - shape.pointOne.X - 1 ), 2)) == shape.radius)
                                {
                                    canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = "*";
                                }
                                else
                                {
                                    if (canvas.size[canvasVerticalBorder, canvasHorizontalBorder] != "*")
                                    {
                                        canvas.size[canvasVerticalBorder, canvasHorizontalBorder] = " ";
                                    }
                                }
                            }
                        }

                        



                    }
                }
               
            }
            PaintCanvas(canvas);
        }
        public static void PaintCanvas(Canvas canvas)
        {
            for (int canvasVerticalBorder = 0; canvasVerticalBorder <  canvas.size.GetLength(0); canvasVerticalBorder++)
            {
                for (int canvasHorizontalBorder = 0; canvasHorizontalBorder < canvas.size.GetLength(1); canvasHorizontalBorder++)
                {
                    Console.Write(canvas.size[canvasVerticalBorder, canvasHorizontalBorder]);
                }
                Console.WriteLine();
            }
        }
    }
}
