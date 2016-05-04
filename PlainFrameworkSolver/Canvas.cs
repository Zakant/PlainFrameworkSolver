using Artentus.Utils.Math;
using PlainFrameworkSolver.Framework;
using PlainFrameworkSolver.Framework.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainFrameworkSolver
{
    public class Canvas : Panel
    {
        private PlainFramework _currentFramework = null;
        public PlainFramework CurrentFramework
        {
            get { return _currentFramework; }
            set
            {
                if(_currentFramework != null)
                {
                    _currentFramework.FrameworkChanged -= HandleFrameworkChanged;
                    _currentFramework.FrameworkSelectedChanged -= HandleFrameworkSelectedChanged;
                }
                _currentFramework = value;
                if(_currentFramework != null)
                {
                    _currentFramework.FrameworkChanged += HandleFrameworkChanged;
                    _currentFramework.FrameworkSelectedChanged += HandleFrameworkSelectedChanged;
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), e.ClipRectangle);
        }

        static Pen penLine = new Pen(new SolidBrush(Color.Black), 2);
        static Pen penHighlight = new Pen(new SolidBrush(Color.Red), 5);
        protected override void OnPaint(PaintEventArgs e)
        {
            CurrentFramework?.Draw(e.Graphics, e.ClipRectangle);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            var newNode = new Node();
            newNode.Position = new Point2D(e.X, e.Y);
            CurrentFramework?.AddElement(newNode);
            CurrentFramework?.Select(newNode);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            CurrentFramework?.Select(CurrentFramework?.getElementAt(new Point2D(e.X, e.Y)));
        }

        protected void HandleFrameworkChanged(object sender, FrameworkChangedEventArgs e)
        {

        }
        protected void HandleFrameworkSelectedChanged(object sender, FrameworkSelectedElementChangedEventArgs e)
        {

        }
    }
}
