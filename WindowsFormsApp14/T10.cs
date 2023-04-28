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
    public partial class Task10 : Form
    {
        List<Shop> goods = new List<Shop>();
        public Task10()
        {
            InitializeComponent();

            Shop item1 = new Shop("Молочные продукты", "Молоко", "ОАО 'Молокоферма'", new DateTime(2023, 4, 18), TimeSpan.FromDays(11));
            Shop item2 = new Shop("Мясные продукты", "Говядина", "ООО 'Ферма'", new DateTime(2023, 4, 8), TimeSpan.FromDays(14));
            Shop item3 = new Shop("Овощи", "Огурцы", "ООО 'Теплица'", new DateTime(2023, 4, 12), TimeSpan.FromDays(16));
            Shop item4 = new Shop("Фрукты", "Груши", "ООО 'Сад'", new DateTime(2023, 4, 10), TimeSpan.FromDays(10));
            Shop item5 = new Shop("Консервы", "Рыбные консервы", "ОАО 'Консервный завод'", new DateTime(2023, 4, 1), TimeSpan.FromDays(365));
            Shop item6 = new Shop("Кондитерские изделия", "Торты", "Roshen", new DateTime(2023, 5, 1), TimeSpan.FromDays(12));
            Shop item7 = new Shop("Крупы", "Гречка'", "Barilla G. e R. Fratelli Società per Azioni", new DateTime(2023, 5, 10), TimeSpan.FromDays(365));
            Shop item8 = new Shop("Напитки", "Фанта", "Fanta Company", new DateTime(2023, 4, 15), TimeSpan.FromDays(13));
            Shop item9 = new Shop("Морепродукты", "Креветки", "ОАО 'Рыба'", new DateTime(2023, 4, 20), TimeSpan.FromDays(15));
            Shop item10 = new Shop("Хлебобулочные изделия", "Хлеб", "ООО 'Хлебозавод №1'", new DateTime(2023, 4, 16), TimeSpan.FromDays(3));

            goods = new List<Shop> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 };

            listView1.Columns.Add("Группа");
            listView1.Columns.Add("Товар");
            listView1.Columns.Add("Изготовитель");
            listView1.Columns.Add("Дата изготовления");
            listView1.Columns.Add("Срок годности");

            foreach (Shop shop in goods)
            {
                ListViewItem item = new ListViewItem(shop.Group);
                item.SubItems.Add(shop.Name);
                item.SubItems.Add(shop.Manufacturer);
                item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
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
            DateTime interval = DateTime.Parse(textBox1.Text);
            foreach (Shop shop in goods)
            {
                DateTime shelf = shop.DateManufacture + shop.ShelfLife;
                if (interval > shelf)
                {
                    ListViewItem item = new ListViewItem(shop.Group);
                    item.SubItems.Add(shop.Name);
                    item.SubItems.Add(shop.Manufacturer);
                    item.SubItems.Add(shop.DateManufacture.ToShortDateString());
                    item.SubItems.Add(shop.ShelfLife.TotalDays.ToString());
                    listView1.Items.Add(item);
                }
            }
        }
    }
    public class Shop
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime DateManufacture { get; set; }
        public TimeSpan ShelfLife { get; set; }

        public Shop(string group, string name, string manufacturer, DateTime dateManufacture, TimeSpan shelfLife)
        {
            Group = group;
            Name = name;
            Manufacturer = manufacturer;
            DateManufacture = dateManufacture;
            ShelfLife = shelfLife;
        }
    }

}