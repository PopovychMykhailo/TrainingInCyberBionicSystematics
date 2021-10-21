using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task4
{
    class Presenter
    {
        MainWindow view;
        Model model;
        
        public Presenter(MainWindow view)
        {
            this.view = view;
            model = new();

            view.WriteTextTo_TextField(model.ReadTextFromFile() == "" ? "Write anything..." : model.ReadTextFromFile());
        }

        public void SaveData(string text)
        {
            model.WriteTextToFile(text);
        }
    }
}
