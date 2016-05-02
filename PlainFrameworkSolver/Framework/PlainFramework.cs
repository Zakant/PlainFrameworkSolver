using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public class PlainFramework
    {
        public ObservableCollection<Node> Nodes { get; protected set; } = new ObservableCollection<Node>();

        public ObservableCollection<Bar> Bars { get; protected set; } = new ObservableCollection<Bar>();

        public ObservableCollection<Force> Forces { get; protected set; } = new ObservableCollection<Force>();

        public IEnumerable<Bar> getBars(Node node)
        {
            return Bars.Where(x => x.NodeA == node || x.NodeB == node);
        }
        public IEnumerable<Force> getForces(Node node)
        {
            return Forces.Where(x => x.Node == node);
        }
    }
}
