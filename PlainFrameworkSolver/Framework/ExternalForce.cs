using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class ExternalForce : Force
    {
        private Node _target;
        public Node Target
        {
            get { return _target; }
            set { _target = value; RaisePropertyChanged(); }
        }

        [DependsOn("ForceValue")]
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
