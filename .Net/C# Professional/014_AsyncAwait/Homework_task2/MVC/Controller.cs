using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework_task2
{

    class Controller
    {
        MainWindow view;
        Model model;
        internal bool DBIsConnected
        {
            get => model.DBIsConnected;
        }

        public Controller(MainWindow view)
        {
            this.view = view;
            this.model = new Model();
        }

        /// <returns>Returns Task"bool" with the connection status</returns>
        internal Task<bool> ConnectDB(SynchronizationContext sync)
        {
            Task<bool> connectDB = model.ConnectDBAsync();

            // Show result of connection to the DB
            connectDB.ContinueWith((Task<bool> task) =>
            {
                if (connectDB.Result == true)
                    sync.Post((object state) => { view.MainTextBox.Text = "Connection successfully :)"; }, null);
                else
                    sync.Post((object state) => { view.MainTextBox.Text = "Error connection :( \nTry again"; }, null);
            });

            return connectDB;
        }

        /// <returns>Returns Task"bool" with the connection status</returns>
        internal Task<bool> DisconnectDB(SynchronizationContext sync)
        {
            Task<bool> disconnectDB = model.ConnectDBAsync();

            // Show result of disconnection to the DB
            disconnectDB.ContinueWith((Task<bool> task) =>
            {
                if (disconnectDB.Result == false)
                    sync.Post((object state) => { view.MainTextBox.Text = "Disconnection successfully :)"; }, null);
                else
                    sync.Post((object state) => { view.MainTextBox.Text = "Error disconnection :( \nTry again"; }, null);
            });

            return disconnectDB;
        }
    }
}



/*
namespace ThreadingExample
{
    public partial class frmUpdateUIFromThread : Form
    {
        Control control;
        public frmUpdateUIFromThread()
        {
            InitializeComponent();
            control = txtLog; //this can be any control
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Log(string msg)
        {
            string m = $"{DateTime.Now.ToString("H:mm:ss.fffff")}\t{msg}\n";
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                txtLog.AppendText(m);
                txtLog.ScrollToCaret();
            });
        }
        private async void btnStartThreads_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            List<Task> allTasks = new List<Task>();

            for (int i = 1; i <= (int)numThreads.Value; i++)
            {
                var j = i;
                var delayFor = TimeSpan.FromMilliseconds(random.Next(100, 5000));
                var task = Task.Run(async () =>
                {
                    var idForLog = $"Task ID {j}, ThreadID={Thread.CurrentThread.ManagedThreadId}";

                    Log($"{idForLog} starting processing");

                    await Task.Delay(delayFor);

                    Log($"{idForLog} finished. Took {delayFor.TotalSeconds}");
                });

                allTasks.Add(task);
            }

            await Task.WhenAll(allTasks);

            Log("All tasks have finished");
        }
    }
}
*/