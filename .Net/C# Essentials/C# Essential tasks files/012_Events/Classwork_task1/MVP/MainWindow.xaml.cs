using System;
using System.Windows;

// View

namespace MVP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        private event EventHandler myEvent = null;
        

        // My new code
        public event EventHandler MyEvent
        {
            add
            {
                myEvent += value;
                Console.WriteLine("Add new handler to MyEvent");
            }

            remove
            {
                myEvent -= value;
                Console.WriteLine("Remove new handler to MyEvent");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            myEvent.Invoke(sender, e);
        }
    }
}
