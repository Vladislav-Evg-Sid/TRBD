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
            textBox4.Text = dr["ВУ"].ToString();
            textBox5.Text = dr["Стаж"].ToString();
            textBox6.Text = dr["Номер телефона"].ToString();
            textBox7.Text = dr["Дата рождения"].ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (textBox4.Text.Count() == 0) & (textBox5.Text.Count() == 0)
                & (textBox6.Text.Count() == 0) & (textBox7.Text.Count() == 0))

            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Client (Client_Surname, Client_Name, Client_Patronymic, License, Expirience, Phone_Number, Date_of_Birth) VALUES('"
                        + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '"
                        + textBox6.Text + "', '" + textBox7.Text + "')", sc);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Client  SET Client_Surname =? , Client_Name =? , Client_Patronymic =? , License =? , Expirience =? , " +
                        "Phone_Number =? , Date_of_Birth = ?  WHERE ID_Client = ? ", sc);
                    command.Parameters.AddWithValue("@Client_Surname", textBox1.Text);
                    command.Parameters.AddWithValue("@Client_Name", textBox2.Text);
                    command.Parameters.AddWithValue("@Client_Patronymic", textBox3.Text);
                    command.Parameters.AddWithValue("@License", textBox4.Text);
                    command.Parameters.AddWithValue("@Expirience", textBox5.Text);
                    command.Parameters.AddWithValue("@Phone_Number", textBox6.Text);
                    command.Parameters.AddWithValue("@Date_of_Birth", textBox7.Text);
                    command.Parameters.AddWithValue("@ID_Client", dr[0]);
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

        private void insEditClient_Load(object sender, EventArgs e)
        {

        }
    }
}
