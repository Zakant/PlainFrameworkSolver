using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public class Node : FrameworkElement
    {
        const float RADIUS = 2;

        public Point2D Position { get; set; }

        public List<Force> Forces { get; protected set; } = new List<Force>();

        public void Attach(Force f)
        {
            if (!Forces.Contains(f))
                Forces.Add(f);
        }

        public void Detach(Force f)
        {
            Forces.Remove(f);
        }

        static Pen penBlack = new Pen(new SolidBrush(Color.Black));
        static Pen penRed = new Pen(new SolidBrush(Color.Red));
        public override void Draw(Graphics g, Rectangle boundary)
        {
            g.DrawEllipse(IsSelected ? penRed : penBlack,(float)( Position.X - RADIUS), (float)(Position.Y - RADIUS), RADIUS * 2, RADIUS * 2);
        }
    }
}
