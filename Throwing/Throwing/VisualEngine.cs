using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Throwing
{
    class VisualEngine
    {
        #region Fields
        Ellipse ball;
        Polyline trajectory;
        Line horizontalDashedLine;
        Line vertivalDashedLine;
        Line verticalLine;
        Line horizontalLine;
        Line velocityLine;
        #endregion

        #region Getter/Setter
        public Ellipse Ball { get => ball; set => ball = value; }
        public Polyline Trajectory { get => trajectory; set => trajectory = value; }
        public Line HorizontalDashedLine { get => horizontalDashedLine; set => horizontalDashedLine = value; }
        public Line VertivalDashedLine { get => vertivalDashedLine; set => vertivalDashedLine = value; }
        public Line HorizontalLine { get => horizontalLine; set => horizontalLine = value; }
        public Line VerticalLine { get => verticalLine; set => verticalLine = value; }
        public Line VelocityLine { get => velocityLine; set => velocityLine = value; }
        #endregion

        public VisualEngine()
        {
            Ball = new Ellipse();
            Trajectory = new Polyline();
            HorizontalDashedLine = new Line();
            VertivalDashedLine = new Line();
            HorizontalLine = new Line();
            VerticalLine = new Line();
            VelocityLine = new Line();
        }

        public void Initialize(double ballSize)
        {
            Ball.Width = ballSize;
            Ball.Height = ballSize;
            Ball.Fill = new SolidColorBrush(Colors.Red);

            Trajectory.Stroke = Brushes.Blue;
            Trajectory.StrokeThickness = 3;

            HorizontalDashedLine.Stroke = Brushes.DarkMagenta;
            HorizontalDashedLine.StrokeThickness = 3;
            HorizontalDashedLine.StrokeEndLineCap = PenLineCap.Triangle;
            horizontalDashedLine.StrokeDashArray = new DoubleCollection() { 2 };

            VertivalDashedLine.Stroke = Brushes.DarkMagenta;
            VertivalDashedLine.StrokeThickness = 3;
            VertivalDashedLine.StrokeEndLineCap = PenLineCap.Triangle;
            VertivalDashedLine.StrokeDashArray = new DoubleCollection() { 2 };

            VerticalLine.Stroke = Brushes.Green;
            VerticalLine.StrokeThickness = 2;
            HorizontalDashedLine.StrokeEndLineCap = PenLineCap.Triangle;

            HorizontalLine.Stroke = Brushes.Green;
            HorizontalLine.StrokeThickness = 2;
            HorizontalLine.StrokeEndLineCap = PenLineCap.Triangle;

            VelocityLine.Stroke = Brushes.Black;
            VelocityLine.StrokeThickness = 3;
            VelocityLine.StrokeEndLineCap = PenLineCap.Triangle;
        }

        public void UpdateTrajectory(Point point)
        {
            Trajectory.Points.Add(point);
        }

        public void ClearTrajectory()
        {
            Trajectory.Points.Clear();
        }

        public void ClearLines()
        {
            HorizontalLine.X1 = 0;
            HorizontalLine.Y1 = 0;
            HorizontalLine.X2 = 0;
            HorizontalLine.Y2 = 0;

            VerticalLine.X1 = 0;
            VerticalLine.Y1 = 0;
            VerticalLine.X2 = 0;
            VerticalLine.Y2 = 0;

            HorizontalDashedLine.X1 = 0;
            HorizontalDashedLine.Y1 = 0;
            HorizontalDashedLine.X2 = 0;
            HorizontalDashedLine.Y2 = 0;

            VertivalDashedLine.X1 = 0;
            VertivalDashedLine.Y1 = 0;
            VertivalDashedLine.X2 = 0;
            VertivalDashedLine.Y2 = 0;

            VelocityLine.X1 = 0;
            VelocityLine.Y1 = 0;
            VelocityLine.X2 = 0;
            VelocityLine.Y2 = 0;
        }

        public void UpdateVelocityVectors(double borderHeight, double x, double y, double vx, double vy)
        {
            HorizontalLine.X1 = x + 15;
            HorizontalLine.Y1 = borderHeight - y - vy + 15;
            HorizontalLine.X2 = x + vx + 15;
            HorizontalLine.Y2 = borderHeight - y - vy + 15;

            VerticalLine.X1 = x + 15;
            VerticalLine.Y1 = borderHeight - y + 15;
            VerticalLine.X2 = x + 15;
            VerticalLine.Y2 = borderHeight - y + 15 - vy;

            HorizontalDashedLine.X1 = x + 15;
            HorizontalDashedLine.Y1 = borderHeight - y + 15;
            HorizontalDashedLine.X2 = x + vx + 15;
            HorizontalDashedLine.Y2 = borderHeight - y + 15;

            VertivalDashedLine.X1 = x + vx + 15;
            VertivalDashedLine.Y1 = borderHeight - y + 15;
            VertivalDashedLine.X2 = x + vx + 15;
            VertivalDashedLine.Y2 = borderHeight - y - vy + 15;

            VelocityLine.X1 = x + 15;
            VelocityLine.Y1 = borderHeight - y + 15;
            VelocityLine.X2 = x + vx + 15;
            VelocityLine.Y2 = borderHeight - y - vy + 15;
        }
    }
}
