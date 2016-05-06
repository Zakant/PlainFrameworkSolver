using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    public abstract class FrameworkElement : NotifyPropertyChangedBase, IDrawable
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }

        private bool _isSelected;
        [Browsable(false)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; RaisePropertyChanged(); }
        }

        public abstract void Draw(Graphics g, Rectangle boundary);

        protected static Pen penBlack = new Pen(new SolidBrush(Color.Black));
        protected static Pen penRed = new Pen(new SolidBrush(Color.Red));
        protected static Font font = new Font(FontFamily.GenericSansSerif, 9);

    }
}
