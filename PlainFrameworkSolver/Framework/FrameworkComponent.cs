using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public abstract class FrameworkComponent
    {
        public string Identifier { get; set; }

        public PlainFramework ParentFramework { get; set; }
    }
}
