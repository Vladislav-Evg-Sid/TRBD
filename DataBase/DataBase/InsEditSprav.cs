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

namespace DataBase
{
    public partial class InsEditSprav : Form
    {
        private SQLiteConnection sc;
        private SQLiteCommand command;
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataRow dr;
        private string TableName, PoleName;
        public InsEditSprav(string name, string ConnectionString, string TableNameInp, string PoleNameInp)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            TableName = TableNameInp;
            PoleName = PoleNameInp;
        }

        public InsEditSprav(string name, string ConnectionString, DataRow dr, string TableName, string PoleName)
        {
            InitializeComponent();
            this.Text = name;
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            this.dr = dr;
            tmp = new DataSet();

            textBox1.Text = dr[TableName].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() == 0)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                sc.Open();

                if ((int)Tag == 0)
                {
                    command = new SQLiteCommand("INSERT INTO " + TableName + " (" + PoleName + ") VALUES('"
                        + textBox1.Text + "')", sc);
                }
                else
                {
                    command = new SQLiteCommand("UPDATE " + TableName + " SET " + PoleName + " = ? WHERE ID_" + PoleName + " = ?", sc);
                    command.Parameters.AddWithValue("@City", textBox1.Text);
                }

                command.ExecuteNonQuery();
                sc.Close();
                Close();
            }
        }
    }
}
