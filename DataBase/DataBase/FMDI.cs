using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class FMDI : Form
    {
        private SQLiteConnection sqliteConn;
        private string ConnectionString = ("Data Source=AutoPark.db;Version=3;");
        public FMDI()
        {
            InitializeComponent();
            sqliteConn = new SQLiteConnection(ConnectionString);
            sqliteConn.Open();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqliteConn.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadM_Clic(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void HorisontalM_Clic(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void VerticalM_Clic(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void LoadData_Brand(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void LoadData_City(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void LoadData_FuelType(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void LoadData_Model(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void LoadData_RentStatus(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void LoadData_Transmission(object sender, EventArgs e)
        {
            string str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var a in MdiChildren)
            {
                if (a.Text == str)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Table t = new Table(str, ConnectionString);
                t.MdiParent = this;
                t.Show();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        
        }
    }
}
