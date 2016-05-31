using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlainFrameworkSolver.Framework
{
    [Serializable]
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

        [Browsable(false)]
        public PlainFramework HostFramework { get; set; }

        public abstract void Draw(Graphics g, Rectangle boundary);

        protected static Brush bBlack = new SolidBrush(Color.Black);
        protected static Brush bRed = new SolidBrush(Color.Red);
        protected static Pen penBlack = new Pen(bBlack);
        protected static Pen penRed = new Pen(bRed);
        protected static Font font = new Font(FontFamily.GenericSansSerif, 9);


    }
}
