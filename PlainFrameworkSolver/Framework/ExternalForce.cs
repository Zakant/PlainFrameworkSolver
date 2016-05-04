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

        public override bool IsForceKnown => ForceValue != 0;

        public override Vector2 GetForceForNode(Node node)
        {
            if(node != Target) return Vector2.Zero;
            return Direction.Normalize() * ForceValue;
        }

        public override void Draw(Graphics g, Rectangle boundary)
        {
            throw new NotImplementedException();
        }
    }
}
