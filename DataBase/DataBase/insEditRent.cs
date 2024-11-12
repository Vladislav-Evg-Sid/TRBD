﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
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
            this.label1.Text = "ID_Employee";
            this.label2.Text = "ID_Client";
            this.label3.Text = "ID_Auto";
            this.label4.Text = "Дата начала аренды";
            this.label5.Text = "Дата окончания аренды";
            this.label6.Text = "Цена аренды";
            this.label7.Text = "Залог";
            this.label8.Text = "Статус аренды";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Employee"));
            a = new SQLiteDataAdapter("SELECT ID_Employee FROM Employee", sc);
            a.Fill(tmp.Tables["Employee"]);
            comboBox1.DisplayMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
            comboBox1.ValueMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
            comboBox1.DataSource = tmp.Tables["Employee"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Client"));
            a = new SQLiteDataAdapter("SELECT ID_Client FROM Client", sc);
            a.Fill(tmp.Tables["Client"]);
            comboBox2.DisplayMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.ValueMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.DataSource = tmp.Tables["Client"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Auto"));
            a = new SQLiteDataAdapter("SELECT ID_Auto FROM Auto", sc);
            a.Fill(tmp.Tables["Auto"]);
            comboBox3.DisplayMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.ValueMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.DataSource = tmp.Tables["Auto"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Rent_Status"));
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
            this.label1.Text = "ID_Employee";
            this.label2.Text = "ID_Client";
            this.label3.Text = "ID_Auto";
            this.label4.Text = "Дата начала аренды";
            this.label5.Text = "Дата окончания аренды";
            this.label6.Text = "Цена аренды";
            this.label7.Text = "Залог";
            this.label8.Text = "Статус аренды";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Employee"));
            a = new SQLiteDataAdapter("SELECT ID_Employee FROM Employee", sc);
            a.Fill(tmp.Tables["Employee"]);
            comboBox1.DisplayMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
            comboBox1.ValueMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
            comboBox1.DataSource = tmp.Tables["Employee"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Client"));
            a = new SQLiteDataAdapter("SELECT ID_Client FROM Client", sc);
            a.Fill(tmp.Tables["Client"]);
            comboBox2.DisplayMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.ValueMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
            comboBox2.DataSource = tmp.Tables["Client"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Auto"));
            a = new SQLiteDataAdapter("SELECT ID_Auto FROM Auto", sc);
            a.Fill(tmp.Tables["Auto"]);
            comboBox3.DisplayMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.ValueMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
            comboBox3.DataSource = tmp.Tables["Auto"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Rent_Status"));
            a = new SQLiteDataAdapter("SELECT ID_Status, Status FROM Rent_Status", sc);
            a.Fill(tmp.Tables["Rent_Status"]);
            comboBox4.DisplayMember = tmp.Tables["Rent_Status"].Columns["Status"].ToString();
            comboBox4.ValueMember = tmp.Tables["Rent_Status"].Columns["ID_Status"].ToString();
            comboBox4.DataSource = tmp.Tables["Rent_Status"];
            textBox1.Text = dr["Дата начала аренды"].ToString();
            textBox2.Text = dr["Дата окончания аренды"].ToString();
            textBox3.Text = dr["Стоимость аренды"].ToString();
            textBox4.Text = dr["Залог"].ToString();
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
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (textBox3.Text.Count() == 0) & (textBox4.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Rent (ID_Employee, ID_Client, ID_Auto, Start_Date, End_Date, Rent_Price, Pledge, ID_Status) VALUES('"
                        + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) +
                        "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '"
                        +textBox4.Text + "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "')", sc);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Rent  SET ID_Employee = ? ,  ID_Client =? , ID_Auto =? , Start_Date =? , End_Date =? , Rent_Price =? , " +
                        "Pledge =? , ID_Status = ?  WHERE ID_Rent = ? ", sc);
                    command.Parameters.AddWithValue("@ID_Employee", int.Parse(comboBox1.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@ID_Client", int.Parse(comboBox2.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@ID_Auto", int.Parse(comboBox3.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Start_Date", textBox1.Text);
                    command.Parameters.AddWithValue("@End_Date", textBox2.Text);
                    command.Parameters.AddWithValue("@Rent_Price", textBox3.Text);
                    command.Parameters.AddWithValue("@Pledge", textBox3.Text);
                    command.Parameters.AddWithValue("ID_Status", int.Parse(comboBox4.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@ID_Rent", dr[0]);
                }

                command.ExecuteNonQuery();
                sc.Close();
                Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
