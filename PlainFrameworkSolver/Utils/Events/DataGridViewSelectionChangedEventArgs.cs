using PlainFrameworkSolver.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Utils.Events
{
    public class DataGridViewSelectionChangedEventArgs : EventArgs
    {
        public Force Force { get; protected set; }

        public DataGridViewSelectionChangedEventArgs(Force force)
        {
            Force = force;
        }
    }
}
