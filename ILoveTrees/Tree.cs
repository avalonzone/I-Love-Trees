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
    class Tree
    {
        private Random _chaosGenerator;
        private Canvas _renderingCanvas;
        private double _centerX;
        private double _centerY;
        private int _depth;

        public Tree(Random chaosGenerator, int depth, Canvas renderingCanvas, double x, double y)
        {
            _centerX = x;
            _centerY = y;
            _renderingCanvas = renderingCanvas;
            _chaosGenerator = chaosGenerator;
            _depth = depth;

            Line RootLine = new Line();

            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromArgb(255, 76, 41, 0);

            RootLine.Stroke = brush;
            RootLine.StrokeThickness = 12;
            RootLine.X1 = _centerX;
            RootLine.X2 = _centerX;
            RootLine.Y1 = _centerY;
            RootLine.Y2 = _centerY;

            TreeBranch Root = new TreeBranch(_chaosGenerator, _depth, _renderingCanvas, 90.0, 30.0, RootLine);
            TreeBranch FullTree = new TreeBranch(Root, _chaosGenerator.Next(85, 95));
        }
    }
}
