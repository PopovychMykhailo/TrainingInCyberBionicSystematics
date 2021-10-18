using System;

namespace Homework_task4
{
    class Presenter
    {
        MainWindow view;
        Model model;

        public Presenter(MainWindow view)
        {
            this.view = view;
            this.model = new();
        }

        public void Calclulate(string MathExpression)
        {
            view.TextBlock_Result.Text = model.Calculate(MathExpression).ToString();
        }
    }
}