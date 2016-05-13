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
    public class ForceNodeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            var force = (ExternalForce)context.Instance;
            var framework = force.HostFramework;

            ListBox lb = new ListBox() { SelectionMode = SelectionMode.One };
            lb.SelectedValueChanged += (s, e) => _editorService.CloseDropDown();
            lb.DisplayMember = "Name";

            foreach (var x in framework.Nodes)
                lb.Items.Add(x);
            lb.SelectedItem = force.Target;

            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null)
                return value;
            return lb.SelectedItem;
        }
    }
}
