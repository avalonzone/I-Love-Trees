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
    class Grass
    {
        private Random _chaosGenerator;
        private Canvas _renderingCanvas;
        private double _centerX;
        private double _centerY;
        private double _pointX;
        private double _pointY;
        

        public Grass(Canvas renderingCanvas, Random chaosGenerator, double x, double y, double pointX, double pointY)
        {
            _renderingCanvas = renderingCanvas;
            _chaosGenerator = chaosGenerator;
            _centerX = x;
            _centerY = y;
            _pointX = pointX;
            _pointY = pointY;

            Path myPath = new Path();

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(255, 0, (byte)_chaosGenerator.Next(128, 192), 0);

            myPath.Stroke = brush;
            myPath.StrokeThickness = 2;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;

            PathGeometry pGeo = new PathGeometry();
            PathFigure pFig = new PathFigure();
            PolyQuadraticBezierSegment pQBez = new PolyQuadraticBezierSegment();

            pFig.StartPoint = new Point(_centerX, _centerY); //Start Point
            pQBez.Points.Add(new Point(_centerX, _pointY)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
            pQBez.Points.Add(new Point(_pointX, _pointY)); // End Point

            pFig.Segments.Add(pQBez);
            pGeo.Figures.Add(pFig);

            myPath.Data = pGeo;

            _renderingCanvas.Children.Add(myPath);
            
        }

        public Grass(Canvas renderingCanvas, Random chaosGenerator)
        {
            _renderingCanvas = renderingCanvas;
            _chaosGenerator = chaosGenerator;

            Path myPath = new Path();

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(255, 0, (byte)_chaosGenerator.Next(128, 192), 0);

            myPath.Stroke = brush;
            myPath.StrokeThickness = 2;
            myPath.HorizontalAlignment = HorizontalAlignment.Left;
            myPath.VerticalAlignment = VerticalAlignment.Center;

            PathGeometry pGeo = new PathGeometry();
            PathFigure pFig = new PathFigure();
            PolyQuadraticBezierSegment pQBez = new PolyQuadraticBezierSegment();

            double StartX = _chaosGenerator.Next(0, (int)_renderingCanvas.Width);
            double StartY = 0;
            double EndX = 0;

            if (_chaosGenerator.Next(0, 2) > 0)
            {
                EndX = StartX - _chaosGenerator.Next(4, 32);
            }
            else
            {
                EndX = StartX + _chaosGenerator.Next(4, 32);
            }

            double EndY = _chaosGenerator.Next(50, 65) - _chaosGenerator.Next(4, 32);

            pFig.StartPoint = new Point(StartX, StartY); //Start Point
            pQBez.Points.Add(new Point(StartX, (EndY / 2))); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
            pQBez.Points.Add(new Point(EndX, EndY)); // End Point

            pFig.Segments.Add(pQBez);
            pGeo.Figures.Add(pFig);

            myPath.Data = pGeo;

            _renderingCanvas.Children.Add(myPath);

        }

        /*
        public Grass(Canvas renderingCanvas, Random chaosGenerator, double x, double y)
            : base(renderingCanvas, chaosGenerator)
        {

        }*/
    }
}
