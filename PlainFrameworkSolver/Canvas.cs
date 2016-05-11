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
        const int GridSize = 20;

        public new event EventHandler<KeyEventArgs> KeyDown;

        private PlainFramework _currentFramework = null;
        public PlainFramework CurrentFramework
        {
            get { return _currentFramework; }
            set
            {
                if (_currentFramework != null)
                {
                    _currentFramework.FrameworkChanged -= HandleFrameworkChanged;
                    _currentFramework.FrameworkSelectedChanged -= HandleFrameworkSelectedChanged;
                }
                _currentFramework = value;
                if (_currentFramework != null)
                {
                    _currentFramework.FrameworkChanged += HandleFrameworkChanged;
                    _currentFramework.FrameworkSelectedChanged += HandleFrameworkSelectedChanged;
                }
            }
        }

        private bool _gridEnabled = true;
        public bool GridEnabled
        {
            get { return _gridEnabled; }
            set { _gridEnabled = value; this.Invalidate(); }
        }

        private bool _creatingBar = false;
        private PointF _mousePos = PointF.Empty;
        private Pen pGrid = new Pen(new SolidBrush(Color.FromArgb(50, 20, 20, 20)), 0.5f);

        public Canvas()
        {
            this.DoubleBuffered = true;
        }

        protected Point2D translatePoint(Point2D p)
        {
            if (!GridEnabled) return p;
            return new Point2D(Math.Round(p.X / GridSize, 0) * GridSize, Math.Round(p.Y / GridSize, 0) * GridSize);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), e.ClipRectangle);
            if (GridEnabled)
            {
                for (int x = 0; x <= this.Width; x += GridSize)
                    e.Graphics.DrawLine(pGrid, x, 0, x, this.Height);
                for (int y = 0; y <= this.Height; y += GridSize)
                    e.Graphics.DrawLine(pGrid, 0, y, this.Width, y);
            }
        }

        static Pen penLine = new Pen(new SolidBrush(Color.Black), 2);
        protected override void OnPaint(PaintEventArgs e)
        {
            CurrentFramework?.Draw(e.Graphics, e.ClipRectangle);
            if (_creatingBar && CurrentFramework?.Selected as Node != null) e.Graphics.DrawLine(penLine, ((Node)CurrentFramework.Selected).Position.ToPointF(), _mousePos);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            var newNode = new Node();
            newNode.Position = translatePoint(new Point2D(e.X, e.Y));
            CurrentFramework?.AddElement(newNode);
            CurrentFramework?.Select(newNode);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            CurrentFramework?.Select(CurrentFramework?.getElementAt(new Point2D(e.X, e.Y)));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var element = CurrentFramework?.getElementAt(e.Location) as Node;
            if (element != null && element != CurrentFramework?.Selected && CurrentFramework?.Selected is Node)
                CurrentFramework.AddElement(new Bar((Node)CurrentFramework.Selected, element));
            _creatingBar = false;
            this.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || CurrentFramework?.Selected == null) return;
            if (Control.ModifierKeys.HasFlag(Keys.Shift))
            {
                var node = CurrentFramework?.Selected as Node;
                if (node == null) return;
                node.Position = translatePoint(e.Location);
            }
            else
            {
                _creatingBar = true;
                _mousePos = e.Location;
            }
            this.Invalidate();
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            KeyDown?.Invoke(this, e);
            base.OnKeyDown(e);
        }

        protected void HandleFrameworkChanged(object sender, FrameworkChangedEventArgs e)
        {
            this.Invalidate();
        }
        protected void HandleFrameworkSelectedChanged(object sender, FrameworkSelectedElementChangedEventArgs e)
        {
            this.Invalidate();
        }


    }
}
