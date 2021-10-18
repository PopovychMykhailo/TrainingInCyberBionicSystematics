using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerialDataBase
{
    public partial class MainForm : Form
    {
        List<Car> cars = null;

        public MainForm()
        {
            InitializeComponent();
            CenterToScreen();

            // Добавляем несколько объектов Car в массив
            cars = new List<Car>()
                       {
                           new Car("Siddhartha", "BMW", "Silver"),
                           new Car("Chucky", "Caravan", "Green"),
                           new Car("Fred", "Audi TT", "Red")
                       };

            // Обновляем DataGrid
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (cars != null)
            {
                // Создаем таблицу DataTable с именем Inventory
                var table = new DataTable("Inventory");

                // Создаем объекты DataColumn
                var make = new DataColumn("Make");
                var name = new DataColumn("Name");
                var color = new DataColumn("Color");

                // Добавляем объекты DataColumn в DataTable
                table.Columns.Add(name);
                table.Columns.Add(make);
                table.Columns.Add(color);

                // Для каждого элемента создаем строку в таблице
                foreach (Car car in cars)
                {
                    DataRow row = table.NewRow();
                    row["Name"] = car.name;
                    row["Make"] = car.make;
                    row["Color"] = car.color;
                    table.Rows.Add(row);
                }

                // Биндим DataTable к dataGridView 
                dataGridView.DataSource = table;
            }
        }

        private void makeNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FormDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                cars.Add(dialog.car);
                UpdateGrid();
            }
        }

        private void saveCarFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Настраиваем свойства диалогового окна для сохранения файлов 
            // SaveFileDialog mySaveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.Filter = "car files (*.car)|*.car|All files(*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "carDoc";

            // Сохраняем объекты автомобилей
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = saveFileDialog.OpenFile();

                var serializer = new BinaryFormatter();
                serializer.Serialize(myStream, cars);
                myStream.Close();

            }
        }

        private void openCarFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Настраиваем свойства диалогового окна для открытия файлов 		
            openFileDialog.InitialDirectory = ".";
            openFileDialog.Filter = "car files (*.car)|*.car|All files(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            // Восстанавливаем объекты автомобилей
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Очищаем текущий массив
                cars.Clear();

                Stream stream = openFileDialog.OpenFile();
                var deserializer = new BinaryFormatter();
                cars = deserializer.Deserialize(stream) as List<Car>;
                stream.Close();
                UpdateGrid();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearAllCarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cars.Clear();
            UpdateGrid();
        }
    }
}