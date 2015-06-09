using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ILoveTrees
{
    class Land
    {
        private double _height;


        public Land(Canvas renderingCanvas, Random chaosGenerator, double height)
        {

            _height = height;

            Path myPath = new Path();

            SolidColorBrush brush = new SolidColorBrush();
            byte lightColor = (byte)chaosGenerator.Next(64, 128);
            brush.Color = Color.FromArgb(255, 0, lightColor, 0);

            myPath.Stroke = brush;

            LinearGradientBrush fiveColorLGB = new LinearGradientBrush();
            fiveColorLGB.StartPoint = new Point(0.5, 0);
            fiveColorLGB.EndPoint = new Point(0.5, 1);

            // Create and add Gradient stops
            GradientStop blueGS = new GradientStop();
            blueGS.Color = Color.FromArgb(255, 0, (byte)(lightColor + 64), 0);
            blueGS.Offset = 0.0;
            fiveColorLGB.GradientStops.Add(blueGS);

            // Create and add Gradient stops
            GradientStop redGS = new GradientStop();
            redGS.Color = Color.FromArgb(255, 0, lightColor, 0);
            redGS.Offset = 1.0;
            fiveColorLGB.GradientStops.Add(redGS);

            myPath.Fill = fiveColorLGB;
            myPath.StrokeThickness = 2;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;

            PathGeometry pGeo = new PathGeometry();
            PathFigure pFig = new PathFigure();
            pFig.IsClosed = true;
            PolyQuadraticBezierSegment pQBez = new PolyQuadraticBezierSegment();

            pFig.StartPoint = new Point(0, 0); //Start Point
            pQBez.Points.Add(new Point(0, height)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
            pQBez.Points.Add(new Point(0, height)); // End Point

            pQBez.Points.Add(new Point(renderingCanvas.Width / 2, height + height * 0.3)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
            pQBez.Points.Add(new Point(renderingCanvas.Width, height)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint

            pQBez.Points.Add(new Point(renderingCanvas.Width, 0)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
            pQBez.Points.Add(new Point(renderingCanvas.Width, 0)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint

            pFig.Segments.Add(pQBez);
            pGeo.Figures.Add(pFig);

            myPath.Data = pGeo;

            renderingCanvas.Children.Add(myPath);
        }
    }
}
