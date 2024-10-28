namespace DataBase
{
    partial class FMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMDI));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.File = new System.Windows.Forms.ToolStripSplitButton();
            this.File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Main_Tables = new System.Windows.Forms.ToolStripSplitButton();
            this.MT_Park = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_Auto = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_Client = new System.Windows.Forms.ToolStripMenuItem();
            this.MT_Rent = new System.Windows.Forms.ToolStripMenuItem();
            this.Reference_Table = new System.Windows.Forms.ToolStripSplitButton();
            this.RT_Brand = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_Model = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_FuelType = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_Transm = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_RentStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.RT_City = new System.Windows.Forms.ToolStripMenuItem();
            this.Report = new System.Windows.Forms.ToolStripSplitButton();
            this.Rep_ClientList = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_ParkWork = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_AutoList = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_EmployeeList = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_AutoClient = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_AutoEmpl = new System.Windows.Forms.ToolStripMenuItem();
            this.Rep_AutoRent = new System.Windows.Forms.ToolStripMenuItem();
            this.Window = new System.Windows.Forms.ToolStripSplitButton();
            this.Win_Kascad = new System.Windows.Forms.ToolStripMenuItem();
            this.Win_Horisont = new System.Windows.Forms.ToolStripMenuItem();
            this.Win_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Main_Tables,
            this.Reference_Table,
            this.Report,
            this.Window});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // File
            // 
            this.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_Exit});
            this.File.Image = ((System.Drawing.Image)(resources.GetObject("File.Image")));
            this.File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(52, 22);
            this.File.Text = "Файл";
            // 
            // File_Exit
            // 
            this.File_Exit.Name = "File_Exit";
            this.File_Exit.Size = new System.Drawing.Size(109, 22);
            this.File_Exit.Text = "Выход";
            this.File_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Main_Tables
            // 
            this.Main_Tables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Main_Tables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MT_Park,
            this.MT_Employee,
            this.MT_Auto,
            this.MT_Client,
            this.MT_Rent});
            this.Main_Tables.Image = ((System.Drawing.Image)(resources.GetObject("Main_Tables.Image")));
            this.Main_Tables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Main_Tables.Name = "Main_Tables";
            this.Main_Tables.Size = new System.Drawing.Size(131, 22);
            this.Main_Tables.Text = "Основные таблицы";
            // 
            // MT_Park
            // 
            this.MT_Park.Name = "MT_Park";
            this.MT_Park.Size = new System.Drawing.Size(143, 22);
            this.MT_Park.Text = "Парки";
            // 
            // MT_Employee
            // 
            this.MT_Employee.Name = "MT_Employee";
            this.MT_Employee.Size = new System.Drawing.Size(143, 22);
            this.MT_Employee.Text = "Сотрудник";
            // 
            // MT_Auto
            // 
            this.MT_Auto.Name = "MT_Auto";
            this.MT_Auto.Size = new System.Drawing.Size(143, 22);
            this.MT_Auto.Text = "Автомобиль";
            // 
            // MT_Client
            // 
            this.MT_Client.Name = "MT_Client";
            this.MT_Client.Size = new System.Drawing.Size(143, 22);
            this.MT_Client.Text = "Клиент";
            // 
            // MT_Rent
            // 
            this.MT_Rent.Name = "MT_Rent";
            this.MT_Rent.Size = new System.Drawing.Size(143, 22);
            this.MT_Rent.Text = "Аренда";
            // 
            // Reference_Table
            // 
            this.Reference_Table.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Reference_Table.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RT_Brand,
            this.RT_Model,
            this.RT_FuelType,
            this.RT_Transm,
            this.RT_RentStatus,
            this.RT_City});
            this.Reference_Table.Image = ((System.Drawing.Image)(resources.GetObject("Reference_Table.Image")));
            this.Reference_Table.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reference_Table.Name = "Reference_Table";
            this.Reference_Table.Size = new System.Drawing.Size(144, 22);
            this.Reference_Table.Text = "Справочные таблицы";
            // 
            // RT_Brand
            // 
            this.RT_Brand.Name = "RT_Brand";
            this.RT_Brand.Size = new System.Drawing.Size(180, 22);
            this.RT_Brand.Text = "Марка";
            this.RT_Brand.Click += new System.EventHandler(this.LoadData_Brand);
            // 
            // RT_Model
            // 
            this.RT_Model.Name = "RT_Model";
            this.RT_Model.Size = new System.Drawing.Size(180, 22);
            this.RT_Model.Text = "Модель";
            this.RT_Model.Click += new System.EventHandler(this.LoadData_Model);
            // 
            // RT_FuelType
            // 
            this.RT_FuelType.Name = "RT_FuelType";
            this.RT_FuelType.Size = new System.Drawing.Size(180, 22);
            this.RT_FuelType.Text = "Тип топлива";
            this.RT_FuelType.Click += new System.EventHandler(this.LoadData_FuelType);
            // 
            // RT_Transm
            // 
            this.RT_Transm.Name = "RT_Transm";
            this.RT_Transm.Size = new System.Drawing.Size(180, 22);
            this.RT_Transm.Text = "Трансмиссия";
            this.RT_Transm.Click += new System.EventHandler(this.LoadData_Transmission);
            // 
            // RT_RentStatus
            // 
            this.RT_RentStatus.Name = "RT_RentStatus";
            this.RT_RentStatus.Size = new System.Drawing.Size(180, 22);
            this.RT_RentStatus.Text = "Статус аренды";
            this.RT_RentStatus.Click += new System.EventHandler(this.LoadData_RentStatus);
            // 
            // RT_City
            // 
            this.RT_City.Name = "RT_City";
            this.RT_City.Size = new System.Drawing.Size(180, 22);
            this.RT_City.Text = "Город";
            this.RT_City.Click += new System.EventHandler(this.LoadData_City);
            // 
            // Report
            // 
            this.Report.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rep_ClientList,
            this.Rep_ParkWork,
            this.Rep_AutoList,
            this.Rep_EmployeeList,
            this.Rep_AutoClient,
            this.Rep_AutoEmpl,
            this.Rep_AutoRent});
            this.Report.Image = ((System.Drawing.Image)(resources.GetObject("Report.Image")));
            this.Report.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(64, 22);
            this.Report.Text = "Отчёты";
            // 
            // Rep_ClientList
            // 
            this.Rep_ClientList.Name = "Rep_ClientList";
            this.Rep_ClientList.Size = new System.Drawing.Size(242, 22);
            this.Rep_ClientList.Text = "Список клиентов";
            // 
            // Rep_ParkWork
            // 
            this.Rep_ParkWork.Name = "Rep_ParkWork";
            this.Rep_ParkWork.Size = new System.Drawing.Size(242, 22);
            this.Rep_ParkWork.Text = "Работа парка";
            // 
            // Rep_AutoList
            // 
            this.Rep_AutoList.Name = "Rep_AutoList";
            this.Rep_AutoList.Size = new System.Drawing.Size(242, 22);
            this.Rep_AutoList.Text = "Списки автомобилей в парках";
            // 
            // Rep_EmployeeList
            // 
            this.Rep_EmployeeList.Name = "Rep_EmployeeList";
            this.Rep_EmployeeList.Size = new System.Drawing.Size(242, 22);
            this.Rep_EmployeeList.Text = "Списки сотрудников в парках";
            // 
            // Rep_AutoClient
            // 
            this.Rep_AutoClient.Name = "Rep_AutoClient";
            this.Rep_AutoClient.Size = new System.Drawing.Size(242, 22);
            this.Rep_AutoClient.Text = "Автомобили по клиентам";
            // 
            // Rep_AutoEmpl
            // 
            this.Rep_AutoEmpl.Name = "Rep_AutoEmpl";
            this.Rep_AutoEmpl.Size = new System.Drawing.Size(242, 22);
            this.Rep_AutoEmpl.Text = "Автомобили по сотрудникам";
            // 
            // Rep_AutoRent
            // 
            this.Rep_AutoRent.Name = "Rep_AutoRent";
            this.Rep_AutoRent.Size = new System.Drawing.Size(242, 22);
            this.Rep_AutoRent.Text = "Аренда автомобиля";
            // 
            // Window
            // 
            this.Window.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Window.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Win_Kascad,
            this.Win_Horisont,
            this.Win_Vertical});
            this.Window.Image = ((System.Drawing.Image)(resources.GetObject("Window.Image")));
            this.Window.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(52, 22);
            this.Window.Text = "Окно";
            // 
            // Win_Kascad
            // 
            this.Win_Kascad.Name = "Win_Kascad";
            this.Win_Kascad.Size = new System.Drawing.Size(158, 22);
            this.Win_Kascad.Text = "Каскад";
            // 
            // Win_Horisont
            // 
            this.Win_Horisont.Name = "Win_Horisont";
            this.Win_Horisont.Size = new System.Drawing.Size(158, 22);
            this.Win_Horisont.Text = "Горизонтально";
            // 
            // Win_Vertical
            // 
            this.Win_Vertical.Name = "Win_Vertical";
            this.Win_Vertical.Size = new System.Drawing.Size(158, 22);
            this.Win_Vertical.Text = "Вертикально";
            // 
            // FMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных \"Справка\"";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton File;
        private System.Windows.Forms.ToolStripMenuItem File_Exit;
        private System.Windows.Forms.ToolStripSplitButton Main_Tables;
        private System.Windows.Forms.ToolStripSplitButton Reference_Table;
        private System.Windows.Forms.ToolStripSplitButton Report;
        private System.Windows.Forms.ToolStripSplitButton Window;
        private System.Windows.Forms.ToolStripMenuItem MT_Park;
        private System.Windows.Forms.ToolStripMenuItem MT_Employee;
        private System.Windows.Forms.ToolStripMenuItem MT_Auto;
        private System.Windows.Forms.ToolStripMenuItem MT_Client;
        private System.Windows.Forms.ToolStripMenuItem MT_Rent;
        private System.Windows.Forms.ToolStripMenuItem RT_Brand;
        private System.Windows.Forms.ToolStripMenuItem RT_Model;
        private System.Windows.Forms.ToolStripMenuItem RT_FuelType;
        private System.Windows.Forms.ToolStripMenuItem RT_Transm;
        private System.Windows.Forms.ToolStripMenuItem RT_RentStatus;
        private System.Windows.Forms.ToolStripMenuItem RT_City;
        private System.Windows.Forms.ToolStripMenuItem Rep_ClientList;
        private System.Windows.Forms.ToolStripMenuItem Rep_ParkWork;
        private System.Windows.Forms.ToolStripMenuItem Rep_AutoList;
        private System.Windows.Forms.ToolStripMenuItem Rep_EmployeeList;
        private System.Windows.Forms.ToolStripMenuItem Rep_AutoClient;
        private System.Windows.Forms.ToolStripMenuItem Rep_AutoEmpl;
        private System.Windows.Forms.ToolStripMenuItem Rep_AutoRent;
        private System.Windows.Forms.ToolStripMenuItem Win_Kascad;
        private System.Windows.Forms.ToolStripMenuItem Win_Horisont;
        private System.Windows.Forms.ToolStripMenuItem Win_Vertical;
    }
}

