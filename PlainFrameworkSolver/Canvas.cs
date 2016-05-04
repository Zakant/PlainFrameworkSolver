using Artentus.Utils.Math;
using PlainFrameworkSolver.Framework;
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
        public PlainFramework CurrentFramework { get; set; }

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

        protected Point2D _startPoint = Point2D.Zero;
        protected Point2D _tempPoint = Point2D.Zero;
        protected Point2D _endPoint = Point2D.Zero;
        protected bool _isCreating = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (CurrentFramework != null)
            {
                _isCreating = true;
                _startPoint = new Point2D(e.X, e.Y);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(_isCreating)
            {

            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_isCreating)
            {
                _endPoint = new Point2D(e.X, e.Y);

                _isCreating = false;
                _startPoint = Point2D.Zero;
                _endPoint = Point2D.Zero;
                _tempPoint = Point2D.Zero;
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            System.Diagnostics.Debug.Print("Mouse leave!");
            base.OnMouseLeave(e);
        }
    }
}
