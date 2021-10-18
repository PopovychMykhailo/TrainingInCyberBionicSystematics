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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону WPF Application.
        Создайте калькулятор на четыре арифметических действия (сложение, вычитание, умножение и
        деление). Для реализации калькулятора используйте паттерн MVP.
    */

    // Comment
    // Does not count a mathematical expression if the first number is fractional, not yet corrected

    public partial class MainWindow : Window
    {
        Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new(this);
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            presenter.Calclulate(TextBox_MathExpression.Text);
        }
    }
}
