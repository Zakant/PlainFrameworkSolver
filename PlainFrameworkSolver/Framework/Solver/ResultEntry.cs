using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public class ResultEntry
    {
        public Force Force { get; protected set; }

        public double Value { get; protected set; }

        public ResultEntry(Force force, double value)
        {
            Force = force;
            Value = value;
        }
    }
}
