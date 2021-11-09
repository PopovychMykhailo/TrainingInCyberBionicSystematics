using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Homework_task2
{
    /* Technical task
    
        Создайте WPF приложение, разместите в окне TextBox и две кнопки. При нажатии на первую
        кнопку в TextBox выводится сообщение «Подключен к базе данных» при этом в обработчике
        установите задержку в 3-5 сек для имитации подключения к БД, также данная кнопка
        запускает таймер, который с периодичностью в несколько секунд выводит в TextBox
        сообщение «Данные получены». При нажатии на вторую кнопку по аналогии с первой
        отключаемся от базы (с задержкой), выводим сообщение и останавливаем таймер.
    */

    /* Developer comment:
        
        I specifically made the disconnection very similar to the connection to better check that in all cases the program works stably
        And in class the teacher didn't talk about SynchronizationContext, and I spent a lot of time looking for information on how to write 
            this program without it, but didn't find anything I could write...
        The next day I tried to look for information, but after 4 hours I decided not to waste time and studied SynchronizationContext 
            and used it in this program.
        
        Happy end :)
    */



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Controller controller;
        private SynchronizationContext sync = SynchronizationContext.Current;
        private Timer showStatusDBTimer;

        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this);
        }

        //public string WrapperMainTextBox
        //{
        //    set
        //    {
        //        MainTextBox.Text = value;
        //        UpdateLayout();
        //    }

        //    get => MainTextBox.Text;
        //}

        private void ConnectDB_Button_Click(object sender, RoutedEventArgs e)
        {
            // Clear old timer
            if (showStatusDBTimer != null)
                showStatusDBTimer.Dispose();

            MainTextBox.Text = "Please wait, connecting to the database...";

            // Display result (is received data) every 1 sec
            controller.ConnectDB(sync)  // Connecting...
                .ContinueWith(          // Next task (to show the result)
                    (Task<bool> task) =>
                    {
                        showStatusDBTimer = new Timer((object state) => { sync.Post(ShowStatusConnectDB, null); }, null, 3000, 1000);
                    });
        }

        private void DisconnectDB_Button_Click(object sender, RoutedEventArgs e)
        {
            // Clear old timer
            if (showStatusDBTimer != null)
                showStatusDBTimer.Dispose();

            MainTextBox.Text = "Please wait, disconnecting from the database...";

            // Display result (is received data)
            controller.DisconnectDB(sync)   // Disconnecting...
                .ContinueWith(              // Next task (to show the result)
                    (Task<bool> task) =>
                    {
                        // Disconnection error - swows status every 1 sec
                        if (task.Result == true)
                            showStatusDBTimer = new Timer((object state) => { sync.Post(ShowStatusConnectDB, null); }, null, 3000, 1000);
                    
                        // Successfuly disconnect - swos status once
                        else
                            showStatusDBTimer = new Timer((object state) => { sync.Post(ShowStatusConnectDB, null); showStatusDBTimer.Dispose(); }, null, 3000, 1000);
                    });
        }

        // Shows the connection status of the DB in the MainTextBox
        private void ShowStatusConnectDB(object state)
        {
            if (controller.DBIsConnected == true)
                MainTextBox.Text = "Data successfully received";
            else
                MainTextBox.Text = "Error received data";
        }
    }
}
