using PlainFrameworkSolver.Framework;
using PlainFrameworkSolver.Framework.Events;
using PlainFrameworkSolver.Framework.Extensions;
using PlainFrameworkSolver.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlainFrameworkSolver
{
    public partial class frmMain : Form
    {
        public PlainFramework CurrentFramework { get; set; } = new PlainFramework();

        protected TreeNode nodesNode = new TreeNode("Nodes");
        protected TreeNode barsNode = new TreeNode("Bars");
        protected TreeNode forcesNode = new TreeNode("Forces");

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            canvas.CurrentFramework = CurrentFramework;
            CurrentFramework.FrameworkSelectedChanged += FrameworkSelectedChangedHandler;
            CurrentFramework.FrameworkChanged += FrameworkChangedHanlder;
            CurrentFramework.PropertyChanged += FrameworkPropertyChangedHandler;
            tvFramework.Nodes.Add(nodesNode);
            tvFramework.Nodes.Add(barsNode);
            tvFramework.Nodes.Add(forcesNode);
            canvas.KeyDown += HandleKeyDown;
        }

        public void FrameworkSelectedChangedHandler(object sender, FrameworkSelectedElementChangedEventArgs e)
        {
            this.propertyGrid.SelectedObject = CurrentFramework.Selected;
            tvFramework.SelectedNode = tvFramework.SelectNode<FrameworkTreeNode>(x => x.Element == CurrentFramework.Selected);
        }

        public void FrameworkChangedHanlder(object sender, FrameworkChangedEventArgs e)
        {
            var element = e.Element;
            switch (e.ChangeType)
            {
                case FrameworkChangedType.Added:
                    var treeNode = new FrameworkTreeNode(element);
                    if (element is Bar) barsNode.Nodes.Add(treeNode);
                    else if (element is ExternalForce) forcesNode.Nodes.Add(treeNode);
                    else if (element is Node) nodesNode.Nodes.Add(treeNode);
                    treeNode.EnsureVisible();
                    break;
                case FrameworkChangedType.Removed:
                    tvFramework.SelectNode<FrameworkTreeNode>(x => x.Element == element)?.Remove();
                    break;
            }
        }

        public void FrameworkPropertyChangedHandler(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Element_Name") canvas.Invalidate();
        }

        private void tvFramework_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var entry = e.Node as FrameworkTreeNode;
            if (entry == null) return;
            CurrentFramework.Select(entry.Element);
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                CurrentFramework.RemoveElement(CurrentFramework.Selected);
        }
    }
}
