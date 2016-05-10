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

        public FrameworkIndex Index { get; protected set; }


        public FrameworkSolver(PlainFramework framework)
        {
            Framework = framework;
        }

        public void UpdateIndex()
        {
            var forces = Framework.Bars.Cast<Force>().Concat(Framework.ExternalForces.Cast<Force>()).Where(x => !x.IsForceKnown).ToList();
            Index = new FrameworkIndex(forces);
        }

        public SquareMatrix CreateMatrix()
        {
            UpdateIndex();
            var matrix = new SquareMatrix(Framework.Nodes.Count * 2 + 1);
            for (int i = 0; i < Framework.Nodes.Count; i++)
                Framework.Nodes[i].CreateMatrixEntries(i * 2, Index);
            return matrix;
        }

        public Dictionary<string, Rational> Solve()
        {
            throw new NotImplementedException();
        }
    }
}
