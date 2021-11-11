using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Classwork_task1
{
    /* Technical task
    
        + Создайте приложение по шаблону WPF Application. 
        + Переместите из элементов управления (ToolBox) на форму текстовое поле и кнопку. 
        + Создайте асинхронный обработчик события по нажатию на кнопку.
        + Создайте метод Addition, который принимает два параметра и возвращает результат их сложениях. 
        + Из асинхронного обработчика события вызовите этот метод через Task.Run. 
        + На возвращаемом значении метода Run вызовите метод ConfigureAwait с указанием параметра false. 
        + Примените оператор await к этому выражению и примите результат работы задачи в целочисленную переменную. 
        + Ее значение выведите в текстовое поле.
        + Посмотрите на результаты работы
    */

    /* Result
        
        The second thread does not have permission to work with the elements of the first thread
    */


    /// <summary>
    /// "View". Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void MainButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            decimal result = 0;
            Func<decimal> additional = () =>
            {
                result = Addtional(10, 20);
                return result;
            };
            await Task.Run<decimal>(additional).ConfigureAwait(false);

            MainTextBox.Text = result.ToString();
        }

        private decimal Addtional(decimal number1, decimal number2)
        {
            return number1 + number2;
        }
    }
}
