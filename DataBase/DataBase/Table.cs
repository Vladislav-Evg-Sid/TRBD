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
    public partial class Table : Form
    {
        private SQLiteConnection sc = new SQLiteConnection();
        private SQLiteDataAdapter a;
        private SQLiteCommand command = new SQLiteCommand();
        private DataTable dt = new DataTable();

        private string nameTable;
        private string query;

        private int CurrentIndex = 0;

        public Table(string nameF, string ConnectionString)
        {
            InitializeComponent();
            this.Text = nameF;
            this.Name = nameF;
            this.sc.ConnectionString = ConnectionString;
            switch (this.Name)
            {
                case "Город":
                    {
                        query = "SELECT City.ID_City, City.City AS [Город] FROM City";
                        this.nameTable = "City";
                        break;
                    }
                    // Другие таблицы
            }
            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
            HideFields();
        }
        private void HideFields()
        {
            switch (this.Name)
            {
                case "Город":
                    {
                        // Определяем скрытые поля
                        break;
                    }
            }
        }
        private void InsEdit(int param)
        {
            int rowCount = dataGridView1.RowCount;
            if (rowCount != 0)
            {
                CurrentIndex = dataGridView1.CurrentRow.Index;
            }
            else
                if (param == 1)
            {
                MessageBox.Show("Нет данных для редактирования!");
            }
            switch (Name)
            {
                case "Город":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление города", this.sc.ConnectionString,
                                                   "City", "City");
                        else ed = new InsEditSprav("Изменение данных о городе", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "City", "City");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
            }
            dt.Clear();
            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;

            if (rowCount != 0)
            {
                dataGridView1.CurrentCell = rowCount == dataGridView1.RowCount ?
                    dataGridView1.Rows[CurrentIndex].Cells[dataGridView1.ColumnCount - 1] :
                    dataGridView1.Rows[rowCount].Cells[dataGridView1.ColumnCount - 1];
            }
        }

        private void InsTable_Click(object sender, EventArgs e)
        {
            InsEdit(0);
        }

        private void EditTable_Click(object sender, EventArgs e)
        {
            InsEdit(1);
        }

        private void CloseTable_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DelTable_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("Нет данных для удаления"); return;
            }

            if (dataGridView1.RowCount != 0 && dataGridView1.CurrentRow.Index != 0)
            {
                CurrentIndex = dataGridView1.CurrentRow.Index - 1;
            }

            sc.Open();
            try
            {
                command = new SQLiteCommand("DELETE * FROM [" + nameTable + "] WHERE ["
                                           + dt.Columns[0].ColumnName + "] = " +
                                           dt.Rows[dataGridView1.CurrentRow.Index][0], sc);
                command.ExecuteNonQuery();
                dt.Clear();
                a = new SQLiteDataAdapter(query, sc);
                a.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sc.Close();
            }

            if (dataGridView1.RowCount != 0)
            {
                dataGridView1.CurrentCell =
                    dataGridView1.Rows[CurrentIndex].Cells[dataGridView1.ColumnCount - 1];
            }
        }

    }
}
