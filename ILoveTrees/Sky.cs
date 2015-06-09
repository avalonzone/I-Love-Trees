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
    class Sky
    {
        public Sky(Canvas renderingCanvas)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = renderingCanvas.Width;
            rectangle.Height = renderingCanvas.Height;

            LinearGradientBrush fiveColorLGB = new LinearGradientBrush();
            fiveColorLGB.StartPoint = new Point(0.5, 0);
            fiveColorLGB.EndPoint = new Point(0.5, 1);

            // Create and add Gradient stops
            GradientStop blueGS = new GradientStop();
            blueGS.Color = Color.FromArgb(255, 240, 130, 0);
            blueGS.Offset = 0.0;
            fiveColorLGB.GradientStops.Add(blueGS);

            // Create and add Gradient stops
            GradientStop redGS = new GradientStop();
            redGS.Color = Color.FromArgb(255,61,97,150);
            redGS.Offset = 1.0;
            fiveColorLGB.GradientStops.Add(redGS);

            // Set Fill property of rectangle
            rectangle.Fill = fiveColorLGB;

            renderingCanvas.Children.Add(rectangle);
        }
    }
}
