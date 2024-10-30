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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паркиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автомобилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.арендыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочныеТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типТопливаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.трансмиссияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусАрендыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.городToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.работаПаркаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спискиАвтомобилейВПаркахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спискиСотрудниковВПаркахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автомобилиПоКлиентамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.автомобилиПоСотрудникамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.арендаАвтомобиляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.каскадToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.основныеТаблицыToolStripMenuItem,
            this.справочныеТаблицыToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.окноToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // основныеТаблицыToolStripMenuItem
            // 
            this.основныеТаблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.паркиToolStripMenuItem,
            this.сотрудникиToolStripMenuItem,
            this.автомобилиToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.арендыToolStripMenuItem});
            this.основныеТаблицыToolStripMenuItem.Name = "основныеТаблицыToolStripMenuItem";
            this.основныеТаблицыToolStripMenuItem.Size = new System.Drawing.Size(127, 20);
            this.основныеТаблицыToolStripMenuItem.Text = "Основные таблицы";
            this.основныеТаблицыToolStripMenuItem.Click += new System.EventHandler(this.основныеТаблицыToolStripMenuItem_Click);
            // 
            // паркиToolStripMenuItem
            // 
            this.паркиToolStripMenuItem.Name = "паркиToolStripMenuItem";
            this.паркиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.паркиToolStripMenuItem.Text = "Парки";
            this.паркиToolStripMenuItem.Click += new System.EventHandler(this.ParksToolStripMenuItem_Click);
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // автомобилиToolStripMenuItem
            // 
            this.автомобилиToolStripMenuItem.Name = "автомобилиToolStripMenuItem";
            this.автомобилиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.автомобилиToolStripMenuItem.Text = "Автомобили";
            this.автомобилиToolStripMenuItem.Click += new System.EventHandler(this.автомобилиToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // арендыToolStripMenuItem
            // 
            this.арендыToolStripMenuItem.Name = "арендыToolStripMenuItem";
            this.арендыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.арендыToolStripMenuItem.Text = "Аренды";
            this.арендыToolStripMenuItem.Click += new System.EventHandler(this.арендыToolStripMenuItem_Click);
            // 
            // справочныеТаблицыToolStripMenuItem
            // 
            this.справочныеТаблицыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маркаToolStripMenuItem,
            this.модельToolStripMenuItem,
            this.типТопливаToolStripMenuItem,
            this.трансмиссияToolStripMenuItem,
            this.статусАрендыToolStripMenuItem,
            this.городToolStripMenuItem});
            this.справочныеТаблицыToolStripMenuItem.Name = "справочныеТаблицыToolStripMenuItem";
            this.справочныеТаблицыToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.справочныеТаблицыToolStripMenuItem.Text = "Справочные таблицы";
            this.справочныеТаблицыToolStripMenuItem.Click += new System.EventHandler(this.справочныеТаблицыToolStripMenuItem_Click);
            // 
            // маркаToolStripMenuItem
            // 
            this.маркаToolStripMenuItem.Name = "маркаToolStripMenuItem";
            this.маркаToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.маркаToolStripMenuItem.Text = "Марка";
            this.маркаToolStripMenuItem.Click += new System.EventHandler(this.LoadData_Brand);
            // 
            // модельToolStripMenuItem
            // 
            this.модельToolStripMenuItem.Name = "модельToolStripMenuItem";
            this.модельToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.модельToolStripMenuItem.Text = "Модель";
            this.модельToolStripMenuItem.Click += new System.EventHandler(this.LoadData_Model);
            // 
            // типТопливаToolStripMenuItem
            // 
            this.типТопливаToolStripMenuItem.Name = "типТопливаToolStripMenuItem";
            this.типТопливаToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.типТопливаToolStripMenuItem.Text = "Тип топлива";
            this.типТопливаToolStripMenuItem.Click += new System.EventHandler(this.LoadData_FuelType);
            // 
            // трансмиссияToolStripMenuItem
            // 
            this.трансмиссияToolStripMenuItem.Name = "трансмиссияToolStripMenuItem";
            this.трансмиссияToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.трансмиссияToolStripMenuItem.Text = "Трансмиссия";
            this.трансмиссияToolStripMenuItem.Click += new System.EventHandler(this.LoadData_Transmission);
            // 
            // статусАрендыToolStripMenuItem
            // 
            this.статусАрендыToolStripMenuItem.Name = "статусАрендыToolStripMenuItem";
            this.статусАрендыToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.статусАрендыToolStripMenuItem.Text = "Статус аренды";
            this.статусАрендыToolStripMenuItem.Click += new System.EventHandler(this.LoadData_RentStatus);
            // 
            // городToolStripMenuItem
            // 
            this.городToolStripMenuItem.Name = "городToolStripMenuItem";
            this.городToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.городToolStripMenuItem.Text = "Город";
            this.городToolStripMenuItem.Click += new System.EventHandler(this.LoadData_City);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКлиентовToolStripMenuItem,
            this.работаПаркаToolStripMenuItem,
            this.спискиАвтомобилейВПаркахToolStripMenuItem,
            this.спискиСотрудниковВПаркахToolStripMenuItem,
            this.автомобилиПоКлиентамToolStripMenuItem,
            this.автомобилиПоСотрудникамToolStripMenuItem,
            this.арендаАвтомобиляToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            this.отчётыToolStripMenuItem.Click += new System.EventHandler(this.отчётыToolStripMenuItem_Click);
            // 
            // списокКлиентовToolStripMenuItem
            // 
            this.списокКлиентовToolStripMenuItem.Name = "списокКлиентовToolStripMenuItem";
            this.списокКлиентовToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.списокКлиентовToolStripMenuItem.Text = "Список клиентов";
            this.списокКлиентовToolStripMenuItem.Click += new System.EventHandler(this.списокКлиентовToolStripMenuItem_Click);
            // 
            // работаПаркаToolStripMenuItem
            // 
            this.работаПаркаToolStripMenuItem.Name = "работаПаркаToolStripMenuItem";
            this.работаПаркаToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.работаПаркаToolStripMenuItem.Text = "Работа парков";
            this.работаПаркаToolStripMenuItem.Click += new System.EventHandler(this.работаПаркаToolStripMenuItem_Click);
            // 
            // спискиАвтомобилейВПаркахToolStripMenuItem
            // 
            this.спискиАвтомобилейВПаркахToolStripMenuItem.Name = "спискиАвтомобилейВПаркахToolStripMenuItem";
            this.спискиАвтомобилейВПаркахToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.спискиАвтомобилейВПаркахToolStripMenuItem.Text = "Списки автомобилей в парках";
            this.спискиАвтомобилейВПаркахToolStripMenuItem.Click += new System.EventHandler(this.спискиАвтомобилейВПаркахToolStripMenuItem_Click);
            // 
            // спискиСотрудниковВПаркахToolStripMenuItem
            // 
            this.спискиСотрудниковВПаркахToolStripMenuItem.Name = "спискиСотрудниковВПаркахToolStripMenuItem";
            this.спискиСотрудниковВПаркахToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.спискиСотрудниковВПаркахToolStripMenuItem.Text = "Списки сотрудников в парках";
            this.спискиСотрудниковВПаркахToolStripMenuItem.Click += new System.EventHandler(this.спискиСотрудниковВПаркахToolStripMenuItem_Click);
            // 
            // автомобилиПоКлиентамToolStripMenuItem
            // 
            this.автомобилиПоКлиентамToolStripMenuItem.Name = "автомобилиПоКлиентамToolStripMenuItem";
            this.автомобилиПоКлиентамToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.автомобилиПоКлиентамToolStripMenuItem.Text = "Автомобили по клиентам";
            this.автомобилиПоКлиентамToolStripMenuItem.Click += new System.EventHandler(this.автомобилиПоКлиентамToolStripMenuItem_Click);
            // 
            // автомобилиПоСотрудникамToolStripMenuItem
            // 
            this.автомобилиПоСотрудникамToolStripMenuItem.Name = "автомобилиПоСотрудникамToolStripMenuItem";
            this.автомобилиПоСотрудникамToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.автомобилиПоСотрудникамToolStripMenuItem.Text = "Автомобили по сотрудникам";
            this.автомобилиПоСотрудникамToolStripMenuItem.Click += new System.EventHandler(this.автомобилиПоСотрудникамToolStripMenuItem_Click);
            // 
            // арендаАвтомобиляToolStripMenuItem
            // 
            this.арендаАвтомобиляToolStripMenuItem.Name = "арендаАвтомобиляToolStripMenuItem";
            this.арендаАвтомобиляToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.арендаАвтомобиляToolStripMenuItem.Text = "Аренда автомобиля";
            this.арендаАвтомобиляToolStripMenuItem.Click += new System.EventHandler(this.арендаАвтомобиляToolStripMenuItem_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.каскадToolStripMenuItem,
            this.горизонтальноToolStripMenuItem,
            this.вертикальноToolStripMenuItem});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.окноToolStripMenuItem.Text = "Окно";
            // 
            // каскадToolStripMenuItem
            // 
            this.каскадToolStripMenuItem.Name = "каскадToolStripMenuItem";
            this.каскадToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.каскадToolStripMenuItem.Text = "Каскад";
            this.каскадToolStripMenuItem.Click += new System.EventHandler(this.CascadM_Clic);
            // 
            // горизонтальноToolStripMenuItem
            // 
            this.горизонтальноToolStripMenuItem.Name = "горизонтальноToolStripMenuItem";
            this.горизонтальноToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.горизонтальноToolStripMenuItem.Text = "Горизонтально";
            this.горизонтальноToolStripMenuItem.Click += new System.EventHandler(this.HorisontalM_Clic);
            // 
            // вертикальноToolStripMenuItem
            // 
            this.вертикальноToolStripMenuItem.Name = "вертикальноToolStripMenuItem";
            this.вертикальноToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.вертикальноToolStripMenuItem.Text = "Вертикально";
            this.вертикальноToolStripMenuItem.Click += new System.EventHandler(this.VerticalM_Clic);
            // 
            // FMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных \"Справка\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паркиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автомобилиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem арендыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочныеТаблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типТопливаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem трансмиссияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусАрендыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem городToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem работаПаркаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спискиАвтомобилейВПаркахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спискиСотрудниковВПаркахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автомобилиПоКлиентамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem автомобилиПоСотрудникамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem арендаАвтомобиляToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem каскадToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem горизонтальноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вертикальноToolStripMenuItem;
    }
}

