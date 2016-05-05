using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Events
{
    public class FrameworkChangedEventArgs : EventArgs
    {
        public FrameworkChangedType ChangeType { get; protected set; }

        public FrameworkElement Element { get; protected set; }

        public FrameworkChangedEventArgs(FrameworkChangedType type, FrameworkElement element)
        {
            ChangeType = type;
            Element = element;
        }
    }
}
