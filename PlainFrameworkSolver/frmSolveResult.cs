using PlainFrameworkSolver.Framework;
using PlainFrameworkSolver.Framework.Solver;
using PlainFrameworkSolver.Utils.Events;
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
        public event EventHandler<DataGridViewSelectionChangedEventArgs> SelectionChanged;


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
            if (Results == null) return;
            dgvResult.DataSource = new BindingList<ResultEntry>(Results);
            dgvResult.Invalidate();
        }

        public void SelectFrameworkElement(FrameworkElement element)
        {
            dgvResult.ClearSelection();
            if (element == null || !(element is Force)) return;
            foreach (var row in dgvResult.Rows)
            {
                var dgvRow = (DataGridViewRow)row;
                var entry = (ResultEntry)dgvRow.DataBoundItem;
                if (entry.Force == element) dgvRow.Selected = true;
            }
        }

        private void dgvResult_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;
            var row = dgvResult.SelectedRows[0];
            SelectionChanged?.Invoke(this, new DataGridViewSelectionChangedEventArgs(((ResultEntry)row.DataBoundItem).Force));
        }
    }
}
