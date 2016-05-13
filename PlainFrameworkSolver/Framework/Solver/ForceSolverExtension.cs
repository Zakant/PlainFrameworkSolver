using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public static class ForceSolverExtension
    {
        public static Vector2 getVectorToNode(this Force f, Node n)
        {
            if (f is ExternalForce && ((ExternalForce)f).Target == n)
            {
                var ef = (ExternalForce)f;
                return ef.Direction.Normalize() * (ef.ForceValue == 0 ? 1 : ef.ForceValue);
            }
            if (f is Bar)
            {
                var bar = (Bar)f;
                if (bar.NodeA == n || bar.NodeB == n)
                    return bar.Direction.Normalize() * (bar.NodeA == n ? -1 : 1);
            }
            return Vector2.Zero;
        }
    }
}
