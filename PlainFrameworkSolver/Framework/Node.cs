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

        public List<Force> Forces {get; protected set;} = new List<Force>();

        public void Attach(Force f)
        {
            if(!Forces.Contains(f))
              Forces.Add(f);
        }

        public void Detach(Force f)
        {
            Forces.Remove(f);
        }
    }
}
