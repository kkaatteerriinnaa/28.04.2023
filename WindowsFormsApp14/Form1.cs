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

namespace Different_tasks_async_await_
{
    public partial class Form1 : Form
    {
        Task6 task6 = null;
        Task7 task7 = null;
        Task8 task8 = null;
        Task9 task9 = null;
        Task10 task10 = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            task6 = new Task6();
            task6.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            task7 = new Task7();
            task7.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            task8 = new Task8();
            task8.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            task9 = new Task9();
            task9.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            task10 = new Task10();
            task10.Show();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await Asynk_Await();
        }
        private async Task Asynk_Await()
        {
            if (task6 != null && task6.button1.Enabled == false)
            {
                await task6.FinalCount();
            }
            if (task7 != null && task7.button1.Enabled == false)
            {
                await task7.FinalCount();
            }
            if (task8 != null && task8.button1.Enabled == false)
            {
                await task8.FinalCount();
            }
            if (task9 != null && task9.button1.Enabled == false)
            {
                await task9.FinalCount();
            }
            if (task10 != null && task10.button1.Enabled == false)
            {
                await task10.FinalCount();
            }
        }

       
    }
}