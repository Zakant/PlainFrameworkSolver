using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework.Solver
{
    public class FrameworkIndex
    {
        protected Dictionary<Force, int> _elementToInt = new Dictionary<Force, int>();
        protected Dictionary<int, Force> _IntToElement = new Dictionary<int, Force>();

        public Force this[int index] => _IntToElement[index];
        public int this[Force force] => _elementToInt[force];

        public int Count => _elementToInt.Count;

        public FrameworkIndex(IList<Force> forces)
        {
            for (int i = 0; i < forces.Count; i++)
            {
                _elementToInt.Add(forces[i], i);
                _IntToElement.Add(i, forces[i]);
            }
        }
    }
}
