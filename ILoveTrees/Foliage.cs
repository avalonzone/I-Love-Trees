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
    class Foliage
    {
        private static double deg_2_rad = Math.PI / 180.0;
        private double _centerX;
        private double _centerY;
        private double _height;
        private double _width;
        private double _scaleFactor;
        private double _angle;
        private byte _alpha;

        public double ScaleFactor
        {
            get { return _scaleFactor; }
            set { _scaleFactor = value; }
        }

        public Foliage(Canvas renderingCanvas, Random chaosGenerator, double x, double y, double width, double height, double scaleFactor, double angle)
        {
            _centerX = x;
            _centerY = y;
            _width = width;
            _height = height;
            _scaleFactor = scaleFactor;
            _angle = angle;
            _alpha = 64;

            Path myPath = new Path();

            SolidColorBrush brush = new SolidColorBrush();
            byte lightColor = (byte)chaosGenerator.Next(128, 192);
            brush.Color = Color.FromArgb(_alpha, 0, (byte)(lightColor - 32), 0);

            myPath.Stroke = brush;

            RadialGradientBrush gradientBrush = new RadialGradientBrush();
            gradientBrush.RadiusX = _width / 2;
            gradientBrush.RadiusY = _height / 2;
            gradientBrush.Center = new Point(_centerX, _centerY);
            gradientBrush.GradientOrigin = new Point(_centerX + 20, _centerY + 10);

            // Create and add Gradient stops
            GradientStop highColor = new GradientStop();
            highColor.Color = Color.FromArgb(_alpha, 0, (byte)(lightColor + 64), 0);
            highColor.Offset = 0.0;
            gradientBrush.GradientStops.Add(highColor);

            // Create and add Gradient stops
            GradientStop lowColor = new GradientStop();
            lowColor.Color = Color.FromArgb(_alpha, 0, lightColor, 0);
            lowColor.Offset = 1.0;
            gradientBrush.GradientStops.Add(lowColor);

            myPath.Fill = gradientBrush;

            PathGeometry pGeo = new PathGeometry();
            PathFigure pFig = new PathFigure();
            pFig.IsClosed = true;
            PolyQuadraticBezierSegment pQBez = new PolyQuadraticBezierSegment();

            int i = 0;

            double startX = _centerX + _width * (Math.Cos(i * deg_2_rad));
            double startY = _centerY + _height * (Math.Sin(i * deg_2_rad));

            double anchorModifier = 30;
            int stepModifier = chaosGenerator.Next(30, 61);

            pFig.StartPoint = new Point(startX, startY); //Start Point
            i += stepModifier;

            while (i < 320)
            {
                double anchorX = _centerX + (_width + anchorModifier) * (Math.Cos((i - (stepModifier / 2)) * deg_2_rad));
                double anchorY = _centerY + (_height + anchorModifier) * (Math.Sin((i - (stepModifier / 2)) * deg_2_rad));

                double pointX = _centerX + _width * (Math.Cos(i * deg_2_rad));
                double pointY = _centerY + _height * (Math.Sin(i * deg_2_rad));

                pQBez.Points.Add(new Point(anchorX, anchorY)); // Anchor Point Y = 1/2 Height (endpoint) X = X Startpoint
                pQBez.Points.Add(new Point(pointX, pointY)); // End Point

                stepModifier = chaosGenerator.Next(30, 61);

                i += stepModifier;
            }

            double anchorEndX = _centerX + (_width + anchorModifier) * (Math.Cos((i - (stepModifier / 2)) * deg_2_rad));
            double anchorEndY = _centerY + (_height + anchorModifier) * (Math.Sin((i - (stepModifier / 2)) * deg_2_rad));

            double pointEndX = _centerX + _width * (Math.Cos(360 * deg_2_rad));
            double pointEndY = _centerY + _height * (Math.Sin(360 * deg_2_rad));


            pQBez.Points.Add(new Point(anchorEndX, anchorEndY));
            pQBez.Points.Add(new Point(pointEndX, pointEndY));


            pFig.Segments.Add(pQBez);
            pGeo.Figures.Add(pFig);

            myPath.Data = pGeo;

            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(new ScaleTransform(_scaleFactor, _scaleFactor, _centerX, _centerY));
            myTransformGroup.Children.Add(new RotateTransform(_angle, _centerX, _centerY));

            myPath.RenderTransform = myTransformGroup;

            renderingCanvas.Children.Add(myPath);
            
        }
    }
}
