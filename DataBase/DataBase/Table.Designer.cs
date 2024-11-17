namespace DataBase
{
    partial class Table
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.InsTable = new System.Windows.Forms.ToolStripButton();
            this.EditTable = new System.Windows.Forms.ToolStripButton();
            this.DelTable = new System.Windows.Forms.ToolStripButton();
            this.CloseTable = new System.Windows.Forms.ToolStripButton();
            this.ReportTable = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsTable,
            this.EditTable,
            this.DelTable,
            this.CloseTable,
            this.ReportTable,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(741, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // InsTable
            // 
            this.InsTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InsTable.Image = ((System.Drawing.Image)(resources.GetObject("InsTable.Image")));
            this.InsTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsTable.Name = "InsTable";
            this.InsTable.Size = new System.Drawing.Size(122, 22);
            this.InsTable.Text = "Добавление данных";
            this.InsTable.Click += new System.EventHandler(this.InsTable_Click);
            // 
            // EditTable
            // 
            this.EditTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditTable.Image = ((System.Drawing.Image)(resources.GetObject("EditTable.Image")));
            this.EditTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditTable.Name = "EditTable";
            this.EditTable.Size = new System.Drawing.Size(144, 22);
            this.EditTable.Text = "Редактирование данных";
            this.EditTable.Click += new System.EventHandler(this.EditTable_Click);
            // 
            // DelTable
            // 
            this.DelTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DelTable.Image = ((System.Drawing.Image)(resources.GetObject("DelTable.Image")));
            this.DelTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelTable.Name = "DelTable";
            this.DelTable.Size = new System.Drawing.Size(107, 22);
            this.DelTable.Text = "Удаление данных";
            this.DelTable.Click += new System.EventHandler(this.DelTable_Click);
            // 
            // CloseTable
            // 
            this.CloseTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CloseTable.Image = ((System.Drawing.Image)(resources.GetObject("CloseTable.Image")));
            this.CloseTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseTable.Name = "CloseTable";
            this.CloseTable.Size = new System.Drawing.Size(46, 22);
            this.CloseTable.Text = "Выход";
            this.CloseTable.Click += new System.EventHandler(this.CloseTable_Click);
            // 
            // ReportTable
            // 
            this.ReportTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReportTable.Image = ((System.Drawing.Image)(resources.GetObject("ReportTable.Image")));
            this.ReportTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReportTable.Name = "ReportTable";
            this.ReportTable.Size = new System.Drawing.Size(128, 22);
            this.ReportTable.Text = "Сформировать отчёт";
            this.ReportTable.Click += new System.EventHandler(this.ReportTable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(741, 275);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.Change_Filter);
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 300);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Table";
            this.Text = "Form2";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InsTable;
        private System.Windows.Forms.ToolStripButton EditTable;
        private System.Windows.Forms.ToolStripButton DelTable;
        private System.Windows.Forms.ToolStripButton CloseTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton ReportTable;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}