using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class ExternalForce : Force
    {
        public Node Target { get; set; }

        public override bool IsForceKnown => Betrag == 0;
        
    }
}