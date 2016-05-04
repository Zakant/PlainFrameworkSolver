using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public abstract class FrameworkElement : IDrawable
    {
        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public abstract void Draw(Graphics g, Rectangle boundary);
    }
}
