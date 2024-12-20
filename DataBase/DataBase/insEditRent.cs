﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class insEditRent : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public insEditRent(string name, string ConnectionString)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.label1.Text = "Сотрудник";
            this.label2.Text = "Клиент";
            this.label3.Text = "Автомобиль";
            this.label4.Text = "Дата начала";
            this.label5.Text = "Дата окончания";
            this.label7.Text = "Залог";
            this.label8.Text = "Статус аренды";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Employee"));
            tmp.Tables.Add(new DataTable("Client"));
            tmp.Tables.Add(new DataTable("Auto"));
            tmp.Tables.Add(new DataTable("Rent_Status"));
            a = new SQLiteDataAdapter("SELECT ID_Client, ID_Client || '. '|| Client_Surname || ' ' || SUBSTR(Client_Name, 1, 1) || '.' AS [Cli] FROM Client", sc);
            a.Fill(tmp.Tables["Client"]);
            comboBox2.DisplayMember = tmp.Tables["Client"].Columns["Cli"].ToString();
            comboBox2.ValueMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.DataSource = tmp.Tables["Client"];
            a = new SQLiteDataAdapter("SELECT Auto.ID_Auto, Auto.ID_Auto || '. '|| Brand.Brand || ' ' || Model.Model AS [Aut] FROM Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model", sc);
            a.Fill(tmp.Tables["Auto"]);
            comboBox3.DisplayMember = tmp.Tables["Auto"].Columns["Aut"].ToString();
            comboBox3.ValueMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.DataSource = tmp.Tables["Auto"];
            a = new SQLiteDataAdapter("SELECT ID_Status, Status FROM Rent_Status", sc);
            a.Fill(tmp.Tables["Rent_Status"]);
            comboBox4.DisplayMember = tmp.Tables["Rent_Status"].Columns["Status"].ToString();
            comboBox4.ValueMember = tmp.Tables["Rent_Status"].Columns["ID_Status"].ToString();
            comboBox4.DataSource = tmp.Tables["Rent_Status"];
        }
        public insEditRent(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            this.label1.Text = "Сотрудник";
            this.label2.Text = "Клиент";
            this.label3.Text = "Автомобиль";
            this.label4.Text = "Дата начала";
            this.label5.Text = "Дата окончания";
            this.label7.Text = "Залог";
            this.label8.Text = "Статус аренды";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Employee"));
            tmp.Tables.Add(new DataTable("Client"));
            tmp.Tables.Add(new DataTable("Auto"));
            tmp.Tables.Add(new DataTable("Rent_Status"));
            a = new SQLiteDataAdapter("SELECT ID_Client, ID_Client || '. '|| Client_Surname || ' ' || SUBSTR(Client_Name, 1, 1) || '.' AS [Cli] FROM Client", sc);
            a.Fill(tmp.Tables["Client"]);
            comboBox2.DisplayMember = tmp.Tables["Client"].Columns["Cli"].ToString();
            comboBox2.ValueMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.DataSource = tmp.Tables["Client"];
            a = new SQLiteDataAdapter("SELECT Auto.ID_Auto, Auto.ID_Auto || '. '|| Brand.Brand || ' ' || Model.Model AS [Aut] FROM Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model", sc);
            a.Fill(tmp.Tables["Auto"]);
            comboBox3.DisplayMember = tmp.Tables["Auto"].Columns["Aut"].ToString();
            comboBox3.ValueMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.DataSource = tmp.Tables["Auto"];
            a = new SQLiteDataAdapter("SELECT ID_Status, Status FROM Rent_Status", sc);
            a.Fill(tmp.Tables["Rent_Status"]);
            comboBox4.DisplayMember = tmp.Tables["Rent_Status"].Columns["Status"].ToString();
            comboBox4.ValueMember = tmp.Tables["Rent_Status"].Columns["ID_Status"].ToString();
            comboBox4.DataSource = tmp.Tables["Rent_Status"];
            maskedTextBox1.Text = dr["Дата начала аренды"].ToString();
            maskedTextBox2.Text = dr["Дата окончания аренды"].ToString();
            maskedTextBox3.Text = dr["Залог"].ToString();
            comboBox1.SelectedValue = dr["ID_Employee"];
            comboBox2.SelectedValue = dr["ID_Client"];
            comboBox3.SelectedValue = dr["ID_Auto"];
            comboBox4.SelectedValue = dr["ID_Status"];

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0) & (maskedTextBox3.Text.Count() == 0))
            { MessageBox.Show("Не все поля заполнены"); return;}
            if (!TextIsDate(maskedTextBox1.Text))
            { MessageBox.Show("Дата начала аренды введене некорректно"); return; }
            if (!TextIsDate(maskedTextBox2.Text))
            { MessageBox.Show("Дата окончания аренды введене некорректно"); return; }
            DateTime dt1 = DateTime.ParseExact(maskedTextBox1.Text, "dd.MM.yyyy", null);
            DateTime dt2 = DateTime.ParseExact(maskedTextBox2.Text, "dd.MM.yyyy", null);
            TimeSpan ts = dt2 - dt1;
            int days = ts.Days + 1;
            if (days < 1)
            { MessageBox.Show("Дата начала должна быть не позже даты окончания аренды"); return; }
            int pledge = int.Parse(maskedTextBox3.Text);
            if (pledge < 0)
            {
                MessageBox.Show("Залог не может быть меньше 0!");return;
            } 
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Auto_Cost"));
            a = new SQLiteDataAdapter("SELECT Rent_Price FROM Auto WHERE ID_Auto = " + int.Parse(comboBox3.SelectedValue.ToString()), sc);
            a.Fill(tmp.Tables["Auto_Cost"]);



            int summ = Convert.ToInt32(tmp.Tables["Auto_Cost"].Rows[0][0]);
            summ = summ * days;

            sc.Open();
            if ((int)Tag == 0)
            {
                command = new SQLiteCommand("INSERT INTO Rent (ID_Employee, ID_Client, ID_Auto, Start_Date, End_Date, Rent_Price, Pledge, ID_Status) VALUES('"
                    + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) +
                    "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '" + summ + "', '"
                    +maskedTextBox3.Text + "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "')", sc);
            }
            else
            {
                command = new SQLiteCommand("UPDATE Rent  SET ID_Employee = ? ,  ID_Client =? , ID_Auto =? , Start_Date =? , End_Date =? , Rent_Price =? , " +
                    "Pledge =? , ID_Status = ?  WHERE ID_Rent = ? ", sc);
                command.Parameters.AddWithValue("@ID_Employee", int.Parse(comboBox1.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@ID_Client", int.Parse(comboBox2.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@ID_Auto", int.Parse(comboBox3.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@Start_Date", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@End_Date", maskedTextBox2.Text);
                command.Parameters.AddWithValue("@Rent_Price", summ);
                command.Parameters.AddWithValue("@Pledge", maskedTextBox3.Text);
                command.Parameters.AddWithValue("ID_Status", int.Parse(comboBox4.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@ID_Rent", dr[0]);
            }

            command.ExecuteNonQuery();
            sc.Close();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static bool TextIsDate(string text)
        {
            var dateFormat = "dd.MM.yyyy";
            DateTime scheduleDate;
            return (DateTime.TryParseExact(text, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate)) ;
        }

        private void maskedmaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        
        private void Change_Park(object sender, EventArgs e)
        {
            a = new SQLiteDataAdapter(
                "SELECT ID_Employee, ID_Employee || '. '|| Employee_Surname || ' ' || SUBSTR(Employee_Name, 1, 1) || '.' AS [Emp]" +
                "FROM Employee WHERE ID_Employee = " + int.Parse(comboBox3.SelectedValue.ToString()), sc);
            tmp.Tables["Employee"].Clear();
            a.Fill(tmp.Tables["Employee"]);
            comboBox1.DisplayMember = tmp.Tables["Employee"].Columns["Emp"].ToString();
            comboBox1.ValueMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
            comboBox1.DataSource = tmp.Tables["Employee"];
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.V))
                return true;
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
