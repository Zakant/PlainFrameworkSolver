using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class DependsOnAttribute : Attribute
    {
        public string DependencyName { get; private set; }

        public DependsOnAttribute(string dependencyName)
        {
            DependencyName = dependencyName;
        }
    }
}
