using PlainFrameworkSolver.Framework;
using PlainFrameworkSolver.Framework.Solver;
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
    public partial class frmSolveResult : Form
    {

        private List<ResultEntry> _results;
        public List<ResultEntry> Results
        {
            get { return _results; }
            set { _results = value; UpdateDataGridView(); }
        }

        public frmSolveResult()
        {
            InitializeComponent();
        }

        public void UpdateDataGridView()
        {
            dgvResult.DataSource = new BindingList<ResultEntry>(Results);
            dgvResult.Invalidate();
        }
    }
}
