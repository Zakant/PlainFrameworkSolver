using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Bar : Force
    {
        public Node NodeA { get; set; }

        public Node NodeB { get; set; }

        public bool IsZeroBar => Betrag == 0;

        public override bool IsForceKnown => false;
    }
}
