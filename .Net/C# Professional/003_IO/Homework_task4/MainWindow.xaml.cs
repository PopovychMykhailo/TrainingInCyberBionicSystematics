using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework_task4
{
    /* Technical task
    
        Создайте приложение WPF Application, позволяющее пользователям сохранять данные в
        изолированное хранилище
    */



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // View
        Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new(this);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.SaveData(TextField.Text);
        }

        public void WriteTextTo_TextField(string text)
        {
            TextField.Text = text;
        }
    }
}
