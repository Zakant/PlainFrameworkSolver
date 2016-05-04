using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class InternalForce : Force
    {
        public override bool IsForceKnown => Betrag != 0;
        
        public override void Draw(Graphics g, Rectangle boundary)
        {
            throw new NotImplementedException();
        }
    }
}