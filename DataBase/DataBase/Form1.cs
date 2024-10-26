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
    public partial class Form1 : Form
    {
        private SQLiteConnection sqliteConn;
        public Form1()
        {
            InitializeComponent();
            sqliteConn = new SQLiteConnection("Data Source=AutoPark.db;Version=3;");
            sqliteConn.Open();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqliteConn.Close();
        }
    }
}
