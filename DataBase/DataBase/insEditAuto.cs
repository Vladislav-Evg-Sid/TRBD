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
    public partial class insEditAuto : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public insEditAuto(string name, string ConnectionString)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.label1.Text = "Марка";
            this.label2.Text = "Модель";
            this.label3.Text = "Тип топлива";
            this.label4.Text = "Трансмиссия";
            this.label5.Text = "Цена аренды";
            this.label6.Text = "Год выпуска";
            this.label7.Text = "Номер парка";
            this.label8.Text = "Расход топлива";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Brand"));
            a = new SQLiteDataAdapter("SELECT ID_Brand, Brand FROM Brand", sc);
            a.Fill(tmp.Tables["Brand"]);
            comboBox1.DisplayMember = tmp.Tables["Brand"].Columns["Brand"].ToString();
            comboBox1.ValueMember = tmp.Tables["Brand"].Columns["ID_Brand"].ToString();
            comboBox1.DataSource = tmp.Tables["Brand"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Model"));
            a = new SQLiteDataAdapter("SELECT ID_Model, Model FROM Model", sc);
            a.Fill(tmp.Tables["Model"]);
            comboBox2.DisplayMember = tmp.Tables["Model"].Columns["Model"].ToString();
            comboBox2.ValueMember = tmp.Tables["Model"].Columns["ID_Model"].ToString();
            comboBox2.DataSource = tmp.Tables["Model"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Fuel_Type"));
            a = new SQLiteDataAdapter("SELECT ID_Fuel, Fuel FROM Fuel_Type", sc);
            a.Fill(tmp.Tables["Fuel_Type"]);
            comboBox3.DisplayMember = tmp.Tables["Fuel_Type"].Columns["Fuel"].ToString();
            comboBox3.ValueMember = tmp.Tables["Fuel_Type"].Columns["ID_Fuel"].ToString();
            comboBox3.DataSource = tmp.Tables["Fuel_Type"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Transmission"));
            a = new SQLiteDataAdapter("SELECT ID_Transmission, Transmission FROM Transmission", sc);
            a.Fill(tmp.Tables["Transmission"]);
            comboBox4.DisplayMember = tmp.Tables["Transmission"].Columns["Transmission"].ToString();
            comboBox4.ValueMember = tmp.Tables["Transmission"].Columns["ID_Transmission"].ToString();
            comboBox4.DataSource = tmp.Tables["Transmission"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Park"));
            a = new SQLiteDataAdapter("SELECT ID_Park FROM Park", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox5.DisplayMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox5.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox5.DataSource = tmp.Tables["Park"];
        }
        public insEditAuto(string name, string ConnectionString, DataRow dr)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            this.label1.Text = "Марка";
            this.label2.Text = "Модель";
            this.label3.Text = "Тип топлива";
            this.label4.Text = "Трансмиссия";
            this.label5.Text = "Цена аренды";
            this.label6.Text = "Год выпуска";
            this.label7.Text = "ID_Park";
            this.label8.Text = "Расход топлива";
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Brand"));
            a = new SQLiteDataAdapter("SELECT ID_Brand, Brand FROM Brand", sc);
            a.Fill(tmp.Tables["Brand"]);
            comboBox1.DisplayMember = tmp.Tables["Brand"].Columns["Brand"].ToString();
            comboBox1.ValueMember = tmp.Tables["Brand"].Columns["ID_Brand"].ToString();
            comboBox1.DataSource = tmp.Tables["Brand"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Model"));
            a = new SQLiteDataAdapter("SELECT ID_Model, Model FROM Model", sc);
            a.Fill(tmp.Tables["Model"]);
            comboBox2.DisplayMember = tmp.Tables["Model"].Columns["Model"].ToString();
            comboBox2.ValueMember = tmp.Tables["Model"].Columns["ID_Model"].ToString();
            comboBox2.DataSource = tmp.Tables["Model"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Fuel_Type"));
            a = new SQLiteDataAdapter("SELECT ID_Fuel, Fuel FROM Fuel_Type", sc);
            a.Fill(tmp.Tables["Fuel_Type"]);
            comboBox3.DisplayMember = tmp.Tables["Fuel_Type"].Columns["Fuel"].ToString();
            comboBox3.ValueMember = tmp.Tables["Fuel_Type"].Columns["ID_Fuel"].ToString();
            comboBox3.DataSource = tmp.Tables["Fuel_Type"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Transmission"));
            a = new SQLiteDataAdapter("SELECT ID_Transmission, Transmission FROM Transmission", sc);
            a.Fill(tmp.Tables["Transmission"]);
            comboBox4.DisplayMember = tmp.Tables["Transmission"].Columns["Transmission"].ToString();
            comboBox4.ValueMember = tmp.Tables["Transmission"].Columns["ID_Transmission"].ToString();
            comboBox4.DataSource = tmp.Tables["Transmission"];
            tmp = new DataSet();
            tmp.Tables.Add(new DataTable("Park"));
            a = new SQLiteDataAdapter("SELECT ID_Park FROM Park", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox5.DisplayMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox5.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox5.DataSource = tmp.Tables["Park"];
            textBox1.Text = dr["Цена аренды"].ToString();
            textBox2.Text = dr["Год производства"].ToString();
            textBox3.Text = dr["Расход топлива"].ToString();
            comboBox1.SelectedValue = dr["ID_Brand"];
            comboBox2.SelectedValue = dr["ID_Model"];
            comboBox3.SelectedValue = dr["ID_Fuel"];
            comboBox4.SelectedValue = dr["ID_Transmission"];
            comboBox5.SelectedValue = dr["ID_Park"];

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (textBox3.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Auto (ID_Brand, ID_Model, ID_Fuel, ID_Transmission, Rent_Price, Year, ID_Park, Fuel_Consumption) VALUES('"
                        + int.Parse(comboBox1.SelectedValue.ToString())  + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) + 
                        "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '"
                        + int.Parse(comboBox5.SelectedValue.ToString()) + "', '" + textBox3.Text + "')", sc); 
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Auto  SET ID_Brand =? , ID_Model =? , ID_Fuel =? , ID_Transmission =? , Rent_Price =? , " +
                        "Year =? , ID_Park = ? , Fuel_Consuption = ?  WHERE ID_Auto = ? ", sc);
                    command.Parameters.AddWithValue("ID_Brand", int.Parse(comboBox1.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Model", int.Parse(comboBox2.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Fuel", int.Parse(comboBox3.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Transmission", int.Parse(comboBox4.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Rent_Price", textBox1.Text);
                    command.Parameters.AddWithValue("@Year", textBox2.Text);
                    command.Parameters.AddWithValue("ID_Park", int.Parse(comboBox5.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Fuel_Consumption", textBox3.Text);
                    command.Parameters.AddWithValue("@ID_Auto", dr[0]);
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
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((textBox1.Text.Count() == 0) & (textBox2.Text.Count() == 0) & (textBox3.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Auto (ID_Brand, ID_Model, ID_Fuel, ID_Transmission, Rent_Price, Year, ID_Park, Fuel_Consumption) VALUES('"
                        + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) +
                        "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '"
                        + int.Parse(comboBox5.SelectedValue.ToString()) + "', '" + textBox3.Text + "')", sc);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Auto  SET ID_Brand =? , ID_Model =? , ID_Fuel =? , ID_Transmission =? , Rent_Price =? , " +
                        "Year =? , ID_Park = ? , Fuel_Consumption = ?  WHERE ID_Auto = ? ", sc);
                    command.Parameters.AddWithValue("ID_Brand", int.Parse(comboBox1.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Model", int.Parse(comboBox2.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Fuel", int.Parse(comboBox3.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Transmission", int.Parse(comboBox4.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Rent_Price", textBox1.Text);
                    command.Parameters.AddWithValue("@Year", textBox2.Text);
                    command.Parameters.AddWithValue("ID_Park", int.Parse(comboBox5.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Fuel_Consumption", textBox3.Text);
                    command.Parameters.AddWithValue("@ID_Auto", dr[0]);
                }

                command.ExecuteNonQuery();
                sc.Close();
                Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void insEditAuto_Load(object sender, EventArgs e)
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
