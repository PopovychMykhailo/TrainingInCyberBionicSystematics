using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Reflector
{
    public partial class Form1 : Form
    {
        // При помощи класса Assembly - можно динамически загружать сборки, 
        // обращаться к членам класса в процессе выполнения (ПОЗДНЕЕ СВЯЗЫВАНИЕ),
        // а так же получать информацию о самой сборке.
        Assembly assembly = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox.Text += "Тип:  " + type + Environment.NewLine;
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "Метод:" + method.Name + "\n";
                            var methodBody = method.GetMethodBody();
                            if (methodBody != null)
                            {
                                var byteArray = methodBody.GetILAsByteArray();

                                foreach (var b in byteArray)
                                {
                                    methStr += b + ":";
                                }
                            }
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }
                }


            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
