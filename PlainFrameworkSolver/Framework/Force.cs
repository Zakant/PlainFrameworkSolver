using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public abstract class Force : FrameworkElement, IDrawable
    {
        public double Betrag { get; }

        public Vector2 Richtung { get; set; }

        public virtual bool IsForceKnown { get; set; }

        public int Index { get; set; }

        public abstract Vector2 GetForceForNode(Node node);

        protected Vector2 SplitToAxes()
        {
            Richtung.Normalize()
        }
    }
}