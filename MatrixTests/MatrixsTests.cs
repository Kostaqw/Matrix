using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Matrix
{
    [TestClass()]
    public class MatrixsTests
    {
        [TestMethod()]
        public void MatrixCreateTest()
        {
            var matrix = new Matrixs(5, 5);

            byte exceptWidth = 5;
            byte exceptHeight = 5;

            Assert.AreEqual(exceptWidth, matrix.Width);
            Assert.AreEqual(exceptHeight, matrix.Height);
        }

        [TestMethod()]
        public void CalculateMainDiagonalInSquareMatrixTest()
        {
            byte[,] array = new byte[,] { {1,2,3,4,5},
                                          {5,6,7,8,9},
                                          {10,11,12,13,14},
                                          {15,16,17,18,19},
                                          {20,21,22,23,24}};

            var matrix = new Matrixs(array);

            byte exceptDiagonal = 61;
           
            Assert.AreEqual(exceptDiagonal, matrix.MainDiagonal);
        }

        [TestMethod()]
        public void CalculateMainDiagonalInRectangleMatrixTest()
        {
            byte[,] array = new byte[,] { {1,2,3},
                                          {5,6,7},
                                          {10,11,12},
                                          {15,16,17},
                                          {20,21,22}};

            var matrix = new Matrixs(array);

            byte exceptDiagonal = 19;

            Assert.AreEqual(exceptDiagonal, matrix.MainDiagonal);
        }

        [TestMethod()]
        public void SnakeInSquareMatrixTest()
        {
            byte[,] array = new byte[,] { {1,2,3,4,5},
                                          {5,6,7,8,9},
                                          {10,11,12,13,14},
                                          {15,16,17,18,19},
                                          {20,21,22,23,24}};

            var matrix = new Matrixs(array);

            string exceptSnake = "1 2 3 4 5 9 14 19 24 23 22 21 20 15 10 5 6 7 8 13 18 17 16 11 12";

            Assert.AreEqual(exceptSnake, matrix.SnakeMatrix());
        }

        [TestMethod()]
        public void SnakeInRectangleMatrixTest()
        {
            byte[,] array = new byte[,] { {1,2,3},
                                          {5,6,7},
                                          {10,11,12},
                                          {15,16,17},
                                          {20,21,22}};

            var matrix = new Matrixs(array);

            string exceptSnake = "1 2 3 7 12 17 22 21 20 15 10 5 6 11 16";

            Assert.AreEqual(exceptSnake, matrix.SnakeMatrix());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MatrixCreateUncorrectDateTest()
        {
            var matrix = new Matrixs(1, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatrixCreateNullDateTest()
        {
            byte[,] array = null;
            var matrix = new Matrixs(array);
        }
    }
}