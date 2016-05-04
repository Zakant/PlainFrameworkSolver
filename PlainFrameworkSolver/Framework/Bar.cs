using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Bar : Force
    {
        public Node NodeA { get; set; }

        public Node NodeB { get; set; }

        public bool IsZeroBar => ForceValue == 0;

        public override bool IsForceKnown => false;

        public override void Draw(Graphics g, Rectangle boundary)
        {
            throw new NotImplementedException();
        }
    }
}
