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
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class Table : Form
    {
        private SQLiteConnection sc = new SQLiteConnection();
        private SQLiteDataAdapter a;
        private SQLiteCommand command = new SQLiteCommand();
        private DataTable dt = new DataTable();

        private string nameTable;
        private string nameID;
        private string query;

        private int CurrentIndex = 0;

        private bool IsReportTable = false;

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
                        query = "SELECT Brand.ID_Brand AS [ID], Brand.Brand AS [Марка], Brand.Brand AS [ForFilter] FROM Brand";
                        this.nameTable = "Brand";
                        this.nameID = "ID_Brand";
                        break;
                    }
                case "Город":
                    {
                        query = "SELECT City.ID_City AS [ID], City.City AS [Город], City.City AS [ForFilter] FROM City";
                        this.nameTable = "City";
                        this.nameID = "ID_City";
                        break;
                    }
                case "Тип топлива":
                    {
                        query = "SELECT Fuel_Type.ID_Fuel AS [ID], Fuel_Type.Fuel AS [Тип топлива], Fuel_Type.Fuel AS [ForFilter] FROM Fuel_Type";
                        this.nameTable = "Fuel_Type";
                        this.nameID = "ID_Fuel";
                        break;
                    }
                case "Модель":
                    {
                        query = "SELECT Model.ID_Model AS [ID], Model.Model AS [Модель], Model.Model AS [ForFilter] FROM Model";
                        this.nameTable = "Model";
                        this.nameID = "ID_Model";
                        break;
                    }
                case "Статус аренды":
                    {
                        query = "SELECT Rent_Status.ID_Status AS [ID], Rent_Status.Status AS [Статус аренды], Rent_Status.Status AS [ForFilter] FROM Rent_Status";
                        this.nameTable = "Rent_Status";
                        this.nameID = "ID_Status";
                        break;
                    }
                case "Трансмиссия":
                    {
                        query = "SELECT Transmission.ID_Transmission AS [ID], Transmission.Transmission AS [Трансмисся], Transmission.Transmission AS [ForFilter] FROM Transmission";
                        this.nameTable = "Transmission";
                        this.nameID = "ID_Transmission";
                        break;
                    }
                case "Парки":
                    {
                        query = "SELECT Park.ID_Park AS [ID], Park.ID_City, City.City AS [Город], Park.Street as [Улица], Park.House_Number as [Номер дома], Park.Start_Time as [Время начала работы], Park.End_Time as [Время окончания работы], City.City || ', ' || Park.Street || ' ' || Park.House_Number AS [ForFilter] FROM Park JOIN City ON Park.ID_City = City.ID_City";
                        this.nameTable = "Park";
                        this.nameID = "ID_Park";
                        break;
                    }
                case "Сотрудники":
                    {
                        query = "SELECT Employee.ID_Employee AS [ID], Park.ID_Park, Employee.Employee_Surname as [Фамилия], Employee.Employee_Name as [Имя], Employee.Employee_Patronymic as [Отчество], Employee.Passport as [Паспорт], Employee.INN as [ИНН], City.City AS [Город парка], Park.Street AS [Улица парка], Employee.Employee_Surname || ' ' || Employee.Employee_Name || ' ' || Employee.Employee_Patronymic AS [ForFilter] FROM Employee JOIN Park ON Employee.ID_Park = Park.ID_Park JOIN City ON Park.ID_City = City.ID_city";
                        this.nameTable = "Employee";
                        this.nameID = "ID_Employee";
                        break;
                    }
                case "Автомобили":
                    {
                        query = "SELECT Auto.ID_Auto AS [ID], Brand.ID_Brand, Model.ID_Model, Fuel_Type.ID_Fuel, Transmission.ID_Transmission, Park.ID_Park, Brand.Brand AS [Марка], Model.Model AS [Модель], Fuel_Type.Fuel AS [Топливо], Transmission.Transmission AS [Трансмиссия], Auto.Rent_Price as [Цена аренды], Auto.Year as [Год производства], City.City AS [Город парка], Park.Street AS [Улица], Park.House_Number AS [Номер дома], Auto.Fuel_Consumption as [Расход топлива], Brand.Brand || ' ' || Model.Model AS [ForFilter] FROM Auto JOIN Park ON Auto.ID_Park = Park.ID_Park JOIN City ON City.ID_City = Park.ID_City JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model JOIN Transmission ON Auto.ID_Transmission = Transmission.ID_Transmission JOIN Fuel_Type ON Auto.ID_Fuel = Fuel_Type.ID_Fuel";
                        this.nameTable = "Auto";
                        this.nameID = "ID_Auto";
                        break;
                    }
                case "Клиенты":
                    {
                        query = "SELECT Client.ID_Client AS [ID], Client.Client_Surname as [Фамилия], Client.Client_Name as [Имя], Client.Client_Patronymic as [Отчество], Client.License as [ВУ], Client.Expirience as [Стаж], Client.Phone_Number as [Номер телефона], Client.Date_of_Birth as [Дата рождения], Client.Client_Surname || ' ' || Client.Client_Name || ' ' || Client.Client_Patronymic AS [ForFilter] from Client";
                        this.nameTable = "Client";
                        this.nameID = "ID_Client";
                        break;
                    }
                case "Аренды":
                    {
                        query = "SELECT Rent.ID_Rent AS [ID], Employee.ID_Employee, Client.ID_Client, Auto.ID_Auto, Rent_Status.ID_Status, Rent.ID_Employee AS [Номер сутрудника], Employee.Employee_Surname AS [Фамилия сотрудника], Rent.ID_Client AS [Номер клиента], Client.Client_Surname AS [Фамилия клиента], Brand.Brand AS [Марка], Model.Model AS [Модель], Rent.Start_Date as [Дата начала аренды], Rent.End_Date as [Дата окончания аренды], Rent.Rent_Price as [Стоимость аренды], Rent.Pledge as [Залог], Rent_Status.Status AS [Статус аренды], Brand.Brand || ' ' || Model.Model AS [ForFilter] FROM Rent JOIN Rent_Status ON Rent.ID_Status = Rent_Status.ID_Status JOIN Employee ON Rent.ID_Employee = Employee.ID_Employee JOIN Client ON Rent.ID_Client = Client.ID_Client JOIN Auto ON Rent.ID_Auto = Auto.ID_Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model";
                        this.nameTable = "Rent";
                        this.nameID = "ID_Rent";
                        break;
                    }
                case "Список клиентов":
                    {
                        query = "SELECT C.ID_Client AS [Номер клиента], C.Client_Surname AS [Фамилия], C.Client_Name AS [Имя], C.Client_Patronymic AS [Отчество], C.Client_Surname || ' ' || C.Client_Name || ' ' || C.Client_Patronymic AS [ForFilter] FROM Client as C";
                        this.nameTable = "Client_list";
                        IsReportTable = true;
                        break;
                    }
                case "Работа парков":
                    {
                        query = "SELECT P.ID_Park AS [Номер парка], C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер дома], Brand.Brand AS [Марка автомолбиля], Model.Model AS [Модель автомобиля], Employee.Employee_Surname AS [Фамилия сотрудника], Client.Client_Surname AS [Фамилия клиента], Rent.ID_Rent AS [Номер аренды], C.City || ', ' || P.Street || ' ' || P.House_Number AS [ForFilter] FROM Park as P JOIN City as C ON P.ID_City = C.ID_City JOIN Employee ON P.ID_Park = Employee.ID_Park JOIN Rent ON Employee.ID_employee = Rent.ID_Employee JOIN Client ON Client.ID_Client = Rent.ID_Client JOIN Auto ON Auto.ID_Auto = Rent.ID_Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model";
                        this.nameTable = "Park_Time";
                        IsReportTable = true;
                        break;
                    }
                case "Списки автомобилей в парках":
                    {
                        query = "SELECT P.ID_Park AS [номер парка], C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер дома/км], A.ID_Auto AS [Номер автомобиля], B.Brand AS [Марка], M.Model AS [Модель], C.City || ', ' || P.Street || ' ' || P.House_Number AS [ForFilter] FROM Park as P JOIN City AS C ON P.ID_City = C.ID_City JOIN Auto as A ON P.ID_Park = A.ID_Park JOIN Brand as B ON A.ID_Brand = B.ID_Brand JOIN Model as M ON A.ID_Model = M.ID_Model";
                        this.nameTable = "Park_Cars";
                        IsReportTable = true;
                        break;
                    }
                case "Списки сотрудников в парках":
                    {
                        query = "SELECT P.ID_Park AS [номер парка], C.City AS [Город], P.Street AS [Улица], P.House_Number AS [Номер дома/км], E.ID_Employee AS [Номер сотрудника], E.Employee_Surname AS [Фамилия], E.Employee_Name AS [Имя], E.Employee_Patronymic AS [Отчество], C.City || ', ' || P.Street || ' ' || P.House_Number AS [ForFilter] FROM Park as P JOIN City as C ON P.ID_City = C.ID_City JOIN Employee as E ON P.ID_Park = E.ID_Park";
                        this.nameTable = "Park_Employees";
                        IsReportTable = true;
                        break;
                    }
                case "Автомобили по клиентам":
                    {
                        query = "SELECT C.Client_Surname AS [Фамилия], C.Client_Name AS [Имя], C.Client_Patronymic AS [Отчество], B.Brand AS [Марка], M.Model AS [Модель], R.ID_Rent AS [Номер аренды],  R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды], C.Client_Surname || ' ' || C.Client_Name || ' ' || C.Client_Patronymic AS [ForFilter] FROM Client AS C JOIN Rent AS R ON C.ID_Client = R.ID_Client JOIN Auto AS A ON R.ID_Auto = A.ID_Auto JOIN Brand AS B ON A.ID_Brand = B.ID_Brand JOIN Model AS M ON A.ID_Model = M.ID_Model;";
                        this.nameTable = "Client_Auto";
                        IsReportTable = true;
                        break;
                    }
                case "Автомобили по сотрудникам":
                    {
                        query = "SELECT E.Employee_Surname AS [Фамилия], E.Employee_Name AS [Имя], E.Employee_Patronymic AS [Отчество], B.Brand AS [Марка], M.Model AS [Модель], R.ID_Rent AS [Номер аренды],  R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды], E.Employee_Surname || ' ' || E.Employee_Name || ' ' || E.Employee_Patronymic AS [ForFilter] FROM Employee AS E JOIN Rent AS R  ON E.ID_Employee = R.ID_Employee JOIN Auto AS A  ON R.ID_Auto = A.ID_Auto JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model;";
                        this.nameTable = "Employee_Auto";
                        IsReportTable = true;
                        break;
                    }
                case "Аренда автомобиля":
                    {
                        query = "SELECT  A.ID_Auto AS [Номер автомобиля],  B.Brand AS [Марка],  M.Model AS [Модель],  R.ID_Rent AS [Номер аренды], R.Start_Date AS [Дата начала аренды],  R.End_Date AS [Дата окончания аренды], B.Brand || ' ' || M.Model AS [ForFilter] " +
                            "FROM Auto AS A JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model JOIN Rent AS R  ON A.ID_Auto = R.ID_Auto;";
                        this.nameTable = "Rent_Auto";
                        IsReportTable = true;
                        break;
                    }
            }
            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            HideFields();
        }
        private void HideFields()
        {
            dataGridView1.Columns["ForFilter"].Visible = false;
            if (!IsReportTable)
            {
                this.ReportTable.Available = false;
                dataGridView1.Columns["ID"].Visible = false;
                switch (this.Name)
                {
                    case "Парки":
                        {
                            dataGridView1.Columns["ID_CIty"].Visible = false;
                            break;
                        }
                    case "Сотрудники":
                        {
                            dataGridView1.Columns["ID_Park"].Visible = false;
                            break;
                        }
                    case "Автомобили":
                        {
                            dataGridView1.Columns["ID_Brand"].Visible = false;
                            dataGridView1.Columns["ID_Model"].Visible = false;
                            dataGridView1.Columns["ID_Fuel"].Visible = false;
                            dataGridView1.Columns["ID_Transmission"].Visible = false;
                            dataGridView1.Columns["ID_Park"].Visible = false;
                            break;
                        }
                    case "Аренды":
                        {
                            dataGridView1.Columns["ID_Employee"].Visible = false;
                            dataGridView1.Columns["ID_Client"].Visible = false;
                            dataGridView1.Columns["ID_Auto"].Visible = false;
                            dataGridView1.Columns["ID_Status"].Visible = false;
                            break;
                        }
                }
            }
            else
            {
                this.InsTable.Available = false;
                this.EditTable.Available = false;
                this.DelTable.Available = false;
            }
        }

        private void InsEdit(int param)
        {
            int rowCount = dataGridView1.RowCount;
            if (dt.Rows.Count > dataGridView1.CurrentRow.Index)
            {
                CurrentIndex = dataGridView1.CurrentRow.Index;
            }
            else
                if (param == 1)
            {
                MessageBox.Show("Нет данных для редактирования!");
                return;
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
                case "Парки":
                    {
                        insEditPark ed;
                        if (param == 0) ed = new insEditPark("Название города", this.sc.ConnectionString);
                    
                        else ed = new insEditPark("Изменение данных об улице ", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Сотрудники":
                    {
                        insEditEmployee ed;
                        if (param == 0) ed = new insEditEmployee("Сотрудники", this.sc.ConnectionString);

                        else ed = new insEditEmployee("", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Клиенты":
                    {
                        insEditClient ed;
                        if (param == 0) ed = new insEditClient("Клиенты", this.sc.ConnectionString);

                        else ed = new insEditClient("", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Автомобили":
                    {
                        insEditAuto ed;
                        if (param == 0) ed = new insEditAuto("Автомобили", this.sc.ConnectionString);

                        else ed = new insEditAuto("", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index]);
                        ed.Tag = param;
                        ed.ShowDialog();
                        break;
                    }
                case "Аренды":
                    {
                        insEditRent ed;
                        if (param == 0) ed = new insEditRent("Аренды", this.sc.ConnectionString);

                        else ed = new insEditRent("", this.sc.ConnectionString,
                                                   dt.Rows[dataGridView1.CurrentRow.Index]);
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
                    dataGridView1.Rows[CurrentIndex].Cells[dataGridView1.ColumnCount - 2] :
                    dataGridView1.Rows[rowCount].Cells[dataGridView1.ColumnCount - 2];
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
                using (TransactionScope scope = new TransactionScope())
                {
                    command = new SQLiteCommand("DELETE FROM [" + nameTable + "] WHERE ["
                                                + this.nameID + "] = " +
                                                dt.Rows[dataGridView1.CurrentRow.Index][0], sc);
                    command.ExecuteNonQuery();
                    dt.Clear();
                    a = new SQLiteDataAdapter(query, sc);
                    a.Fill(dt);
                    dataGridView1.DataSource = dt;
                    string[] list2apd = new string[] { "Парки", "Сотрудники", "Автомобили", "Клиенты", "Аренды", "Список клиентов", "Работа парков", "Списки автомобилей в парках", "Списки сотрудников в парках", "Автомобили по клиентам", "Автомобили по сотрудникам", "Аренда автомобиля" };
                    foreach (Form f in Application.OpenForms)
                    {
                        if (list2apd.Contains(f.Text))
                        {
                            ((Table)f).Apdate();
                        }
                    }
                }
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
                    dataGridView1.Rows[CurrentIndex].Cells[dataGridView1.ColumnCount - 2];
            }
        }

        private void ReportTable_Click(object sender, EventArgs e)
        {
            int number = 0;
            switch (this.Name)
            {
                case "Список клиентов":
                    {
                        number = 1;
                        break;
                    }
                case "Работа парков":
                    {
                        number = 2;
                        break;
                    }
                case "Списки автомобилей в парках":
                    {
                        number = 3;
                        break;
                    }
                case "Списки сотрудников в парках":
                    {
                        number = 4;
                        break;
                    }
                case "Автомобили по клиентам":
                    {
                        number = 5;
                        break;
                    }
                case "Автомобили по сотрудникам":
                    {
                        number = 6;
                        break;
                    }
                case "Аренда автомобиля":
                    {
                        number = 7;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            CreateReport rep = new CreateReport(number, this.sc.ConnectionString);
            rep.Text = this.Name;
            rep.ShowDialog();
        }

        public void Apdate()
        {
            dt.Clear();
            a = new SQLiteDataAdapter(query, sc);
            a.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Change_Filter(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "ForFilter like '%" + toolStripTextBox1.Text + "%'";
            dataGridView1.DataSource = bs;
        }
    }
}
