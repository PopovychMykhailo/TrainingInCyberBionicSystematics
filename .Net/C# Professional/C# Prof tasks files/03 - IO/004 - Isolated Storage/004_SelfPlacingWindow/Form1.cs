using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.IsolatedStorage;

namespace IsolateStorageSmpl
{
    public partial class frmDSSample : Form
    {
        DataSet dsSettings = null;
        DataTable tblSettings = null;

        public frmDSSample()
        {
            dsSettings = new DataSet("Settings");
            tblSettings = dsSettings.Tables.Add("userSettings");

            // Создаем таблицу.
            tblSettings.Columns.Add("BackColor", typeof(Int32));
            tblSettings.Columns.Add("Width", typeof(Int32));
            tblSettings.Columns.Add("Height", typeof(Int32));
            tblSettings.Columns.Add("SampleData", typeof(String));

            this.Load += frmDSSample_Load;

            InitializeComponent();
        }

        private void frmDSSample_Load(Object sender, EventArgs e)
        {
            try
            {
                // Создаем IsolatedStorageFile и определяем место для сохранения настроек приложения.
                //TODO: Different Versions of an assembly...
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForDomain();

                // Проверяем, существует ли уже файл с настройками.
                // Если да - загружаем данные из него.
                var storeFileName =
                    isoStorage.GetFileNames().FirstOrDefault(fileName => fileName == "UserSettingsDS.xml");

                if (storeFileName != null)
                {
                    // Создаем StreamReader для isoStorage.
                    var stmReader =
                        new StreamReader(new IsolatedStorageFileStream("UserSettingsDS.xml", FileMode.Open, isoStorage));

                    // Конвертируем данные из файла (XML) в DataSet.
                    dsSettings.ReadXml(stmReader, XmlReadMode.ReadSchema);

                    // Закрываем StreamReader.
                    stmReader.Close();

                    // Загрузка настроек формы из DataSet.
                    DataRow dr = null;
                    foreach (DataRow row in dsSettings.Tables[0].Rows)
                    {
                        dr = row;
                        this.BackColor = Color.FromArgb(int.Parse(dr["BackColor"].ToString()));
                        this.Width = int.Parse(dr["Width"].ToString());
                        this.Height = int.Parse(dr["Height"].ToString());
                        txtSampleData.Text = dr["SampleData"].ToString();
                    }
                    MessageBox.Show("Настройки успешно загружены", "Пример");
                }
                // Закрываем хранилище.
                isoStorage.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // Изменяем цвет формы.
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if (cdBackground.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = cdBackground.Color;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Удаляем данные.
                tblSettings.Clear();

                // Сохраняем текущее состояние.
                DataRow drSettings = tblSettings.NewRow();

                drSettings["BackColor"] = this.BackColor.ToArgb();
                drSettings["Width"] = this.Width;
                drSettings["Height"] = this.Height;
                drSettings["SampleData"] = txtSampleData.Text;

                tblSettings.Rows.Add(drSettings);
                tblSettings.AcceptChanges();

                // Создаем IsolatedStorageFile и определяем место для хранения настроек приложения.
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForDomain();

                // Создаем StreamWriter для isoStorage.
                var stmWriter = new StreamWriter(new IsolatedStorageFileStream("UserSettingsDS.xml", FileMode.Create, isoStorage));

                // Конвертируем данные из DataSet в файл настроек XML и сохраняем его.
                dsSettings.WriteXml(stmWriter, XmlWriteMode.WriteSchema);
                stmWriter.Close();
                isoStorage.Close();

                // Если добрались до этого места, значит все прошло удачно.
                MessageBox.Show("Настройки успешно сохранены", "Пример");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } // Обработка ошибок.
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Создаем IsolatedStorageFile и определяем место для хранения настроек приложения.
            try
            {
                IsolatedStorageFile isoStorage = IsolatedStorageFile.GetUserStoreForDomain();
                isoStorage.DeleteFile("UserSettingsDS.xml");
                isoStorage.Close();

                MessageBox.Show("Настройки успешно удалены", "Пример");

            }
            catch (System.Exception ex) { MessageBox.Show(ex.Message); } // Обработка ошибок.
        }
    }
}
