using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwing
{
    public class PhysicsEngine
    {
        #region Fields
        double[] xx;
        double time;
        double dt;
        double ballMass;
        double gravity;
        double dragCoefficient;
        double airDensity;
        double ballArea;
        ODESolverRK4.Function[] F;
        #endregion

        #region Getter/Setter
        public double Time { get => time; set => time = value; }
        public double Dt { get => dt; set => dt = value; }
        public double BallMass { get => ballMass; set => ballMass = value; }
        public double Gravity { get => gravity; set => gravity = value; }
        public double DragCoefficient { get => dragCoefficient; set => dragCoefficient = value; }
        public double AirDensity { get => airDensity; set => airDensity = value; }
        public double BallArea { get => ballArea; set => ballArea = value; }
        #endregion

        public PhysicsEngine(double x0, double y0, double v0x, double v0y, double dt, double ballMass, double gravity, double dragCoefficient, double airDensity, double ballArea)
        {
            xx = new double[4] { x0, y0, v0x, v0y };
            Time = 0;
            Dt = dt;
            F = new ODESolverRK4.Function[4] { CalculatePositionX, CalculatePositionY, CalculateDragForce, CalculateGravityForce };
            BallMass = ballMass;
            Gravity = gravity;
            DragCoefficient = dragCoefficient;
            AirDensity = airDensity;
            BallArea = ballArea;
        }

        private double CalculatePositionX(double[] xx, double t)
        {
            return xx[2];
        }

        private double CalculatePositionY(double[] xx, double t)
        {
            return xx[3];
        }

        private double CalculateDragForce(double[] xx, double t)
        {
            double A = BallArea;
            double rho = AirDensity;
            double cd = DragCoefficient;
            double m = 1 / BallMass;
            double fd = 0.5 * rho * A * cd * ((xx[2] * xx[2]) + (xx[3] * xx[3]));
            return -fd * xx[2] / m / Math.Sqrt((xx[2] * xx[2]) + (xx[3] * xx[3]));
        }

        private double CalculateGravityForce(double[] xx, double t)
        {
            double A = BallArea;
            double rho = AirDensity;        
            double cd = DragCoefficient;    
            double m = 1 / BallMass;        
            double fd = 0.5 * rho * A * cd * ((xx[2] * xx[2]) + (xx[3] * xx[3]));
            return -Gravity - (fd * xx[3] / m / Math.Sqrt((xx[2] * xx[2]) + (xx[3] * xx[3])));
        }

        public double[] UpdateState()
        {
            double[] result = ODESolverRK4.RungeKutta4(F, xx, Time, Dt);
            xx = result;
            Time += Dt;
            return result;
        }

        public void ResetState(double borderHeight)
        {
            xx[0] = 100;
            xx[1] = borderHeight / 2;
            xx[2] = 50;
            xx[3] = 70;
        }
    }
}
