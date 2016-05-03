using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Force : FrameworkElement, IDrawable
    {
        public double Betrag { get; set; }

        public Vector2 Richtung { get; set; }

        public virtual bool IsForceKnown { get; set; }

        public int Index { get; set; }

        public Vector2 GetForceForNode()
        {
            throw new System.NotImplementedException();
        }
    }
}