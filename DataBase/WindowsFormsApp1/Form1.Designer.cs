namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripSplitButton();
            this.File_New = new System.Windows.Forms.ToolStripMenuItem();
            this.File_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Edit = new System.Windows.Forms.ToolStripSplitButton();
            this.Window = new System.Windows.Forms.ToolStripSplitButton();
            this.Window_Horis = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Vert = new System.Windows.Forms.ToolStripMenuItem();
            this.Window_Casc = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(442, 217);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Edit,
            this.Window});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // File
            // 
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_New,
            this.File_Delete});
            this.File.Image = ((System.Drawing.Image)(resources.GetObject("File.Image")));
            this.File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(52, 22);
            this.File.Text = "Файл";
            // 
            // File_New
            // 
            this.File_New.Name = "File_New";
            this.File_New.Size = new System.Drawing.Size(126, 22);
            this.File_New.Text = "Добавить";
            // 
            // File_Delete
            // 
            this.File_Delete.Name = "File_Delete";
            this.File_Delete.Size = new System.Drawing.Size(126, 22);
            this.File_Delete.Text = "Удалить";
            // 
            // Edit
            // 
            this.Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(103, 22);
            this.Edit.Text = "Редактировать";
            // 
            // Window
            // 
            this.Window.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Window_Horis,
            this.Window_Vert,
            this.Window_Casc});
            this.Window.Image = ((System.Drawing.Image)(resources.GetObject("Window.Image")));
            this.Window.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(52, 22);
            this.Window.Text = "Окно";
            // 
            // Window_Horis
            // 
            this.Window_Horis.Name = "Window_Horis";
            this.Window_Horis.Size = new System.Drawing.Size(158, 22);
            this.Window_Horis.Text = "Горизонтально";
            // 
            // Window_Vert
            // 
            this.Window_Vert.Name = "Window_Vert";
            this.Window_Vert.Size = new System.Drawing.Size(158, 22);
            this.Window_Vert.Text = "Вертикально";
            // 
            // Window_Casc
            // 
            this.Window_Casc.Name = "Window_Casc";
            this.Window_Casc.Size = new System.Drawing.Size(158, 22);
            this.Window_Casc.Text = "Каскад";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton File;
        private System.Windows.Forms.ToolStripMenuItem File_New;
        private System.Windows.Forms.ToolStripMenuItem File_Delete;
        private System.Windows.Forms.ToolStripSplitButton Edit;
        private System.Windows.Forms.ToolStripSplitButton Window;
        private System.Windows.Forms.ToolStripMenuItem Window_Horis;
        private System.Windows.Forms.ToolStripMenuItem Window_Vert;
        private System.Windows.Forms.ToolStripMenuItem Window_Casc;
    }
}

