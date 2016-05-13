using Artentus.Utils.Math;
using PlainFrameworkSolver.Utils.Editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class ExternalForce : Force
    {
        private Node _target;
        [Editor(typeof(ForceNodeEditor), typeof(UITypeEditor))]
        public Node Target
        {
            get { return _target; }
            set { _target = value; RaisePropertyChanged(); }
        }

        [DependsOn("ForceValue")]
        public override bool IsForceKnown => ForceValue != 0;

        public override void Draw(Graphics g, Rectangle boundary)
        {
            // throw new NotImplementedException();
        }
    }
}
