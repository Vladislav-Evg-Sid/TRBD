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
                        this.nameTable = "Transmission";
                        break;
                    }
                case "Парки":
                    {
                        query = "SELECT Park.ID_Park, Park.ID_City, Park.Street as [Улица], Park.House_Number as [Номер дома], Park.Start_Time as [Время начала работы], Park.End_Time as [Время окончания работы] FROM Park";
                        this.nameTable = "Park";
                        break;
                    }
                case "Сотрудники":
                    {
                        query = "SELECT Employee.ID_Employee, Employee.Employee_Surname as [Фамилия], Employee.Employee_Name as [Имя], Employee.Employee_Patronymic as [Отчество], Employee.Passport as [Серия и номер паспорта], Employee.INN as [ИНН], Employee.ID_Park FROM Employee";
                        this.nameTable = "Employee";
                        break;
                    }
                case "Автомобили":
                    {
                        query = "SELECT Auto.ID_Auto, Auto.ID_Brand, Auto.ID_Model, Auto.ID_Fuel, Auto.ID_Transmission, Auto.Rent_Price as [Цена аренды], Auto.Year as [Год производства], Auto.ID_Park, Auto.Fuel_Consumption as [Расход топлива] FROM Auto";
                        this.nameTable = "Auto";
                        break;
                    }
                case "Клиенты":
                    {
                        query = "SELECT Client.ID_Client, Client.Client_Surname as [Фамилия], Client.Client_Name as [Имя], Client.Client_Patronymic as [Отчество], Client.License as [Серия и номер ВУ], Client.Expirience as [Стаж], Client.Phone_Number as [Номер телефона], Client.Date_of_Birth as [Дата рождения] from Client";
                        this.nameTable = "Client";
                        break;
                    }
                case "Аренды":
                    {
                        query = "SELECT Rent.ID_Rent, Rent.ID_Employee, Rent.ID_Auto, Rent.Start_Date as [Дата начала аренды], Rent.End_Date as [Дата окончания аренды], Rent.Rent_Price as [Цена аренды за весь срок], Rent.Pledge as [Залог], Rent.ID_Status FROM Rent ";
                        this.nameTable = "Rent";
                        break;
                    }
                case "Список клиентов":
                    {
                        query = "SELECT C.ID_Client, C.Client_Surname AS [Фамилия], C.Client_Name AS [Имя], C.Client_Surname AS [Отчество] FROM Client as C";
                        this.nameTable = "Client_list";
                        break;
                    }
                case "Работа парков":
                    {
                        query = "SELECT P.ID_Park, C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер дома], P.Start_Time AS [Начало работы], P.End_Time AS [Конец работы] FROM Park as P JOIN City as C ON P.ID_City = C.ID_City;";
                        this.nameTable = "Park_Time";
                        break;
                    }
                case "Списки автомобилей в парках":
                    {
                        query = "SELECT A.ID_Auto, B.Brand AS [Марка], M.Model AS [Модель], C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер телефона] FROM Auto as A JOIN Brand as B ON A.ID_Brand = B.ID_Brand JOIN Model as M ON A.ID_Model = M.ID_Model JOIN City AS C ON P.ID_City = C.ID_City JOIN Park as P ON A.ID_Park = P.ID_Park"; 
                        this.nameTable = "Park_Cars";
                        break;
                    }
                case "Списки сотрудников в парках":
                    {
                        query = "SELECT E.ID_Employee, E.Employee_Surname AS [Фамилия], E.Employee_Name AS [Имя], E.Employee_Patronymic AS [Отчество], C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер дома] FROM Employee as E JOIN Park as P ON P.ID_Park = E.ID_Park JOIN City as C ON P.ID_City = C.ID_City";
                        this.nameTable = "Park_Employees";
                        break;
                    }
                case "Автомобили по клиентам":
                    {
                        query = "SELECT  C.Client_Surname AS [Фамилия], C.Client_Name AS [Имя],  C.Client_Patronymic AS [Отчество],  B.Brand AS [Марка], M.Model AS [Модель],  R.ID_Rent ,  R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды] FROM Client AS C JOIN Rent AS R  ON C.ID_Client = R.ID_Client JOIN Auto AS A  ON R.ID_Auto = A.ID_Auto JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M   ON A.ID_Model = M.ID_Model;";
                        this.nameTable = "Client_Auto";
                        break;
                    }
                case "Автомобили по сотрудникам":
                    {
                        query = "SELECT  E.Employee_Surname AS [Фамилия], E.Employee_Name AS [Имя], E.Employee_Patronymic AS [Отчество],  B.Brand AS [Марка],  M.Model AS [Модель], R.ID_Rent,  R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды] FROM Employee AS E JOIN Rent AS R  ON E.ID_Employee = R.ID_Employee JOIN Auto AS A  ON R.ID_Auto = A.ID_Auto JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model;";
                        this.nameTable = "Employee_Auto";
                        break;
                    }
                case "Аренда автомобиля":
                    {
                        query = "SELECT  A.ID_Auto,  B.Brand AS [Марка],  M.Model AS [Модель],  R.ID_Rent , R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды" +
                            "" +
                            "] FROM Auto AS A JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model JOIN Rent AS R  ON A.ID_Auto = R.ID_Auto;";
                        this.nameTable = "Rent_Auto";
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
