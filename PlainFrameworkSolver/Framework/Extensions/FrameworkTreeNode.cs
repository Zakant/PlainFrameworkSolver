using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainFrameworkSolver.Framework.Extensions
{
    [Serializable]
    public class FrameworkTreeNode : TreeNode
    {
        public FrameworkElement Element { get; protected set; }


        public FrameworkTreeNode(FrameworkElement element)
        {
            Element = element;
            element.PropertyChanged += HandlePropertyChanged;
            Text = element.Name;
        }

        protected FrameworkTreeNode(SerializationInfo info, StreamingContext context) : base(info, context) { }


        protected void HandlePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Name")
            {
                Text = Element.Name;
                this.TreeView.Invalidate();
            }
        }
    }
}
