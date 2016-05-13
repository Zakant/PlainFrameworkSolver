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
            int entryCount = Framework.Nodes.Count * 2;
            var matrix = new SquareMatrix(entryCount);
            var solutionVector = new double[entryCount];
            for (int i = 0; i < Framework.Nodes.Count; i++)
                Framework.Nodes[i].CreateMatrixEntries(matrix, solutionVector, i * 2, Index);
            return matrix;
        }

        public Dictionary<string, Rational> Solve()
        {
            throw new NotImplementedException();
        }
    }
}
