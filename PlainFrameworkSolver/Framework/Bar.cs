using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Bar : Force
    {
        private Node _nodeA;
        public Node NodeA
        {
            get { return _nodeA; }
            set { _nodeA = value; RaisePropertyChanged(); }
        }

        private Node _nodeB;
        public Node NodeB
        {
            get { return _nodeB; }
            set { _nodeB = value; RaisePropertyChanged(); }
        }

        [DependsOn("ForceValue")]
        public bool IsZeroBar => ForceValue == 0;

        public override bool IsForceKnown => false;

        public Bar(Node nodeA, Node nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
            Direction = NodeA.Position - NodeB.Position;
        }

        public override void Draw(Graphics g, Rectangle boundary)
        {
            g.DrawLine(IsSelected ? penRed : penBlack, NodeA.Position.ToPointF(), NodeB.Position.ToPointF());
        }
    }
}
