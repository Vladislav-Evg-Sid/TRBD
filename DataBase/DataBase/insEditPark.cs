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
    public partial class insEditPark : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public insEditPark(string name, string ConnectionString)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.label1.Text = "Город";
            this.label2.Text = "Улица";
            this.label3.Text = "Номер дома";
            this.label4.Text = "Время начала работы";
            this.label5.Text = "Время окончания работы";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("City"));
            a = new SQLiteDataAdapter("SELECT ID_City, City FROM City", sc);
            a.Fill(tmp.Tables["City"]);
            comboBox1.DisplayMember = tmp.Tables["City"].Columns["City"].ToString();
            comboBox1.ValueMember = tmp.Tables["City"].Columns["ID_City"].ToString();
            comboBox1.DataSource = tmp.Tables["City"];

        }
        public insEditPark(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            this.label1.Text = "Город";
            this.label2.Text = "Улица";
            this.label3.Text = "Номер дома";
            this.label4.Text = "Время начала работы";
            this.label5.Text = "Время окончания работы";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("City"));
            a = new SQLiteDataAdapter("SELECT ID_City, City FROM City", sc);
            a.Fill(tmp.Tables["City"]);
            comboBox1.DisplayMember = tmp.Tables["City"].Columns["City"].ToString();
            comboBox1.ValueMember = tmp.Tables["City"].Columns["ID_City"].ToString();
            comboBox1.DataSource = tmp.Tables["City"];
            textBox1.Text = dr["Улица"].ToString();
            maskedTextBox1.Text = dr["Номер дома"].ToString();
            maskedTextBox2.Text = dr["Время начала работы"].ToString();
            maskedTextBox3.Text = dr["Время окончания работы"].ToString();
            comboBox1.SelectedValue = dr["ID_City"];
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0) & (maskedTextBox3.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            int street = int.Parse(maskedTextBox1.Text);
            if (street < 1)
            {
                MessageBox.Show("Номер дома введен неверно!");
                return;
            }
            if (maskedTextBox2.Text.Count() < 5)
            {
                MessageBox.Show("Время начала работы введено неверно!");
                return;
            }
            if (maskedTextBox3.Text.Count() < 5)
            {
                MessageBox.Show("Время окончания работы введено неверно!");
                return;
            }


            sc.Open();

            if ((int)Tag == 0)
            {
                command = new SQLiteCommand("INSERT INTO PARK (ID_City, Street, House_Number, Start_Time, End_Time) VALUES('"
                    + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + textBox1.Text + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '"
                    + maskedTextBox3.Text + "')", sc);
            }
            else
            {
                command = new SQLiteCommand("UPDATE Park  SET ID_City =? , Street =? , House_Number =? , Start_Time =? , End_Time =? " +
                    "WHERE ID_Park = ? ", sc);
                command.Parameters.AddWithValue("ID_City", int.Parse(comboBox1.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@Street", textBox1.Text);
                command.Parameters.AddWithValue("@House_Number", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@Start_Time", maskedTextBox2.Text);
                command.Parameters.AddWithValue("@End_Time", maskedTextBox3.Text);
                command.Parameters.AddWithValue("@ID_Park", dr[0]);
            }

            command.ExecuteNonQuery();
            sc.Close();
            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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
