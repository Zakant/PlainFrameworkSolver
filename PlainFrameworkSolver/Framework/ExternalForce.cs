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
        // [Editor(typeof(ForceNodeEditor), typeof(UITypeEditor))]
        public Node Target
        {
            get { return _target; }
            set { _target = value; RaisePropertyChanged(); }
        }

        [DependsOn("ForceValue")]
        public override bool IsForceKnown => ForceValue != 0;

        protected static Pen penBlue = new Pen(new SolidBrush(Color.Blue));
        public override void Draw(Graphics g, Rectangle boundary)
        {
            var start = Target.Position - Direction * 25;
            var end = Target.Position - (Direction * Node.RADIUS);
            var orthogonal = Direction.CrossProduct.Normalize();
            var arrow1 = Target.Position - Direction * 10 - orthogonal * 5;
            var arrow2 = Target.Position - Direction * 10 + orthogonal * 5;
            var pen = IsSelected ? penRed : penBlue;


            g.DrawLine(pen, start.ToPointF(), end.ToPointF());
            g.DrawLine(pen, end.ToPointF(), arrow1.ToPointF());
            g.DrawLine(pen, end.ToPointF(), arrow2.ToPointF());
        }
    }
}
