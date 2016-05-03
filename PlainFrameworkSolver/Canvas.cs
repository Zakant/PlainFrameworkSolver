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
        // public PlainFramework CurrentFramework { get; set; }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.White), e.ClipRectangle);
        }

        static Pen penLine = new Pen(new SolidBrush(Color.Black), 2);
        static Pen penHighlight = new Pen(new SolidBrush(Color.Red), 5);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
