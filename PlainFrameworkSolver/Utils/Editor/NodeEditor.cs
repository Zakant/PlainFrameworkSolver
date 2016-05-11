using PlainFrameworkSolver.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PlainFrameworkSolver.Utils.Editor
{
    public class NodeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            var bar = (Bar)context.Instance;
            var framework = bar.HostFramework;
            
            ListBox lb = new ListBox() { SelectionMode = SelectionMode.One };
            lb.SelectedValueChanged += (s, e) => _editorService.CloseDropDown();
            lb.DisplayMember = "Name";

            var editNode = context.PropertyDescriptor.GetValue(bar);
            var otherNode = bar.NodeA == editNode ? bar.NodeB : bar.NodeA;

            foreach (var x in framework.Nodes.Where(x => x != otherNode))
                lb.Items.Add(x);
            lb.SelectedItem = editNode;

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null)
                return value;
            return lb.SelectedItem;
        }
    }
}
