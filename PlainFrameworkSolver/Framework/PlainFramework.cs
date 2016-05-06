using Artentus.Utils.Math;
using PlainFrameworkSolver.Framework.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlainFrameworkSolver.Framework
{
    public class PlainFramework : IDrawable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<FrameworkChangedEventArgs> FrameworkChanged;

        public event EventHandler<FrameworkSelectedElementChangedEventArgs> FrameworkSelectedChanged;

        public ObservableCollection<Bar> Bars { get; protected set; } = new ObservableCollection<Bar>();

        public ObservableCollection<ExternalForce> ExternalForces { get; protected set; } = new ObservableCollection<ExternalForce>();

        public ObservableCollection<Node> Nodes { get; protected set; } = new ObservableCollection<Node>();

        private FrameworkElement _selected = null;
        public FrameworkElement Selected { get { return _selected; } protected set { _selected = value; RaisePropertyChanged(); } }

        private int _nodeCounter = 0;
        private int _barCounter = 0;

        public void Draw(Graphics g, Rectangle boundary)
        {
            foreach (var e in getAll()) e.Draw(g, boundary);
        }

        public void Select(FrameworkElement element)
        {
            if (Selected != null) Selected.IsSelected = false;
            Selected = element;
            if (Selected != null) Selected.IsSelected = true;
            RaiseSelectedChange(Selected);
        }

        public void RemoveElement(FrameworkElement element)
        {
            if (element is Bar)
            {
                var b = (Bar)element;
                b.NodeA?.Detach(b);
                b.NodeB?.Detach(b);
                Bars.Remove(b);
            }
            else if (element is Node)
            {
                var n = (Node)element;
                foreach (var f in n.Forces.ToList())
                    RemoveElement(f);
                Nodes.Remove(n);
            }
            else if (element is ExternalForce)
            {
                var e = (ExternalForce)element;
                e.Target.Detach(e);
                ExternalForces.Remove(e);
            }
            element.PropertyChanged -= HandleElementPropertyChanged;
            RaiseFrameworkChanged(FrameworkChangedType.Removed, element);
        }

        public void AddElement(FrameworkElement element)
        {
            if (element is Bar)
            {
                if (String.IsNullOrWhiteSpace(element.Name)) element.Name = $"Bar {_barCounter++}";
                var b = (Bar)element;
                b.NodeA?.Attach(b);
                b.NodeB?.Attach(b);
                Bars.Add(b);
            }
            else if (element is Node)
            {
                if (String.IsNullOrWhiteSpace(element.Name)) element.Name = $"Node {_nodeCounter++}";
                Nodes.Add((Node)element);
            }
            else if (element is ExternalForce)
            {
                var f = (ExternalForce)element;
                f.Target?.Attach(f);
                ExternalForces.Add(f);
            }
            element.PropertyChanged += HandleElementPropertyChanged;
            RaiseFrameworkChanged(FrameworkChangedType.Added, element);
        }

        public FrameworkElement getElementAt(Point2D point)
        {
            var nearNodes = Nodes.Where(x => point.IsNear(x.Position, 10));
            var nearBars = Bars.Where(x => (x.NodeA.Position - x.NodeB.Position).GetDistance(point) <= 10);
            return nearNodes.Cast<FrameworkElement>().Concat(nearBars.Cast<FrameworkElement>()).FirstOrDefault(); // Nicht schön aber selten....
        }

        protected IEnumerable<FrameworkElement> getAll()
        {
            return Nodes.Cast<FrameworkElement>().Concat(Bars.Cast<FrameworkElement>()).Concat(ExternalForces.Cast<FrameworkElement>());
        }


        protected void HandleElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Name") RaisePropertyChanged("Element_Name", sender);
        }

        protected void RaisePropertyChanged([CallerMemberName]string name = "", object sender = null)
        {
            PropertyChanged?.Invoke(sender ?? this, new PropertyChangedEventArgs(name));
        }
        protected void RaiseFrameworkChanged(FrameworkChangedType type, FrameworkElement element)
        {
            FrameworkChanged?.Invoke(this, new FrameworkChangedEventArgs(type, element));
        }
        protected void RaiseSelectedChange(FrameworkElement element)
        {
            FrameworkSelectedChanged?.Invoke(this, new FrameworkSelectedElementChangedEventArgs(element));
        }
    }
}


