using System;
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
    public partial class insEditClient : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public insEditClient(string name, string ConnectionString)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.label1.Text = "Фамилия";
            this.label2.Text = "Имя";
            this.label3.Text = "Отчество";
            this.label4.Text = "ВУ";
            this.label5.Text = "Стаж";
            this.label6.Text = "Номер телефона";
            this.label7.Text = "Дата рождения";
        }
        public insEditClient(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            this.label1.Text = "Фамилия";
            this.label2.Text = "Имя";
            this.label3.Text = "Отчество";
            this.label4.Text = "ВУ";
            this.label5.Text = "Стаж";
            this.label6.Text = "Номер телефона";
            this.label7.Text = "Дата рождения";
            textBox1.Text = dr["Фамилия"].ToString();
            textBox2.Text = dr["Имя"].ToString();
            textBox3.Text = dr["Отчество"].ToString();
            maskedTextBox1.Text = dr["ВУ"].ToString();
            maskedTextBox2.Text = dr["Стаж"].ToString();
            maskedTextBox3.Text = dr["Номер телефона"].ToString();
            maskedTextBox4.Text = dr["Дата рождения"].ToString();
           



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0)
                & (maskedTextBox3.Text.Count() == 0) & (maskedTextBox4.Text.Count() == 0))
                

            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            int expirience = int.Parse(maskedTextBox2.Text);
            if ((maskedTextBox1.Text.Count() < 11))
            {
                MessageBox.Show("Водительсоке удостоверение не до конца заполнено!");
                return;
            }
            if ((maskedTextBox3.Text.Count() < 11))
            {
                MessageBox.Show("Номер не до конца заполнен!");
                return;
            }
            if (expirience == 0)
            {
                MessageBox.Show("Стаж не может быть равным 0");
                return;
            }
            if ((maskedTextBox4.Text.Count() < 10))
            {
                MessageBox.Show("Дата рождения не до конца заполнена!");
                return;
            }


            sc.Open();

            if ((int)Tag == 0)
            {
                command = new SQLiteCommand("INSERT INTO Client (Client_Surname, Client_Name, Client_Patronymic, License, Expirience, Phone_Number, Date_of_Birth) VALUES('"
                    + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '"
                    + maskedTextBox3.Text + "', '" + maskedTextBox4.Text + "')", sc);
            }
            else
            {
                command = new SQLiteCommand("UPDATE Client  SET Client_Surname =? , Client_Name =? , Client_Patronymic =? , License =? , Expirience =? , " +
                    "Phone_Number =? , Date_of_Birth = ?  WHERE ID_Client = ? ", sc);
                command.Parameters.AddWithValue("@Client_Surname", textBox1.Text);
                command.Parameters.AddWithValue("@Client_Name", textBox2.Text);
                command.Parameters.AddWithValue("@Client_Patronymic", textBox3.Text);
                command.Parameters.AddWithValue("@License", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@Expirience", maskedTextBox2.Text);
                command.Parameters.AddWithValue("@Phone_Number", maskedTextBox3.Text);
                command.Parameters.AddWithValue("@Date_of_Birth", maskedTextBox4.Text);
                command.Parameters.AddWithValue("@ID_Client", dr[0]);
            }

            command.ExecuteNonQuery();
            sc.Close();
            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void insEditClient_Load(object sender, EventArgs e)
        {

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
