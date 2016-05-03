using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Node : FrameworkElement, IDrawable
    {
        public Point2D Position { get; protected set; }

        public void Attach(Force f)
        {
            throw new System.NotImplementedException();
        }

        public void Detach(Force f)
        {
            throw new System.NotImplementedException();
        }
    }
}