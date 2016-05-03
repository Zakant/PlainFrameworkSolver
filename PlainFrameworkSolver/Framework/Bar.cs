using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public class Bar : FrameworkComponent
    {
        public Node NodeA { get; set; }

        public Node NodeB { get; set; }

        public Vector2 Vector { get { return NodeA.Point-NodeB.Point} }
   
    }
}
