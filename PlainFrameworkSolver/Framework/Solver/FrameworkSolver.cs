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

        public LinearSystem CreateMatrix()
        {
            UpdateIndex();
            int entryCount = Framework.Nodes.Count * 2;
            var matrix = new SquareMatrix(entryCount);
            var solutionVector = new double[entryCount];
            for (int i = 0; i < Framework.Nodes.Count; i++)
                Framework.Nodes[i].CreateMatrixEntries(matrix, solutionVector, i * 2, Index);
            return new LinearSystem(matrix, solutionVector);
        }

        public Dictionary<Force, double> Solve()
        {
            var system = CreateMatrix();
            var dic = new Dictionary<Force, double>();
            var solution = system.Solve();
            for (int i = 0; i < solution.Length; i++)
                dic.Add(Index[i], solution[i]);
            return dic;
        }
    }
}
