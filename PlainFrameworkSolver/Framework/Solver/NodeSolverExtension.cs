using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public static class NodeSolverExtension
    {

        public static void CreateMatrixEntries(this Node node, SquareMatrix matrix, double[] solutionVector, int line, FrameworkIndex index)
        {
            foreach (var f in node.Forces.Where(x => x.IsForceKnown))
            {
                var v = f.getVectorToNode(node);
                solutionVector[line] += v.X;
                solutionVector[line + 1] += v.Y;
            }

            foreach (var f in node.Forces.Where(x => !x.IsForceKnown))
            {
                var v = f.getVectorToNode(node);
                matrix[index[f], line] = v.X;
                matrix[index[f], line + 1] = v.Y;
            }
        }
    }
}
