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

        private Point2D _position;
        public Point2D Position
        {
            get { return _position; }
            set
            {
                _position.PropertyChanged -= HandlePositionChanged;
                _position = value;
                _position.PropertyChanged += HandlePositionChanged;
                RaisePropertyChanged();
            }
        }

        public List<Force> Forces { get; protected set; } = new List<Force>();

        public Node()
        {
            _position = Point2D.Zero;
        }

        public void Attach(Force f)
        {
            if (!Forces.Contains(f))
                Forces.Add(f);
            RaisePropertyChanged("Forces");
        }

        public void Detach(Force f)
        {
            Forces.Remove(f);
            RaisePropertyChanged("Forces");
        }

        public override void Draw(Graphics g, Rectangle boundary)
        {
            g.DrawEllipse(IsSelected ? penRed : penBlack, (float)(Position.X - RADIUS), (float)(Position.Y - RADIUS), RADIUS * 2, RADIUS * 2);
            g.DrawString(Name, font, bBlack, (float)Position.X + RADIUS + 2, (float)Position.Y);
        }

        protected void HandlePositionChanged(object sender, EventArgs args) => RaisePropertyChanged("Position");
    }
}
