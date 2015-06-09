using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ILoveTrees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random ChaosFactor = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Generate_Click(object sender, RoutedEventArgs e)
        {
            Canvas_DrawingBoard.Children.Clear();
            Canvas_DrawingBoard.ClipToBounds = true;

            Sky sky = new Sky(Canvas_DrawingBoard);

            for (int i = 0; i < 64; i++)
            {
                Cloud cloud = new Cloud(Canvas_DrawingBoard, ChaosFactor, ChaosFactor.Next(0, (int)Canvas_DrawingBoard.Width), (Canvas_DrawingBoard.Height/3*2 + i*(i/16)), 150, 50, (1.0/64*i));
            }

            Land land_01 = new Land(Canvas_DrawingBoard, ChaosFactor, Canvas_DrawingBoard.Height / 3);
            Land land_02 = new Land(Canvas_DrawingBoard, ChaosFactor, Canvas_DrawingBoard.Height / 4);
            Land land_03 = new Land(Canvas_DrawingBoard, ChaosFactor, Canvas_DrawingBoard.Height / 6);

            Tree tree_01 = new Tree(ChaosFactor, 10, Canvas_DrawingBoard, 256, 80);
            Tree tree_02 = new Tree(ChaosFactor, 10, Canvas_DrawingBoard, 800, 30);

            GrassTuft grassTuft_01 = new GrassTuft(Canvas_DrawingBoard, ChaosFactor, 256, 80, 40, 40);

            for (int i = 0; i < 1024; i++)
            {
                Grass grassTest = new Grass(Canvas_DrawingBoard, ChaosFactor);
            }

            Canvas_DrawingBoard.RenderTransform = new RotateTransform(180, Canvas_DrawingBoard.Width / 2, Canvas_DrawingBoard.Height / 2);

        }
    }
}
