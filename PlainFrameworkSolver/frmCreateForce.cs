using Artentus.Utils.Math;
using PlainFrameworkSolver.Framework;
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
    public partial class frmCreateForce : Form
    {
        public ExternalForce ResultForce { get; protected set; }

        public PlainFramework CurrentFramework { get; set; }

        public frmCreateForce()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ResultForce = new ExternalForce();
            var f = (new Vector2((double)nupX.Value, (double)nupY.Value));
            ResultForce.Direction = f.Normalize();
            ResultForce.ForceValue = f.Length;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
