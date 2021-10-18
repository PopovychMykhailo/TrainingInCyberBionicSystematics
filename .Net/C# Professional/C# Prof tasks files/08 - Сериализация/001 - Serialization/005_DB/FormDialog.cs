using System;
using System.Windows.Forms;

namespace SerialDataBase
{
    public partial class FormDialog : Form
    {
        public Car car = null;

        public FormDialog()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.car = new Car(textBox1.Text, listBox1.Text, listBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}