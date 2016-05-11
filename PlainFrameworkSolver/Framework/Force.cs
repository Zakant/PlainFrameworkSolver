using Artentus.Utils.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace PlainFrameworkSolver.Framework
{
    public abstract class Force : FrameworkElement
    {
        private double _forceValue;
        public double ForceValue
        {
            get { return _forceValue; }
            set { _forceValue = value; RaisePropertyChanged(); }
        }

        private Vector2 _direction;
        public virtual Vector2 Direction
        {
            get { return _direction; }
            set { _direction = value; RaisePropertyChanged(); }
        }

        public abstract bool IsForceKnown { get; }
    }
}
