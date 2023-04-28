using System;
using System.Collections;
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
    public partial class Task8 : Form
    {
        List<Student> students = null;
        public Task8()
        {
            InitializeComponent();

            Student s1 = new Student("Мельникова К.В.", "Группа КН-212", 82, 76, 92, new DateTime(2023, 1, 2));
            Student s2 = new Student("Иванова С.И.", "Группа КН-212", 70, 75, 79, new DateTime(2023, 1, 3));
            Student s3 = new Student("Буракшаева Ю.С.", "Группа КН-212", 74, 81, 93, new DateTime(2023, 1, 4));
            Student s4 = new Student("Фурсова Е.В.", "Группа КН-212", 85, 95, 77, new DateTime(2023, 1, 5));
            Student s5 = new Student("Сапсай И.Е.", "Группа КН-212", 78, 86, 84, new DateTime(2023, 1, 6));
            Student s6 = new Student("Богословский А.Г.", "Группа КН-212", 97, 84, 89, new DateTime(2023, 1, 7));
            Student s7 = new Student("Шпак А.Э.", "Группа КН-212", 87, 74, 83, new DateTime(2023, 1, 8));
            Student s8 = new Student("Пименов М.Р.", "Группа КН-212", 91, 90, 92, new DateTime(2023, 1, 9));
            Student s9 = new Student("Сигида В.М.", "Группа КН-212", 85, 86, 80, new DateTime(2023, 1, 10));
            Student s10 = new Student("Миронова Е.Г.", "Группа КН-212", 74, 83, 86, new DateTime(2023, 1, 11));

            students = new List<Student> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };

            listView1.Columns.Add("ФИО");
            listView1.Columns.Add("Номер группы");
            listView1.Columns.Add("Физика");
            listView1.Columns.Add("Математика");
            listView1.Columns.Add("Информатика");
            listView1.Columns.Add("Дата сдачи экзамена");

            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.FullName);
                item.SubItems.Add(student.GroupNumber);
                item.SubItems.Add(student.PhysicsGrade.ToString());
                item.SubItems.Add(student.MathGrade.ToString());
                item.SubItems.Add(student.InformaticsGrade.ToString());
                item.SubItems.Add(student.LastExamDate.ToShortDateString());
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
            DateTime dateTime = DateTime.Parse(textBox1.Text);
            listView1.Items.Clear();
            listView1.Columns.Add("Средний балл");

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

            foreach (Student student in students)
            {
                if (student.LastExamDate <= dateTime)
                {
                    double GPA = (student.InformaticsGrade + student.MathGrade +
                        student.PhysicsGrade) / 3;
                    ListViewItem item = new ListViewItem(student.FullName);
                    item.SubItems.Add(student.GroupNumber);
                    item.SubItems.Add(student.PhysicsGrade.ToString());
                    item.SubItems.Add(student.MathGrade.ToString());
                    item.SubItems.Add(student.InformaticsGrade.ToString());
                    item.SubItems.Add(student.LastExamDate.ToShortDateString());
                    item.SubItems.Add(GPA.ToString());
                    listView1.Items.Add(item);
                }
            }
            listView1.ListViewItemSorter = new GPAComparer(6);
            listView1.Sort();
        }
    }
    class Student
    {
        public string FullName { get; set; }
        public string GroupNumber { get; set; }
        public int PhysicsGrade { get; set; }
        public int MathGrade { get; set; }
        public int InformaticsGrade { get; set; }
        public DateTime LastExamDate { get; set; }
        public Student(string fullName, string groupNumber, int physicsGrade, int mathGrade, int informaticsGrade, DateTime lastExamDate)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
            PhysicsGrade = physicsGrade;
            MathGrade = mathGrade;
            InformaticsGrade = informaticsGrade;
            LastExamDate = lastExamDate;
        }
    }
    public class GPAComparer : IComparer
    {
        private int column;

        public GPAComparer(int column)
        {
            this.column = column;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = (ListViewItem)x;
            ListViewItem itemY = (ListViewItem)y;

            double gpaX = double.Parse(itemX.SubItems[column].Text);
            double gpaY = double.Parse(itemY.SubItems[column].Text);

            return gpaX.CompareTo(gpaY);
        }
    }
}