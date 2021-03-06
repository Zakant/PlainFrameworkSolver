﻿using Artentus.Utils.Math;
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
    [Serializable]
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

        public override string ToString()
        {
            return $"{Name} (External Force)";
        }

        protected static Brush bBlue = new SolidBrush(Color.Blue);
        protected static Pen penBlue = new Pen(bBlue);
        public override void Draw(Graphics g, Rectangle boundary)
        {
            var invertDirection = new Vector2(Direction.X, -Direction.Y);

            var start = Target.Position - invertDirection * 25;
            var end = Target.Position - (invertDirection * Node.RADIUS);
            var orthogonal = invertDirection.CrossProduct.Normalize();
            var arrow1 = Target.Position - invertDirection * 10 - orthogonal * 5;
            var arrow2 = Target.Position - invertDirection * 10 + orthogonal * 5;
            var pen = IsSelected ? penRed : penBlue;


            g.DrawLine(pen, start.ToPointF(), end.ToPointF());
            g.DrawLine(pen, end.ToPointF(), arrow1.ToPointF());
            g.DrawLine(pen, end.ToPointF(), arrow2.ToPointF());

            g.DrawString(Name, font, bBlue, start.ToPointF());
        }
    }
}
