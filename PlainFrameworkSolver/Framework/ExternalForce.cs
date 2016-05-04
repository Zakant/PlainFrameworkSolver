using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class ExternalForce : Force
    {
        public Node Target { get; set; }

        public override bool IsForceKnown => Betrag != 0;

        public override Vector2 GetForceForNode(Node node)
        {
            if(node != Target) return Vector2.Zero;
            return Richtung.Normalize() * Betrag;
        }

        public override void Draw(Graphics g, Rectangle boundary)
        {
            throw new NotImplementedException();
        }
    }
}
