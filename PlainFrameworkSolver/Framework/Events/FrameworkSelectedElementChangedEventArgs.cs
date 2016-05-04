using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Events
{
    public class FrameworkSelectedElementChangedEventArgs : EventArgs
    {
        public FrameworkElement NewSelected { get; protected set; }

        public FrameworkSelectedElementChangedEventArgs(FrameworkElement element)
        {
            NewSelected = element;
        }
    }
}
