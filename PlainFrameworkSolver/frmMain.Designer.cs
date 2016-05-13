namespace PlainFrameworkSolver
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menueMain = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvFramework = new System.Windows.Forms.TreeView();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.canvasContextMenue = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.createFixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMovableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvas = new PlainFrameworkSolver.Canvas();
            this.menueMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.canvasContextMenue.SuspendLayout();
            this.SuspendLayout();
            // 
            // menueMain
            // 
            this.menueMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menueMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem});
            this.menueMain.Location = new System.Drawing.Point(0, 0);
            this.menueMain.Name = "menueMain";
            this.menueMain.Size = new System.Drawing.Size(594, 24);
            this.menueMain.TabIndex = 0;
            this.menueMain.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.dateiToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Image = global::PlainFrameworkSolver.Properties.Resources.CloseImage;
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.beendenToolStripMenuItem.Text = "Close";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.toolStripSeparator3,
            this.solveToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.bearbeitenToolStripMenuItem.Text = "Edit";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckOnClick = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gridToolStripMenuItem.Image")));
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.CheckedChanged += new System.EventHandler(this.gridToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(99, 6);
            // 
            // solveToolStripMenuItem
            // 
            this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
            this.solveToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.solveToolStripMenuItem.Text = "Solve";
            this.solveToolStripMenuItem.Click += new System.EventHandler(this.solveToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.canvas, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(594, 487);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(392, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvFramework);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(199, 481);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvFramework
            // 
            this.tvFramework.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFramework.Location = new System.Drawing.Point(0, 0);
            this.tvFramework.Name = "tvFramework";
            this.tvFramework.Size = new System.Drawing.Size(199, 249);
            this.tvFramework.TabIndex = 0;
            this.tvFramework.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFramework_AfterSelect);
            this.tvFramework.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HandleKeyDown);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.MinimumSize = new System.Drawing.Size(0, 200);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(199, 228);
            this.propertyGrid.TabIndex = 0;
            // 
            // canvasContextMenue
            // 
            this.canvasContextMenue.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.canvasContextMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createForceToolStripMenuItem,
            this.toolStripSeparator2,
            this.createFixedToolStripMenuItem,
            this.createMovableToolStripMenuItem});
            this.canvasContextMenue.Name = "canvasContextMenue";
            this.canvasContextMenue.Size = new System.Drawing.Size(201, 76);
            // 
            // createForceToolStripMenuItem
            // 
            this.createForceToolStripMenuItem.Name = "createForceToolStripMenuItem";
            this.createForceToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createForceToolStripMenuItem.Text = "Create Force";
            this.createForceToolStripMenuItem.Click += new System.EventHandler(this.createForceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // createFixedToolStripMenuItem
            // 
            this.createFixedToolStripMenuItem.Name = "createFixedToolStripMenuItem";
            this.createFixedToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createFixedToolStripMenuItem.Text = "Create Fixed Bearing";
            this.createFixedToolStripMenuItem.Click += new System.EventHandler(this.createFixedToolStripMenuItem_Click);
            // 
            // createMovableToolStripMenuItem
            // 
            this.createMovableToolStripMenuItem.Name = "createMovableToolStripMenuItem";
            this.createMovableToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.createMovableToolStripMenuItem.Text = "Create Movable Bearing";
            this.createMovableToolStripMenuItem.Click += new System.EventHandler(this.createMovableToolStripMenuItem_Click);
            // 
            // canvas
            // 
            this.canvas.AutoScroll = true;
            this.canvas.ContextMenue = this.canvasContextMenue;
            this.canvas.CurrentFramework = null;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.GridEnabled = true;
            this.canvas.Location = new System.Drawing.Point(3, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(383, 481);
            this.canvas.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menueMain);
            this.MainMenuStrip = this.menueMain;
            this.MinimumSize = new System.Drawing.Size(374, 324);
            this.Name = "frmMain";
            this.Text = "Plain Framework Solver";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menueMain.ResumeLayout(false);
            this.menueMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.canvasContextMenue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menueMain;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvFramework;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private Canvas canvas;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip canvasContextMenue;
        private System.Windows.Forms.ToolStripMenuItem createForceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem createFixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMovableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem solveToolStripMenuItem;
    }
}

