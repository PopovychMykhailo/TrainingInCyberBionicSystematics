using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002_Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Установка параметров Таймера.
            InitializeTimer();
        }


        // Обработчик события Тиков Таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
                progressBar1.Value++;

            if (progressBar2.Value < 100)
                progressBar2.Value++;
        }

        private void InitializeTimer()
        {
            // 1 second = 1000 mlsec.
            // 1000 mlsec. - 1 тик в секунду. 100 mlsec. - 10 тиков в секунду.
            // 10 mlsec. - 100 тиков в секунду. 1 mlsec. - 1000 тиков в секунду.
            // Интервал генерации события Таймера.
            timer1.Interval = 100;

            // Запуск Таймера.
            timer1.Start();

            // Статус Таймера.
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
