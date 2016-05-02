using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public class Force
    {
        public Node Node { get; set; }

        public Vector2 Value { get; set; }

        public bool IsUnknown { get { return this.Value == Vector2.Zero; } }
    }
}
