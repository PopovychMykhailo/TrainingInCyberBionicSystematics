using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task1
{
    // Character with color
    class MyChar
    {
        public char Symbol { set; get; }
        public ConsoleColor Color { set; get; }

        public MyChar()
        {
            Symbol = '\'';
            Color = ConsoleColor.Red;
        }
        public MyChar(char symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }
    }
}
