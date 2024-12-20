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

namespace DataBase
{
    public partial class insEditEmployee : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public insEditEmployee(string name, string ConnectionString)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.label1.Text = "Фамилия";
            this.label2.Text = "Имя";
            this.label3.Text = "Отчество";
            this.label4.Text = "Паспорт";
            this.label5.Text = "ИНН";
            this.label6.Text = "Номер парка";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Park"));
            a = new SQLiteDataAdapter("SELECT Park.ID_Park, Park.ID_Park || '.' || City.City || '.' || Park.Street || '.' || Park.House_Number AS [Par] FROM Park JOIN City ON Park.ID_City = City.ID_City", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox1.DisplayMember = tmp.Tables["Park"].Columns["Par"].ToString();
            comboBox1.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox1.DataSource = tmp.Tables["Park"];


        }
        public insEditEmployee(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            this.label1.Text = "Фамилия";
            this.label2.Text = "Имя";
            this.label3.Text = "Отчество";
            this.label4.Text = "Паспорт";
            this.label5.Text = "ИНН";
            this.label6.Text = "Номер парка";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Park"));
            a = new SQLiteDataAdapter("SELECT Park.ID_Park, Park.ID_Park || '.' || City.City || '.' || Park.Street || '.' || Park.House_Number AS [Par] FROM Park JOIN City ON Park.ID_City = City.ID_City", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox1.DisplayMember = tmp.Tables["Park"].Columns["Par"].ToString(); comboBox1.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox1.DataSource = tmp.Tables["Park"];
            textBox1.Text = dr["Фамилия"].ToString();
            textBox2.Text = dr["Имя"].ToString();
            textBox3.Text = dr["Отчество"].ToString();
            maskedTextBox1.Text = dr["Паспорт"].ToString();
            maskedTextBox2.Text = dr["ИНН"].ToString();
            comboBox1.SelectedValue = dr["ID_Park"];


        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            if (maskedTextBox1.Text.Count() < 11)
            {
                MessageBox.Show("Паспорт не до конца заполнен!");
                return;
            }
            if (maskedTextBox2.Text.Count() < 12)
            {
                MessageBox.Show("ИНН не до конца заполнен!");
                return;
            }


            sc.Open();

            if ((int)Tag == 0)
            {
                command = new SQLiteCommand("INSERT INTO Employee (Employee_Surname, Employee_Name, Employee_Patronymic, Passport, INN, ID_Park) VALUES('"
                    + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '"
                    + int.Parse(comboBox1.SelectedValue.ToString()) + "')", sc);
            }
            else
            {
                command = new SQLiteCommand("UPDATE Employee  SET Employee_Surname =? , Employee_Name =? , Employee_Patronymic =? , Passport =? , INN =? , " +
                    "ID_Park =? WHERE ID_Employee = ? ", sc);
                command.Parameters.AddWithValue("@Employee_Surname", textBox1.Text);
                command.Parameters.AddWithValue("@Employee_Name", textBox2.Text);
                command.Parameters.AddWithValue("@Employee_Patronymic", textBox3.Text);
                command.Parameters.AddWithValue("@Passport", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@INN", maskedTextBox2.Text);
                command.Parameters.AddWithValue("ID_Park", int.Parse(comboBox1.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@ID_Employee", dr[0]);
            }

            command.ExecuteNonQuery();
            sc.Close();
            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void insEditEmployee_Load(object sender, EventArgs e)
        {

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
