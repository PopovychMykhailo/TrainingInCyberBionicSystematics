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

// View

namespace Homework_task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /* Technical task
     
        Используя Visual Studio, создайте проект по шаблону WPF Application.
        Создайте программу секундомер. Требуется выводить показания секундомера в окне. Окно имеет
        кнопки запуска, остановки и сброса секундомера. Для реализации секундомера используйте паттерн
        MVP. 
     */

    // Comment
    // 1. I don't know how to do update time every N ms, so I did that when the mouse moves on textBlock - the time is updating



    public partial class MainWindow : Window
    {
        Presenter presenter;

        public MainWindow()
        {
            InitializeComponent();
            presenter = new(this);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.Stopwatch_startTime();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.Stopwatch_stopTime();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.Stopwatch_resetTime();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            presenter.UpdateStopwatchTime();
        }

        public void TextBlock_updateTime(string time)
        {
            textBlock_time.Text = time;
        }

    }
}