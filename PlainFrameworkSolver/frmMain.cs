using Artentus.Utils.Math;
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

        protected frmSolveResult _resutlForm = null;

        public frmMain()
        {
            InitializeComponent();
            canvas.Select();
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
            _resutlForm?.SelectFrameworkElement(CurrentFramework.Selected);
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
            canvas.Invalidate();
            _resutlForm?.UpdateDataGridView();
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
                if (CurrentFramework?.Selected != null)
                    CurrentFramework?.RemoveElement(CurrentFramework.Selected);
        }

        private void gridToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            canvas.GridEnabled = gridToolStripMenuItem.CheckState == CheckState.Checked;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var forceDialog = new frmCreateForce() { CurrentFramework = CurrentFramework };
            if (forceDialog.ShowDialog() == DialogResult.OK)
                CurrentFramework.AddElement(forceDialog.ResultForce);
        }

        private void createFixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xForce = new ExternalForce() { Direction = Vector2.Right, ForceValue = 0, Target = (Node)CurrentFramework.Selected };
            var yForce = new ExternalForce() { Direction = Vector2.Up, ForceValue = 0, Target = (Node)CurrentFramework.Selected };
            xForce.Name = "Ax";
            yForce.Name = "Ay";
            CurrentFramework.AddElement(xForce);
            CurrentFramework.AddElement(yForce);
        }

        private void createVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var yForce = new ExternalForce() { Direction = Vector2.Up, ForceValue = 0, Target = (Node)CurrentFramework.Selected };
            yForce.Name = "By";
            CurrentFramework.AddElement(yForce);
        }

        private void createHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xForce = new ExternalForce() { Direction = Vector2.Right, ForceValue = 0, Target = (Node)CurrentFramework.Selected };
            xForce.Name = "Cx";
            CurrentFramework.AddElement(xForce);
        }

        private void solveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_resutlForm == null || _resutlForm.IsDisposed) _resutlForm = new frmSolveResult();
            _resutlForm.SelectionChanged += (s, e) => CurrentFramework.Select(e.Force);
            var result = (new Framework.Solver.FrameworkSolver(CurrentFramework)).Solve();
            if (result == null) return;
            _resutlForm.Results = result;
            _resutlForm.Show(this);
        }
    }
}
