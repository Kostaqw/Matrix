using System;
using System.Text;

namespace Matrix
{
    public class Matrixs
    {
        public ushort Width { get; }
        public ushort Height { get; }
        public byte[,] Matrix { get; }
        public int MainDiagonal { get; }


        public Matrixs(ushort weight, ushort height)
        {
            Width = weight;
            Height = height;
            
            CheckSize();
            
            Matrix = new byte[weight, height];
            FillMatrix();
            
            MainDiagonal = FindMainDiagonal();
        }

        public Matrixs(byte[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("the array is null");
            }

            Width = (ushort)matrix.GetLength(0);
            Height = (ushort)matrix.GetLength(1);

            CheckSize();

            Matrix = matrix;
            MainDiagonal = FindMainDiagonal();
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{Matrix[i, j]:d3} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{Matrix[i, j]:d3} ");
                    }
                }
                Console.WriteLine();
            }
        }

        public string SnakeMatrix()
        {
            int width = Matrix.GetLength(1);
            int height = Matrix.GetLength(0);

            int minX = 0;
            int maxX = width - 1;
            int minY = 0;
            int maxY = height - 1;

            var snake = new StringBuilder();

            while (true)
            {
                if (maxX - minX < 0)
                    break;

                for (int i = minX; i <= maxX; i++)
                {
                    snake.Append($"{Matrix[minY, i]} ");
                }

                minY++;

                if (maxY - minY < 0)
                    break;

                for (int i = minY; i <= maxY; i++)
                {
                    snake.Append($"{Matrix[i, maxX]} ");
                }

                maxX--;

                if (maxX - minX < 0)
                    break;

                for (int i = maxX; i >= minX; i--)
                {
                    snake.Append($"{Matrix[maxY, i]} ");
                }

                maxY--;

                if (maxY - minY < 0)
                    break;

                for (int i = maxY; i >= minY; i--)
                {
                    snake.Append($"{Matrix[i, minX]} ");
                }

                minX++;
            }
            snake.Length--;

            return snake.ToString();
        }

        private void FillMatrix()
        {
            Random rnd = new Random();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Matrix[i, j] = (byte)rnd.Next(0, 101);
                }
            }
        }

        private int FindMainDiagonal()
        {
            int i = 1, j = 1;
            int mainDiagonal = Matrix[0, 0];
            while (i < Width && j < Height)
            {
                mainDiagonal += Matrix[i, j];
                i++;
                j++;
            }
            return mainDiagonal;
        }

        private void CheckSize()
        {
            if ((Width <= 1 && Height <= 1) || (Width < 1 || Height < 1))
            {
                throw new ArgumentException("the size of the matrix must be >1");
            }
        }
    }
}
