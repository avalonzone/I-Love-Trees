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
    class GrassTuft
    {
        private static double deg_2_rad = Math.PI / 180.0;
        private Random _chaosGenerator;
        private Canvas _renderingCanvas;
        private double _centerX;
        private double _centerY;
        private double _height;
        private double _width;

        public GrassTuft(Canvas renderingCanvas, Random chaosGenerator, double x, double y, double width, double height){
            _renderingCanvas = renderingCanvas;
            _chaosGenerator = chaosGenerator;
            _centerX = x;
            _centerY = y;
            _width = width;
            _height = height;

            int i = 20;
            double pointModifier = _chaosGenerator.Next(1, 11) / 10;
            
            while (i < 161)
            {
                double pointX = _centerX + (_width - (_width*pointModifier)) * (Math.Cos(i * deg_2_rad));
                double pointY = _centerY + _height * (Math.Sin(i * deg_2_rad));

                double FloatingX = _centerX + _width/6 * (Math.Cos(i * deg_2_rad));

                Grass grass = new Grass(_renderingCanvas, _chaosGenerator, FloatingX, _centerY, pointX, pointY);

                i += _chaosGenerator.Next(10,15);
            }
        }
        
    }
}
