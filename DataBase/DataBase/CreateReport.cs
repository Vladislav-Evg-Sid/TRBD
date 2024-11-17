using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
//using Word = Microsoft.Office.Interop.Word;
using PDF = Aspose.Pdf;
using System.Data.SQLite;
using Microsoft.Office.Core;
using Aspose.Pdf.Text;
using Aspose.Pdf.AI;
/*
namespace DataBase
{
    public partial class CreateReport : Form
    {
        private SQLiteConnection sc = new SQLiteConnection();
        private SQLiteDataAdapter a;
        private DataSet tmp;
        private DataTable dt = new DataTable();
        private string query;

        public CreateReport(int rep, string ConnectionString)
        {
            InitializeComponent();
            sc = new SQLiteConnection();
            this.sc.ConnectionString = ConnectionString;
            tmp = new DataSet();
            comboBox1.SelectedIndex = 1;
            Tag = rep;
            if (rep == 1)
            {
                label2.Visible = false;
                comboBox2.Visible = false;
            }
            else if (rep < 5)
            {
                label2.Text = "Выбирите парк:";
                tmp.Tables.Add(new DataTable("Park"));
                query = "SELECT Park.ID_Park, City.City || ', ' || Park.Street || ', ' || Park.House_Number AS [ParkName] FROM Park JOIN City ON Park.ID_City = City.ID_City";
                a = new SQLiteDataAdapter(query, sc);
                a.Fill(tmp.Tables["Park"]);
                if (tmp.Tables["Park"].Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчёта"); Close();
                }
                comboBox2.DisplayMember = tmp.Tables["Park"].Columns["ParkName"].ToString();
                comboBox2.ValueMember = tmp.Tables["Park"].Columns["ID_Park"].ToString();
                comboBox2.DataSource = tmp.Tables["Park"];
            }
            else if (rep == 5)
            {
                label2.Text = "Выбирите клиента:";
                tmp.Tables.Add(new DataTable("Client"));
                query = "SELECT Client.ID_Client, Client.Client_Surname || ' ' || SUBSTR(Client.Client_Name, 1, 1) || '.' || SUBSTR(Client.Client_Patronymic, 1, 1) AS [ClientName] FROM Client";
                a = new SQLiteDataAdapter(query, sc);
                a.Fill(tmp.Tables["Client"]);
                if (tmp.Tables["Client"].Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчёта"); Close();
                }
                comboBox2.DisplayMember = tmp.Tables["Client"].Columns["ClientName"].ToString();
                comboBox2.ValueMember = tmp.Tables["Client"].Columns["ID_Client"].ToString();
                comboBox2.DataSource = tmp.Tables["Client"];
            }
            else if (rep == 6)
            {
                label2.Text = "Выбирите сотрудника:";
                tmp.Tables.Add(new DataTable("Employee"));
                query = "SELECT ID_Employee, Employee_Surname || ' ' || SUBSTR(Employee_Name, 1, 1) || '.' || SUBSTR(Employee_Patronymic, 1, 1) AS [EmployeeName] FROM Employee";
                a = new SQLiteDataAdapter(query, sc);
                a.Fill(tmp.Tables["Employee"]);
                if (tmp.Tables["Employee"].Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчёта"); Close();
                }
                comboBox2.DisplayMember = tmp.Tables["Employee"].Columns["EmployeeName"].ToString();
                comboBox2.ValueMember = tmp.Tables["Employee"].Columns["ID_Employee"].ToString();
                comboBox2.DataSource = tmp.Tables["Employee"];
            }
            else if (rep == 7)
            {
                label2.Text = "Выбирите автомобиль:";
                tmp.Tables.Add(new DataTable("Auto"));
                query = "SELECT ID_Auto, ID_Auto || '. ' || Brand || ' ' || Model AS [AutoName] FROM Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model";
                a = new SQLiteDataAdapter(query, sc);
                a.Fill(tmp.Tables["Auto"]);
                if (tmp.Tables["Auto"].Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для формирования отчёта"); Close();
                }
                comboBox2.DisplayMember = tmp.Tables["Auto"].Columns["AutoName"].ToString();
                comboBox2.ValueMember = tmp.Tables["Auto"].Columns["ID_Auto"].ToString();
                comboBox2.DataSource = tmp.Tables["Auto"];
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Close();
        }

        private void Create_Report(object sender, EventArgs e)
        {
            string path = @"E:\Проги\git\Лабы\Отчёт";
            string typeFile = comboBox1.SelectedItem.ToString();
            int indCB = 0;
            string textCB = "";
            if ((int)Tag > 1)
            {
                indCB = int.Parse(comboBox2.SelectedValue.ToString());
                textCB = comboBox2.Text.ToString();
            }

            Task MakeReport = Task.Run(async () =>
            {
                string[] ColNames = new string[] { "" };
                string FirstLine = "";
                if ((int)Tag == 1)
                {
                    query = "SELECT C.Client_Surname AS [1], C.Client_Name AS [2], C.Client_Patronymic AS [3] FROM Client as C";
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Фамилия", "Имя", "Отчество" };
                    FirstLine = "Список клиентов";
                }
                else if ((int)Tag == 2)
                {
                    query = "SELECT Brand.Brand AS [1], Model.Model AS [2], Employee.Employee_Surname AS [3], Client.Client_Surname AS [4]" +
                            "FROM Park JOIN Employee ON Park.ID_Park = Employee.ID_Park JOIN Rent ON Employee.ID_employee = Rent.ID_Employee JOIN Client ON Client.ID_Client = Rent.ID_Client JOIN Auto ON Auto.ID_Auto = Rent.ID_Auto JOIN Brand ON Auto.ID_Brand = Brand.ID_Brand JOIN Model ON Auto.ID_Model = Model.ID_Model " +
                            "WHERE Park.ID_Park = " + indCB;
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Марка автомобиля", "Модель автомобиля", "Фамилия сотрудника", "Фамилия клиента" };
                    FirstLine = "Парк номер " + indCB + ". Адрес парка: " + textCB;
                }
                else if ((int)Tag == 3)
                {
                    query = "SELECT B.Brand AS [1], M.Model AS [2]" +
                            "FROM Park as P JOIN Auto as A ON P.ID_Park = A.ID_Park JOIN Brand as B ON A.ID_Brand = B.ID_Brand JOIN Model as M ON A.ID_Model = M.ID_Model " +
                            "WHERE P.ID_Park = " + indCB;
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Марка автомобиля", "Модель автомобиля" };
                    FirstLine = "Парк номер " + indCB + ". Адрес парка: " + textCB;
                }
                else if ((int)Tag == 4)
                {
                    query = "SELECT E.Employee_Surname AS [1], E.Employee_Name AS [2], E.Employee_Patronymic AS [3]" +
                            "FROM Park as P JOIN Employee as E ON P.ID_Park = E.ID_Park " +
                            "WHERE P.ID_Park = " + indCB;
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Фамилия", "Имя", "Отчество" };
                    FirstLine = "Парк номер " + indCB + ". Адрес парка: " + textCB;
                }
                else if ((int)Tag == 5)
                {
                    query = "SELECT B.Brand AS [1], M.Model AS [2], R.Start_Date AS [3], R.End_Date AS [4] " +
                            "FROM Client AS C JOIN Rent AS R ON C.ID_Client = R.ID_Client JOIN Auto AS A ON R.ID_Auto = A.ID_Auto JOIN Brand AS B ON A.ID_Brand = B.ID_Brand JOIN Model AS M ON A.ID_Model = M.ID_Model " +
                            "WHERE C.ID_Client = " + indCB;

                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Марка", "Модель", "Дата начала аренды", "Дата окончания аренды" };
                    FirstLine = "Клиент номер " + indCB + ". ФИО: " + textCB;
                }
                else if ((int)Tag == 6)
                {
                    query = "SELECT B.Brand AS [1], M.Model AS [2], R.Start_Date AS [3],  R.End_Date AS [4] " +
                            "FROM Employee AS E JOIN Rent AS R ON E.ID_Employee = R.ID_Employee JOIN Auto AS A ON R.ID_Auto = A.ID_Auto JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model " +
                            "WHERE E.ID_Employee = " + indCB;
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Марка", "Модель", "Дата начала аренды", "Дата окончания аренды" };
                    FirstLine = "Сотрудник номер " + indCB + ". ФИО: " + textCB;
                }
                else if ((int)Tag == 7)
                {
                    query = "SELECT R.Start_Date AS [1],  R.End_Date AS [2]" +
                            "FROM Auto AS A JOIN Brand AS B  ON A.ID_Brand = B.ID_Brand JOIN Model AS M  ON A.ID_Model = M.ID_Model JOIN Rent AS R  ON A.ID_Auto = R.ID_Auto " +
                            "WHERE A.ID_Auto = " + indCB;
                    a = new SQLiteDataAdapter(query, sc);
                    dt.Clear();
                    a.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет данных для анализа"); return;
                    }
                    ColNames = new string[] { "Дата начала аренды", "Дата окончания аренды" };
                    FirstLine = "Автомобмль номер " + indCB + ". Марка, модель: " + string.Join(" ", textCB.Split('.').Skip(1).ToArray());
                }
                else
                {
                    return;
                }

                if (typeFile == "Excel")
                {
                    CreateRep_Excel(path, FirstLine, ColNames);
                }
                else if (typeFile == "Word")
                {
                    CreateRep_Word(path, FirstLine, ColNames);
                }
                else
                {
                    CreateRep_PDF(path, FirstLine, ColNames);
                }
            });
        }

        private void CreateRep_Excel(string path, string FirstLine, string[] ColNames)
        {
            Excel.Application ObjExcel = new Excel.Application();
            Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];

            ObjWorkSheet.Cells[1, 1] = FirstLine;
            for (int i=1;i<= ColNames.Length; i++)
            {
                ObjWorkSheet.Cells[2, i] = ColNames[i-1];
            }

            for (int _row = 0; _row < dt.Rows.Count; _row++)
            {
                DataRow dr = dt.Rows[_row];
                for (int i=1;i<= ColNames.Length; i++)
                {
                    ObjWorkSheet.Cells[_row + 3, i] = dr[i.ToString()].ToString();
                }
            }

            try
            {
                ObjWorkBook.SaveAs(path + Tag + ".xlsx");
                ObjExcel.Quit();
                MessageBox.Show("Отчёт сформирован");
            }
            catch { }
        }

        private void CreateRep_Word(string path, string FirstLine, string[] ColNames)
        {
            Word.Application wrdApp = new Word.Application();
            Word.Document wrdDoc = wrdApp.Documents.Add();
            Word.Range range = wrdDoc.Range();
            range.InsertAfter(FirstLine);
            range.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
            Word.Table wrdTable = wrdDoc.Tables.Add(range, dt.Rows.Count + 1, ColNames.Length);
            wrdTable.Borders.Enable = 1;

            for (int i = 1; i <= ColNames.Length; i++)
            {
                wrdTable.Cell(1, i).Range.InsertAfter(ColNames[i-1]);
            }

            for (int _row = 0; _row < dt.Rows.Count; _row++)
            {
                DataRow dr = dt.Rows[_row];
                for (int i = 1; i <= ColNames.Length; i++)
                {
                    wrdTable.Cell(_row + 2, i).Range.InsertAfter(dr[i.ToString()].ToString());
                }
            }

            wrdDoc.Saved = true;
            wrdDoc.SaveAs(path + Tag + ".docx");
            wrdDoc.Close();
            wrdApp.Quit();
            wrdDoc = null;
            wrdApp = null;
            MessageBox.Show("Отчёт сформирован");
        }
    
        private void CreateRep_PDF(string path, string FirstLine, string[] ColNames)
        {
            PDF.Document pdfDoc = new PDF.Document();
            PDF.Page page = pdfDoc.Pages.Add();
            PDF.Table table = new PDF.Table();
            TextFragment textFragment = new TextFragment(FirstLine);

            table.ColumnWidths = "";
            double procents = 100.0 / ColNames.Length;
            for (int i=0;i< ColNames.Length; i++)
            {
                table.ColumnWidths = table.ColumnWidths + procents + "% ";
            }
            table.DefaultCellBorder = new PDF.BorderInfo(PDF.BorderSide.All, 0.5f, PDF.Color.FromRgb(System.Drawing.Color.LightGray)); // задает обводку ячеек таблицы
            table.Border = new PDF.BorderInfo(PDF.BorderSide.All, 0.5f, PDF.Color.FromRgb(System.Drawing.Color.LightGray)); // задает обводку таблицы

            textFragment.Position = new Position(100, 780);
            textFragment.TextState.FontSize = 12;
            textFragment.TextState.Font = FontRepository.FindFont("TimesNewRoman");
            textFragment.TextState.BackgroundColor = PDF.Color.FromRgb(System.Drawing.Color.White);
            textFragment.TextState.ForegroundColor = PDF.Color.FromRgb(System.Drawing.Color.Black);
            TextBuilder textBuilder = new TextBuilder((PDF.Page)pdfDoc.Pages[1]);
            textBuilder.AppendText(textFragment);

            table.Rows.Add();
            for (int i = 0; i < ColNames.Length; i++)
            {
                table.Rows[0].Cells.Add(ColNames[i]);
            }

            for (int _row = 0; _row < dt.Rows.Count; _row++)
            {
                DataRow dr = dt.Rows[_row];
                table.Rows.Add();
                for (int i = 1; i <= ColNames.Length; i++)
                {
                    table.Rows[_row + 1].Cells.Add(dr[i.ToString()].ToString());
                }
            }
            page.Paragraphs.Add(table);
            pdfDoc.Save(path + Tag + ".pdf");
            pdfDoc.Dispose();
            MessageBox.Show("Отчёт сформирован");
        }
    }
}
*/