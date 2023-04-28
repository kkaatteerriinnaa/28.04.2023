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
    public partial class Task9 : Form
    {
        List<Book> books = null;
        public Task9()
        {
            InitializeComponent();

            Book book1 = new Book("001", "Iван Нечун-Левицький", "Кайдашева сiм`я", "Фоліо", "2005", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book2 = new Book("002", "Іван Котляревський", "Енеїда", "Радянська школа", "1989", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book3 = new Book("003", "Леся Украинка", "Лісова пісня", "БАО", "2009", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book4 = new Book("004", "Багряний Іван", "Тигролови", "Школа", "2008", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book5 = new Book("005", "Панас Мирний", "Хіба ревуть воли, як ясла повні?", "Аргумент Принт", "2012", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book6 = new Book("006", "Василь Барка", "Жовтий князь", "Фоліо", "2009", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book7 = new Book("007", "Михайло Коцюбинський", "Тіні забутих предків (Сборник)", "Фоліо", "2008", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book8 = new Book("008", "Михаил Старицкий", "За двома зайцями", "Украина", "2005", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book9 = new Book("009", "Остап Вишня", "Мисливськi усмiшки та інші оповідання", "БАО", "2009", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));
            Book book10= new Book("010", "Олександр Довженко", "Зачарована Десна(сборник)", "Фоліо", "2011", new DateTime(2023, 1, 9), new DateTime(2023, 2, 9));

            books = new List<Book> { book1, book2, book3, book4, book5, book6, book7, book8, book9, book10 };

            listView1.Columns.Add("Номер");
            listView1.Columns.Add("Автор");
            listView1.Columns.Add("Название");
            listView1.Columns.Add("Издательство");
            listView1.Columns.Add("Год издания");
            listView1.Columns.Add("Дата выдачи книги");
            listView1.Columns.Add("Срок возврата");

            foreach (Book book in books)
            {
                ListViewItem item = new ListViewItem(book.Number);
                item.SubItems.Add(book.NameAuthor);
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Publishing);
                item.SubItems.Add(book.PublishingYear);
                item.SubItems.Add(book.DateIssue.ToShortDateString());
                item.SubItems.Add(book.ReturnPeriod.ToShortDateString());
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
            listView1.Items.Clear();

            DateTime now = DateTime.Now;
            TimeSpan interval = TimeSpan.Parse(textBox1.Text);
            DateTime newDateTime = now.Add(interval);
            foreach (Book book in books)
            {
                if (book.ReturnPeriod > newDateTime)
                {
                    ListViewItem item = new ListViewItem(book.Number);
                    item.SubItems.Add(book.NameAuthor);
                    item.SubItems.Add(book.Title);
                    item.SubItems.Add(book.Publishing);
                    item.SubItems.Add(book.PublishingYear);
                    item.SubItems.Add(book.DateIssue.ToShortDateString());
                    item.SubItems.Add(book.ReturnPeriod.ToShortDateString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    class Book
    {
        public string Number { get; set; }
        public string NameAuthor { get; set; }
        public string Title { get; set; }
        public string Publishing { get; set; }
        public string PublishingYear { get; set; }
        public DateTime DateIssue { get; set; }
        public DateTime ReturnPeriod { get; set; }

        public Book(string number, string nameAuthor, string title, string publishing, string publishingYear, DateTime dateIssue, DateTime returnPeriod)
        {
            Number = number;
            NameAuthor = nameAuthor;
            Title = title;
            Publishing = publishing;
            PublishingYear = publishingYear;
            DateIssue = dateIssue;
            ReturnPeriod = returnPeriod;
        }
    }

}