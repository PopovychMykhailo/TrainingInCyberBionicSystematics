using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_task1
{
    // Array of characters, with color and coordinates
    class Chain
    {
        static object block = new();

        int column;     // Axis X (->)
        int row;        // Axis Y (^)
        int timeUpdate; // Time (ms) to display the chain in the console
        MyChar[] chain; // Array symbols


        public int Length
        {
            get => chain.Length;
        }           // The length of the character array
        public int Column
        {
            set
            {
                if (value >= 0)
                    column = value;
            }

            get => column;
        }           // Column of the current position of the head (beginning) of the chain
        public int Row
        {
            set
            {
                if (value >= 0)
                    row = value;
            }
            get => row;
        }              // Console row where the chain is located
        public int TimeUpdateMs
        {
            set
            {
                if (value > 0)
                    timeUpdate = value;
            }
            get => timeUpdate;
        }     // Time period for chain update in the console (milliseconds)



        public Chain(int length, int column, int row, int timeUpdate)
        {
            Column = row;
            Row = column;
            TimeUpdateMs = timeUpdate;
            chain = new MyChar[length];

            for (int i = 0; i < chain.Length; i++)
                chain[i] = new MyChar();
        }
        public Chain(int length, int column)
        {
            Random random = new();

            int _row = random.Next(0, Printer.ConsoleHeight);
            int _timeUpdate = random.Next(50, 200);

            Column = column;
            Row = _row;
            TimeUpdateMs = _timeUpdate;
            chain = new MyChar[length];

            for (int i = 0; i < chain.Length; i++)
                chain[i] = new MyChar();
        }

        public MyChar this[int index]
        {
            set
            {
                if (index >= 0 && index < Length)
                    chain[index] = value;
            }

            get
            {
                if (index >= 0 && index < Length)
                    return chain[index];
                else
                    throw new Exception($"Attention: index position (get) is out of range in the Chain {this}!");
                //return new MyChar('!', ConsoleColor.Red);

            }
        }

        // Move the current row to the next to update the current position of the chain in the console
        public void NextRow()
        {
            if (row - Length + 1 < Printer.ConsoleHeight)
                ++row;
            else
                row = 0;
        }

        public void Show()
        {
            for (int i = 0; i < chain.Length; i++)
            {
                if (Row - i >= 0)
                    Printer.WriteAt(chain[i].Symbol, chain[i].Color, Column, Row - i);
            }

            if (Row - Length >= 0)
                Printer.WriteAt(' ', ConsoleColor.Black, Column, Row - Length);
        }
    }

}
