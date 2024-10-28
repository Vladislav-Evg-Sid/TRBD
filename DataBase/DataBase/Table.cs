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
                case "Марка":
                    {
                        query = "SELECT Brand.ID_Brand, Brand.Brand AS [Марка] FROM Brand";
                        this.nameTable = "Brand";
                        break;
                    }
                case "Город":
                    {
                        query = "SELECT City.ID_City, City.City AS [Город] FROM City";
                        this.nameTable = "City";
                        break;
                    }
                case "Тип топлива":
                    {
                        query = "SELECT Fuel_Type.ID_Fuel, Fuel_Type.Fuel AS [Тип топлива] FROM Fuel_Type";
                        this.nameTable = "Fuel_Type";
                        break;
                    }
                case "Модель":
                    {
                        query = "SELECT Model.ID_Model, Model.Model AS [Модель] FROM Model";
                        this.nameTable = "Model";
                        break;
                    }
                case "Статус аренды":
                    {
                        query = "SELECT Rent_Status.ID_Status, Rent_Status.Status AS [Статус аренды] FROM Rent_Status";
                        this.nameTable = "Rent_Status";
                        break;
                    }
                case "Трансмиссия":
                    {
                        query = "SELECT Transmission.ID_Transmission, Transmission.Transmission AS [Трансмисся] FROM Transmission";
                        this.nameTable = "Rent_Status";
                        break;
                    }
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
                case "Марка":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление марки", this.sc.ConnectionString,
                                                   "Brand", "Brand");
                        else ed = new InsEditSprav("Изменение данных о марке", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "Brand", "Brand", "марки");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Город":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление города", this.sc.ConnectionString,
                                                   "City", "City");
                        else ed = new InsEditSprav("Изменение данных о городе", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "City", "City", "города");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Тип топлива":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление топлива", this.sc.ConnectionString,
                                                   "Fuel_Type", "Fuel");
                        else ed = new InsEditSprav("Изменение данных о топливе ", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "Fuel_Type", "Fuel", "топлива");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Модель":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление модели", this.sc.ConnectionString,
                                                   "Model", "Model");
                        else ed = new InsEditSprav("Изменение данных о модели ", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "Model", "Model", "модели");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Статус аренды":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление статуса", this.sc.ConnectionString,
                                                   "Rent_Status", "Status");
                        else ed = new InsEditSprav("Изменение данных о статусе ", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "Rent_Status", "Status", "статуса");
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Трансмиссия":
                    {
                        InsEditSprav ed;
                        if (param == 0) ed = new InsEditSprav("Добавление трансмиссии", this.sc.ConnectionString,
                                                   "Transmission", "Transmission");
                        else ed = new InsEditSprav("Изменение данных о трансмиссии ", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index], "Transmission", "Transmission", "трансмиссии");
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
                command = new SQLiteCommand("DELETE FROM [" + nameTable + "] WHERE ["
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
