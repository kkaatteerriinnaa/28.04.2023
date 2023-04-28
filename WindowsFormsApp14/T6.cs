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
    public partial class Task6 : Form
    {
        List<CompanyEmployees> employees = null;
        public Task6()
        {
            InitializeComponent();

            employees = new List<CompanyEmployees>
{
    new CompanyEmployees("Мельникова", "Ксения", "Витальевна", new DateTime(1985, 1, 1), "+380789456598", "Улица Шевченко", 8, "22"),
    new CompanyEmployees("Иванова", "София", "Ивановна", new DateTime(1986, 2, 5), "+380968534856", "Улица Леси Украинки", 19, "36"),
    new CompanyEmployees("Буракшаева", "Юлия", "Сергеевна", new DateTime(1987, 3, 2), "+380912035876", "Улица Мазепы", 27, "1"),
    new CompanyEmployees("Фурсова", "Елизавета", "Владимировна", new DateTime(1988, 4, 6), "+380968532671", "Улица Коперника", 81, "20"),
    new CompanyEmployees("Сапсай", "Иван", "Евгеньевич", new DateTime(1989, 5, 3), "+380225368014", "Улица Ломоносова", 67, "5"),
    new CompanyEmployees("Богословский", "Артем", "Григорьевич", new DateTime(1990, 6, 7), "+380168253074", "Улица Терещенкова", 32, "3"),
    new CompanyEmployees("Самбикина", "Юлия", "Валерьевна", new DateTime(1991, 7, 8), "+380365240855", "Улица Гринченка", 25, "10"),
    new CompanyEmployees("Шпак", "Ангелина", "Эдуардовна", new DateTime(1992, 8, 9), "+380147253204", "Улица Гагарина", 68, "14"),
    new CompanyEmployees("Пименов", "Максим", "Романович", new DateTime(1993, 9, 11), "+3801658642305", "Улица Каразина", 35, "22"),
    new CompanyEmployees("Сигида", "Валерия", "Михайлович", new DateTime(1994, 10, 12), "+380359648201", "Улица Мироносицкая", 24, "28"),
    new CompanyEmployees("Миронова", "Елизавета", "Георгиевна", new DateTime(1995, 11, 20), "+380350496250", "Улица Шевченко", 85, "30"),
    new CompanyEmployees("Безуглова", "Анастасия", "Дмитривена", new DateTime(1996, 12, 21), "+380302486953", "Улица Сагайдачного", 96, "13") };


            listView1.Columns.Add("Фамилия");
            listView1.Columns.Add("Имя");
            listView1.Columns.Add("Отчество");
            listView1.Columns.Add("Дата рождения");
            listView1.Columns.Add("Телефон");
            listView1.Columns.Add("Улица");
            listView1.Columns.Add("Номер дома");
            listView1.Columns.Add("Номер кв.");
            foreach (CompanyEmployees employee in employees)
            {
                ListViewItem item = new ListViewItem(employee.LastName);
                item.SubItems.Add(employee.FirstName);
                item.SubItems.Add(employee.MiddleName);
                item.SubItems.Add(employee.BirthDate.ToShortDateString());
                item.SubItems.Add(employee.Phone);
                item.SubItems.Add(employee.Street);
                item.SubItems.Add(employee.HouseNumber.ToString());
                item.SubItems.Add(employee.ApartmentNumber);

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
            string street = textBox1.Text;
            listView1.Items.Clear();
            int totalAge = 0;

            foreach (CompanyEmployees employee in employees)
            {
                if ((street == employee.Street) && (employee.HouseNumber % 2 == 0))
                {
                    ListViewItem item = new ListViewItem(employee.LastName);
                    totalAge += DateTime.Now.Year - employee.BirthDate.Year;
                    item.SubItems.Add(employee.FirstName);
                    item.SubItems.Add(employee.MiddleName);
                    item.SubItems.Add(employee.BirthDate.ToShortDateString());
                    item.SubItems.Add(employee.Phone);
                    item.SubItems.Add(employee.Street);
                    item.SubItems.Add(employee.HouseNumber.ToString());
                    item.SubItems.Add(employee.ApartmentNumber);

                    listView1.Items.Add(item);
                }
            }

            double averageAge = totalAge / listView1.Items.Count;
            MessageBox.Show($"Средний возраст сотрудников: {averageAge:F1} лет");

        }
    }
    class CompanyEmployees
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public CompanyEmployees(string lastName, string firstName, string middleName, DateTime birthDate, string phone, string street, int houseNumber, string apartmentNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
            Phone = phone;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }
    }


}