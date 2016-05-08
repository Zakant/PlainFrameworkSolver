using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public class FrameworkSolver
    {
        public PlainFramework Framework { get; protected set; }

        public FrameworkSolver(PlainFramework framework)
        {
            Framework = framework;
        }

        public SquareMatrix CreateMatrix()
        {
        }

        public Dictionary<string, Rational> Solve()
        {
            throw new NotImplementedException();
        }
    }
}
