using PlainFrameworkSolver.Framework;
using PlainFrameworkSolver.Framework.Events;
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
            tvFramework.Nodes.Add(nodesNode);
            tvFramework.Nodes.Add(barsNode);
            tvFramework.Nodes.Add(forcesNode);
        }

        public void FrameworkSelectedChangedHandler(object sender, FrameworkSelectedElementChangedEventArgs e)
        {
            this.propertyGrid.SelectedObject = CurrentFramework.Selected;
        }

        public void FrameworkChangedHanlder(object sender, FrameworkChangedEventArgs e)
        {

        }
    }
}
