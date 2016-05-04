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
    public partial class frmMain : Form
    {
        public PlainFramework CurrentFramework = new PlainFramework();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            canvas.CurrentFramework = CurrentFramework;
        }
    }
}
