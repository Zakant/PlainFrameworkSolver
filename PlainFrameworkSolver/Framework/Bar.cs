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

        public override void Draw(Graphics g, Rectangle boundary)
        {
            throw new NotImplementedException();
        }
    }
}
