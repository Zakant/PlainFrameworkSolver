using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public interface IDrawable
    {
        void Draw(Graphics g, Rectangle boundary);
    }
}
