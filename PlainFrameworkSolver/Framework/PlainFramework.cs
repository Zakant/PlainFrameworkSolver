using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public class PlainFramework : IDrawable
    {
        public ObservableCollection<Bar> Bars { get; protected set; } = new ObservableCollection<Bar>();

        public ObservableCollection<ExternalForce> ExternalForces { get; protected set; } = new ObservableCollection<ExternalForce>();

        public ObservableCollection<Node> Nodes { get; protected set; } = new ObservableCollection<Node>();

        public FrameworkElement Selected { get; protected set; }

        public void Draw(Graphics g, Rectangle boundary)
        {
            foreach (var x in Nodes) x.Draw(g, boundary);
            foreach (var x in Bars) x.Draw(g, boundary);
            foreach (var x in ExternalForces) x.Draw(g, boundary);
        }

        public void Select(FrameworkElement element)
        {
            if (Selected != null) Selected.IsSelected = false;
            Selected = element;
            if (Selected != null) Selected.IsSelected = true;
        }
    }
}


