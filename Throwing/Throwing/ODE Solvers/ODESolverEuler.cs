using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwing
{
    public class ODESolverEuler
    {
        public delegate double Function(double[] x, double t);

        /*
            x:          Aktuális állapot
            dt:         Időlépés 
            f(x, t):    Ez a függvény határozza meg az állapot változását
            t:          Aktuális idő

            Új állapot kiszámítása:     x = x + dt * f(x, t)
            Idő frissítése:             t = t + dt
         */

        public static double[] EulerMethod(Function[] f, double[] x0, double t0, double dt)
        {
            int n = x0.Length;
            double[] x = x0;
            double t = t0;

            for (int i = 0; i < n; i++)
            {
                x[i] += dt * f[i](x, t);
            }

            // t += dt;

            return x;
        }
    }
}
