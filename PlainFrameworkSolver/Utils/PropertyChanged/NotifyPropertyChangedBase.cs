using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ComponentModel
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            if (isPropertyChangedEnabled)
            {
                var myevent = PropertyChanged;
                if (myevent != null)
                    myevent(this, new PropertyChangedEventArgs(name));
            }
            else
            {
                _buffer.Add(name);
            }
            HandleDependencies(name);

        }

        protected void StartInThread(ThreadStart threadStart)
        {
            new Thread(threadStart) { IsBackground = true }.Start();
        }

        private HashSet<string> _buffer = new HashSet<string>();

        private bool _isPropertyChangedEnabled = true;
        public bool isPropertyChangedEnabled
        {
            get { return _isPropertyChangedEnabled; }
            set
            {
                bool old = _isPropertyChangedEnabled;
                _isPropertyChangedEnabled = value;
                if (value && !old)
                {
                    foreach (var s in _buffer)
                        RaisePropertyChanged(s);
                    _buffer.Clear();
                }
            }
        }

        private Dictionary<string, List<string>> _dependencies = new Dictionary<string, List<string>>();

        protected void RegisterDependendChange(string baseProperty, params string[] dependendProperties)
        {
            if (!_dependencies.ContainsKey(baseProperty))
                _dependencies.Add(baseProperty, new List<string>());
            foreach (var s in dependendProperties)
                _dependencies[baseProperty].Add(s);
        }

        private void HandleDependencies(string PropertyName)
        {
            if (_dependencies.ContainsKey(PropertyName))
            {
                foreach (var s in _dependencies[PropertyName])
                    StartInThread(() => RaisePropertyChanged(s));
            }
        }

        public NotifyPropertyChangedBase()
        {
            foreach (var prop in this.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
            {
                if (Attribute.IsDefined(prop, typeof(DependsOnAttribute)))
                {
                    var dependencies = Attribute.GetCustomAttributes(prop, typeof(DependsOnAttribute)).Select(x => ((DependsOnAttribute)x).DependencyName);
                    foreach (var dep in dependencies)
                        RegisterDependendChange(dep, prop.Name);
                }
            }
        }

    }
}
