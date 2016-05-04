using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlainFrameworkSolver.Framework
{
    public abstract class Force : FrameworkElement, IDrawable
    {
        public double ForceValue { get; }

        public Vector2 Direction { get; set; }

        public abstract bool IsForceKnown { get; }

        public int Index { get; set; }

        public virtual Vector2 GetForceForNode(Node node) => Vector2.Zero;

        public abstract void Draw(Graphics g, Rectangle boundary);
    }
}
