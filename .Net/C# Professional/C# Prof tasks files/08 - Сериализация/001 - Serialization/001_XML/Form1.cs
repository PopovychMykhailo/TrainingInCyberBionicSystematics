using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

// XML СЕРИАЛИЗАЦИЯ.

namespace XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Тип для Сериализации и Десериализации.
        readonly XmlSerializer serializer = new XmlSerializer(typeof(MyClass));

        MyClass instance1 = new MyClass();
        MyClass instance2;


        // СЕРИАЛИЗАЦИЯ.
        private void SerializeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                instance1.Items.Add("Element " + i); // Заполнение списка.
            }

            FileStream stream = new FileStream("Serialization.xml", FileMode.Create, FileAccess.Write, FileShare.Read);

            // Сохраняем объект в XML-файле на диске(СЕРИАЛИЗАЦИЯ).
            serializer.Serialize(stream, instance1);
            this.Text = "Объект сериализован!";
            stream.Close();
        }


        // ДЕСЕРИАЛИЗАЦИЯ.
        private void DeserializeButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream stream = new FileStream("Serialization.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

                // Восстанавливаем объект из XML-файла.
                instance2 = serializer.Deserialize(stream) as MyClass;
                this.Text = "Объект Десериализован!";


                textBox.Text = "ID        : " + instance2.ID + Environment.NewLine +
                                "Size     : " + instance2.Size + Environment.NewLine +
                                "Position : " + instance2.Position.ToString() + Environment.NewLine +
                                "List     : " + Environment.NewLine;

                foreach (string item in instance2.Items)
                {
                    textBox.Text += "\t" + item + Environment.NewLine;
                }

                textBox.Text += "Password: " + instance2.Password;
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}