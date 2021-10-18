using System;

// Presenter

namespace MVP
{
    class Presenter
    {
        Model model = null;
        MainWindow view = null;

        public Presenter(MainWindow mainWindow)
        {
            this.model = new Model();
            this.view = mainWindow;
            this.view.myEvent += new EventHandler(mainWindow_myEvent);
        }

        void mainWindow_myEvent(object sender, System.EventArgs e)
        {
            var data = this.view.textBox1.Text;

            string variable = model.Logic(data);

            this.view.textBox1.Text = variable;
        }
    }
}
