using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_task3
{
    class MyMatrix
    {
        // ТЗ
        /*
         * Создать класс MyMatrix, обеспечивающий представление матрицы произвольного размера 
         * с возможностью изменения числа строк и столбцов. Написать программу, которая выводит 
         * на экран матрицу и производные от нее матрицы разных порядков
         */

        // Legend
        /* 0 - 50%  - Writing, not testing
         * 50 - 90% - Writed, tisting
         * 100%     - Done (checked)
        */

        int[,] matrix;

        Random random = new();
        const int maxValue = 100;   // Max value of cell

        // 100%
        public MyMatrix(int sizeX, int sizeY)
        {
            matrix = new int[sizeX, sizeY];

            // Filling the matrix random value
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = random.Next(maxValue);
                }
            }
        }

        // 100%
        public void ReSize(int sizeX, int sizeY)
        {
            int[,] newMatrix = new int[sizeX, sizeY];

            // If the new matrix size is smaller than the current one - copy cells to new matrix
            if (sizeX < matrix.GetLength(0) && sizeY < matrix.GetLength(1))
            {
                for (int i = 0; i < sizeX; ++i)
                {
                    for (int j = 0; j < sizeY; ++i)
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }
                }
            }
            // Else, the new matrix is larger (at least on one side) - copy part values to the new matrix, and fill random values
            else
            {
                for (int i = 0; i < sizeX; ++i)
                {
                    for (int j = 0; j < sizeY; ++j)
                    {
                        if (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                        {
                            newMatrix[i, j] = matrix[i, j];
                        }
                        else
                        {
                            newMatrix[i, j] = random.Next(maxValue);
                        }
                    }
                }
            }

            matrix = newMatrix;
        }

        // 100%
        public void Show()
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
