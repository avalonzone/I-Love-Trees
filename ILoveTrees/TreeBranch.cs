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
    class TreeBranch
    {
        private Random _chaosGenerator;
        private List<TreeBranch> _children = new List<TreeBranch>();
        private TreeBranch _parent;
        private double _angle;
        private double _angleVariationFactor;
        private Canvas _renderingCanvas;
        private Line _graphicalObject;
        private int _depth;
        private static double deg_2_rad = Math.PI / 180.0;
        private Brush _brush;

        public Brush brush
        {
            get { return _brush; }
            set { _brush = value;  }
        }

        public Random chaosGenerator
        {
            get { return _chaosGenerator; }
            set { _chaosGenerator = value; }
        }

        public double angleVariationFactor
        {
            get { return _angleVariationFactor; }
            set { _angleVariationFactor = value; }
        }

        public Canvas renderingCanvas
        {
            get { return _renderingCanvas; }
            set { _renderingCanvas = value; }
        }

        public Line GraphicalObject
        {
            get { return _graphicalObject; }
            set { _graphicalObject = value; }
        }

        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        public TreeBranch(Random chaosGenerator, int depth, Canvas renderingCanvas, double angle, double angleVariationFactor, Line graphicalObject)
        {
            this._chaosGenerator = chaosGenerator;
            this._depth = depth;
            this._renderingCanvas = renderingCanvas;
            this._angle = angle;
            this._angleVariationFactor = angleVariationFactor;
            this._graphicalObject = graphicalObject;
            this._renderingCanvas.Children.Add(this._graphicalObject);

        }

        public TreeBranch(TreeBranch parent, double angle)
        {
            try
            {
                this._parent = parent;
                this._angle = angle;
                this._depth = this._parent.Depth - 1;
                this._renderingCanvas = this._parent.renderingCanvas;
                this._angleVariationFactor = this._parent.angleVariationFactor;
                this._chaosGenerator = _parent.chaosGenerator;

                this._graphicalObject = new Line();

                SolidColorBrush ParentBrush = (SolidColorBrush)this._parent.GraphicalObject.Stroke;
                byte Green = (byte)(ParentBrush.Color.G + 10);

                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Color.FromArgb(255, ParentBrush.Color.R, Green, 0);

                this._graphicalObject.Stroke = brush;
                this._graphicalObject.StrokeThickness = (double)(this._parent.GraphicalObject.StrokeThickness / 1.25);
                this._graphicalObject.X1 = _parent.GraphicalObject.X2;
                this._graphicalObject.X2 = (double)(_parent.GraphicalObject.X2 + (Math.Cos(_angle * deg_2_rad) * this._depth * (this._chaosGenerator.Next(5,15))));
                this._graphicalObject.Y1 = _parent.GraphicalObject.Y2;
                this._graphicalObject.Y2 = (double)(_parent.GraphicalObject.Y2 + (Math.Sin(_angle * deg_2_rad) * this._depth * (this._chaosGenerator.Next(5,15))));

                if (this._depth > 0)
                {
                    this._renderingCanvas.Children.Add(this._graphicalObject);

                    TreeBranch LeftChild = new TreeBranch(this, (this._angle - this._angleVariationFactor));
                    TreeBranch RightChild = new TreeBranch(this, (this._angle + this._angleVariationFactor));

                    _children.Add(LeftChild);
                    _children.Add(RightChild);
                }
                else
                {
                    Foliage foliage = new Foliage(_renderingCanvas, _chaosGenerator, _graphicalObject.X2, _graphicalObject.Y2, 150, 50, 0.25,_angle);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Source);
            }
            
        }
    }
}
