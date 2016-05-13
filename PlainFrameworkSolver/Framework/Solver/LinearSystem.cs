using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public class LinearSystem
    {
        public SquareMatrix Matrix { get; protected set; }

        public double[] SolutionVector { get; protected set; }

        public LinearSystem(SquareMatrix matrix, double[] solutionVector)
        {
            Matrix = matrix;
            SolutionVector = solutionVector;
        }

        public double[] Solve()
        {
            return SquareMatrix.SolveLinearSystem(Matrix, SolutionVector);
        }
    }
}
