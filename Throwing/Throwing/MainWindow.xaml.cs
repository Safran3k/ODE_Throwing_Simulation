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

namespace Throwing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PhysicsEngine physicsEngine;
        VisualEngine visualEngine;
        bool isSimulationRunning = false;

        public MainWindow()
        {
            InitializeComponent();

            physicsEngine = new PhysicsEngine(100, border1.Height / 2, 50, 70, 0.01, 1, 9.81, 1, 0.01, 0.4);
            visualEngine = new VisualEngine();
            visualEngine.Initialize(30);
            Canvas.SetLeft(visualEngine.Ball, 100);
            Canvas.SetTop(visualEngine.Ball, border1.Height / 2);
            canvas.Children.Add(visualEngine.Ball);
            canvas.Children.Add(visualEngine.Trajectory);
            canvas.Children.Add(visualEngine.HorizontalDashedLine);
            canvas.Children.Add(visualEngine.VertivalDashedLine);
            canvas.Children.Add(visualEngine.VerticalLine);
            canvas.Children.Add(visualEngine.HorizontalLine);
            canvas.Children.Add(visualEngine.VelocityLine);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!isSimulationRunning)
            {
                if (visualEngine == null)
                {
                    visualEngine = new VisualEngine();
                    visualEngine.Initialize(30);
                }

                CompositionTarget.Rendering += StartAnimation;
                isSimulationRunning = true;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            if (canvas.Children.Count > 1)
            {
                CompositionTarget.Rendering -= StartAnimation;
                visualEngine.Initialize(30);
                isSimulationRunning = false;
                Canvas.SetLeft(visualEngine.Ball, 100);
                Canvas.SetTop(visualEngine.Ball, border1.Height / 2);
                visualEngine.ClearTrajectory();
                visualEngine.ClearLines();
                physicsEngine.ResetState(border1.Height);
                lbInfo.Content = string.Empty;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            double[] result = physicsEngine.UpdateState();
            double x = result[0];
            double y = result[1];
            if ((x < border1.Width + 15) && (15 < x) && (y < border1.Height + 15) && (15 < y))
            {
                visualEngine.UpdateTrajectory(new Point(x + 15, border1.Height - y + 15));
                visualEngine.UpdateVelocityVectors(border1.Height, x, y, result[2], result[3]);
                Canvas.SetLeft(visualEngine.Ball, x);
                Canvas.SetTop(visualEngine.Ball, border1.Height - y);
                lbInfo.Content = $"Vx: {(int)result[2]} m/s\t" +
                    $"Vy: {(int)result[3]} m/s\t" +
                    $"V: {(int)Math.Sqrt(Math.Pow(result[2], 2) + Math.Pow(result[3], 2))} m/s";
            }
            else
            {
                lbInfo.Foreground = new SolidColorBrush(Colors.Red);
                lbInfo.Content = $"Bang!!! The result is: {(int)result[0]} m";
                CompositionTarget.Rendering -= StartAnimation;
            }
        }
    }
}
