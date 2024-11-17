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
            a = new SQLiteDataAdapter("SELECT Park.ID_Park, Park.ID_Park || '.' || City.City || '.' || Park.Street || '.' || Park.House_Number AS [Par] FROM Park JOIN City ON Park.ID_City = City.ID_City", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox5.DisplayMember = tmp.Tables["Park"].Columns["Par"].ToString();
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
            a = new SQLiteDataAdapter("SELECT Park.ID_Park, Park.ID_Park || '.' || City.City || '.' || Park.Street || '.' || Park.House_Number AS [Par] FROM Park JOIN City ON Park.ID_City = City.ID_City", sc);
            a.Fill(tmp.Tables["Park"]);
            comboBox5.DisplayMember = tmp.Tables["Park"].Columns["Par"].ToString();
            comboBox5.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
            comboBox5.DataSource = tmp.Tables["Park"];
            maskedTextBox1.Text = dr["Цена аренды"].ToString();
            maskedTextBox2.Text = dr["Год производства"].ToString();
            maskedTextBox3.Text = dr["Расход топлива"].ToString();
            comboBox1.SelectedValue = dr["ID_Brand"];
            comboBox2.SelectedValue = dr["ID_Model"];
            comboBox3.SelectedValue = dr["ID_Fuel"];
            comboBox4.SelectedValue = dr["ID_Transmission"];
            comboBox5.SelectedValue = dr["ID_Park"];

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0) & (maskedTextBox3.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
            }
            if (maskedTextBox2.Text.Count() < 4)
            {
                MessageBox.Show("Год заполнен не до конца!");
            }
            
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO Auto (ID_Brand, ID_Model, ID_Fuel, ID_Transmission, Rent_Price, Year, ID_Park, Fuel_Consumption) VALUES('"
                        + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) +
                        "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '"
                        + int.Parse(comboBox5.SelectedValue.ToString()) + "', '" + maskedTextBox3.Text + "')", sc);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE Auto  SET ID_Brand =? , ID_Model =? , ID_Fuel =? , ID_Transmission =? , Rent_Price =? , " +
                        "Year =? , ID_Park = ? , Fuel_Consuption = ?  WHERE ID_Auto = ? ", sc);
                    command.Parameters.AddWithValue("ID_Brand", int.Parse(comboBox1.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Model", int.Parse(comboBox2.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Fuel", int.Parse(comboBox3.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("ID_Transmission", int.Parse(comboBox4.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Rent_Price", maskedTextBox1.Text);
                    command.Parameters.AddWithValue("@Year", maskedTextBox2.Text);
                    command.Parameters.AddWithValue("ID_Park", int.Parse(comboBox5.SelectedValue.ToString()));
                    command.Parameters.AddWithValue("@Fuel_Consumption", maskedTextBox3.Text);
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
            if ((maskedTextBox1.Text.Count() == 0) & (maskedTextBox2.Text.Count() == 0) & (maskedTextBox3.Text.Count() == 0))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            int year = int.Parse(maskedTextBox2.Text);
            int price = int.Parse(maskedTextBox1.Text);
            int fuel = int.Parse(maskedTextBox3.Text);
            if (price < 1000)
            {
                MessageBox.Show("Цена слишком низкая!");
                return;

            }
            if (year < 1950 || year > 2024)
            {
                MessageBox.Show("Год должен быть в диапазоне от 1950 до 2024!");
                return;
            }
            if (fuel < 3)
            {
                MessageBox.Show("Слишком низкое значение расхода топлива!");
                return;
            }


            sc.Open();

            if ((int)Tag == 0)
            {
                command = new SQLiteCommand("INSERT INTO Auto (ID_Brand, ID_Model, ID_Fuel, ID_Transmission, Rent_Price, Year, ID_Park, Fuel_Consumption) VALUES('"
                    + int.Parse(comboBox1.SelectedValue.ToString()) + "', '" + int.Parse(comboBox2.SelectedValue.ToString()) + "', '" + int.Parse(comboBox3.SelectedValue.ToString()) +
                    "', '" + int.Parse(comboBox4.SelectedValue.ToString()) + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '"
                    + int.Parse(comboBox5.SelectedValue.ToString()) + "', '" + maskedTextBox3.Text + "')", sc);
            }
            else
            {
                command = new SQLiteCommand("UPDATE Auto  SET ID_Brand =? , ID_Model =? , ID_Fuel =? , ID_Transmission =? , Rent_Price =? , " +
                    "Year =? , ID_Park = ? , Fuel_Consumption = ?  WHERE ID_Auto = ? ", sc);
                command.Parameters.AddWithValue("ID_Brand", int.Parse(comboBox1.SelectedValue.ToString()));
                command.Parameters.AddWithValue("ID_Model", int.Parse(comboBox2.SelectedValue.ToString()));
                command.Parameters.AddWithValue("ID_Fuel", int.Parse(comboBox3.SelectedValue.ToString()));
                command.Parameters.AddWithValue("ID_Transmission", int.Parse(comboBox4.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@Rent_Price", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@Year", maskedTextBox2.Text);
                command.Parameters.AddWithValue("ID_Park", int.Parse(comboBox5.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@Fuel_Consumption", maskedTextBox3.Text);
                command.Parameters.AddWithValue("@ID_Auto", dr[0]);
            }

            command.ExecuteNonQuery();
            sc.Close();
            Close();

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

        private void maskedmaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
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
