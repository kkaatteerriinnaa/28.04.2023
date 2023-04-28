using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Different_tasks_async_await_
{
    public partial class Task7 : Form
    {
        List<CompanyEmployees2> employees2 = null;
        public Task7()
        {
            InitializeComponent();
            employees2 = new List<CompanyEmployees2>
            {
                new CompanyEmployees2("Мельникова", "Ксения", "Витальевна", new DateTime(1985, 7, 15), "Одесса"),
                new CompanyEmployees2("Иванова", "София", "Ивановна", new DateTime(1993, 1, 20), "Днепр"),
                new CompanyEmployees2("Буракшаева", "Юлия", "Сергеевна", new DateTime(1988, 11, 3), "Запорожье"),
                new CompanyEmployees2("Фурсова", "Елизавета", "Владимировна", new DateTime(1992, 6, 25), "Днепр"),
                new CompanyEmployees2("Сапсай", "Иван", "Евгеньевич", new DateTime(1987, 9, 14), "Киев"),
                new CompanyEmployees2("Богословский", "Артем", "Григорьевич", new DateTime(1991, 3, 18), "Киев"),
                new CompanyEmployees2("Самбикина", "Юлия", "Валерьевна", new DateTime(1986, 8, 7), "Днепр"),
                new CompanyEmployees2("Шпак", "Ангелина", "Эдуардовна", new DateTime(1994, 4, 28), "Запорожье"),
                new CompanyEmployees2("Пименов", "Максим", "Романович", new DateTime(1989, 12, 9), "Одесса"),
                new CompanyEmployees2("Миронова", "Елизавета", "Георгиевна", new DateTime(1995, 2, 22), "Днепр")
            };
            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Место рождения");
            foreach (CompanyEmployees2 employee in employees2)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.LivePlase);
                listView1.Items.Add(item);
            }
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                button1.Enabled = false;

        }
        public async Task FinalCount()
        {
            int year = int.Parse(textBox1.Text);
            listView1.Items.Clear();

            foreach (CompanyEmployees2 employee in employees2)
            {
                if (year == employee.BirthDate.Year)
                {
                    ListViewItem row = new ListViewItem("Введённый вами год");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
            foreach (CompanyEmployees2 employee in employees2)
            {
                if (employee.BirthDate.Year == 1985)
                {
                    ListViewItem row = new ListViewItem("Сотрудник рожденный в год быка");
                    row.SubItems.Add("");
                    row.SubItems.Add("");
                    listView1.Items.Add(row);

                    ListViewItem item = new ListViewItem(employee.LastName);
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.LivePlase);
                    listView1.Items.Add(item);
                }
            }
        }
    }
    class CompanyEmployees2
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string LivePlase { get; set; }

        public CompanyEmployees2(string lastName, string firstName, string middleName, DateTime birthDate, string livePlase)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            LivePlase = livePlase;
        }
    }
}