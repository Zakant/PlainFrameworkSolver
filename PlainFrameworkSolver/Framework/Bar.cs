using PlainFrameworkSolver.Utils.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Artentus.Utils.Math;

namespace PlainFrameworkSolver.Framework
{
    public class Bar : Force
    {
        private Node _nodeA;
        [Editor(typeof(NodeEditor), typeof(UITypeEditor))]
        public Node NodeA
        {
            get { return _nodeA; }
            set { _nodeA = value; RaisePropertyChanged(); }
        }

        private Node _nodeB;
        [Editor(typeof(NodeEditor), typeof(UITypeEditor))]
        public Node NodeB
        {
            get { return _nodeB; }
            set { _nodeB = value; RaisePropertyChanged(); }
        }


        [DependsOn("ForceValue")]
        public bool IsZeroBar => ForceValue == 0;

        public override bool IsForceKnown => false;

        [DependsOn("NodeA"), DependsOn("NodeB")]
        public override Vector2 Direction
        {
            get { return NodeB.Position - NodeA.Position; }
            set { throw new NotSupportedException("Setting direction is not supported!"); }
        }

        public Bar(Node nodeA, Node nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
        }

        public override void Draw(Graphics g, Rectangle boundary)
        {
            g.DrawLine(IsSelected ? penRed : penBlack, NodeA.Position.ToPointF(), NodeB.Position.ToPointF());

            g.DrawString(Name, font, bBlack, (NodeA.Position + Direction * 0.5).ToPointF());
        }
    }
}
