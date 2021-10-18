using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;

namespace Homework_task4
{
    class Model
    {

        public double Calculate(string MathExpression)
        {
            double mathResult = 0;
            List<double> numerics = new();
            List<char> mathSigns = new();

            #region Find out all numerics and math signs

            for (Match match = Regex.Match(MathExpression, @"\d*[.,]?\d+"); match.Success; match = match.NextMatch())
            {
                numerics.Add(Convert.ToDouble(match.Value));
            }

            for (Match match = Regex.Match(MathExpression, @"[+,\-,*,/]"); match.Success; match = match.NextMatch())
            {
                mathSigns.Add(Convert.ToChar(match.Value));
            }
            #endregion

            #region Calculating numerics

            mathResult = numerics[0];

            for (int i = 0; i < mathSigns.Count; i++)
            {
                switch (mathSigns[i])
                {
                    case '+':
                        {
                            mathResult += numerics[i + 1];
                            break;
                        }
                    case '-':
                        {
                            mathResult -= numerics[i + 1];
                            break;
                        }
                    case '*':
                        {
                            mathResult *= numerics[i + 1];

                            break;
                        }
                    case '/':
                        {
                            if (numerics[i + 1] != 0)
                                mathResult /= numerics[i + 1];
                            else
                            {
                                mathResult = 0;
                                MessageBox.Show("Can't divide by zero!", "Calculate");
                            }

                            break;
                        }
                }
            }

            #endregion

            return mathResult;
        }

    }
}