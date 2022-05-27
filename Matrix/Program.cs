using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrixs matrix = new Matrixs(5, 5);
            Matrixs matrix2 = new Matrixs(5, 8);
            Matrixs matrix3 = new Matrixs(1, 8);
            Matrixs matrix4 = new Matrixs(6, 1);

            Show(matrix);
            Show(matrix2);
            Show(matrix3);
            Show(matrix4);
        }

        private static void Show(Matrixs matrix)
        {
            matrix.ShowMatrix();
            Console.WriteLine();
            Console.WriteLine($"Main diagonal = {matrix.MainDiagonal}");
            Console.Write("Snake = " + matrix.SnakeMatrix());
            Console.WriteLine("\n-----------------------------------\n");
        }
    }
}
