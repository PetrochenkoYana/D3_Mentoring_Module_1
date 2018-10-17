using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Write a program, which multiplies two matrices and uses class Parallel.
/// </summary>

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix1 = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 1, 2 } };
            int[][] matrix2 = new int[][] { new int[] { 1, 2, 3 }, new int[] { 0, 2, 1 } };
            Stopwatch s = new Stopwatch();
            s.Start();
            var res = MultiplySquareMatrices(matrix1, matrix2);
            s.Stop();
            Console.WriteLine($"MultiplySquareMatrices took {s.ElapsedMilliseconds}");

            for (int i = 0; i < matrix1.Length; i++)
            {

                for (int j = 0; j < matrix2[0].Length; j++)
                {
                    Console.Write(res[i][j] + " ");
                }
                Console.WriteLine("");
            }

            Stopwatch st = new Stopwatch();
            st.Start();
            var resParallel = MultiplySquareMatricesParallel(matrix1, matrix2);
            st.Stop();
            Console.WriteLine($"MultiplySquareMatricesParallel took {st.ElapsedMilliseconds}");

            for (int i = 0; i < matrix1.Length; i++)
            {

                for (int j = 0; j < matrix2[0].Length; j++)
                {
                    Console.Write(resParallel[i][j] + " ");
                }
                Console.WriteLine("");
            }

            Console.ReadKey();
        }

        private static
            int[][] MultiplySquareMatrices(int[][] m1, int[][] m2)
        {
            if (m1.Length != m2[0].Length)
                throw new ArgumentException("Matrices have unsuitable dimension and can not be multiplied ");

            var resultMatrix = new int[m1.Length][];

            for (int i = 0; i < m1.Length; i++)
            {
                resultMatrix[i] = new int[m2[0].Length];

                for (int j = 0; j < m2[0].Length; j++)
                {
                    var sum = 0;
                    for (int k = 0; k < m2.Length; k++)
                    {
                        sum += m1[i][k] * m2[k][j];
                    }
                    resultMatrix[i][j] = sum;

                }
            }
            return resultMatrix;
        }

        private static int[][] MultiplySquareMatricesParallel(int[][] m1, int[][] m2)
        {
            if (m1.Length != m2[0].Length)
                throw new ArgumentException("Matrices have unsuitable dimension and can not be multiplied ");

            var resultMatrix = new int[m1.Length][];
            Parallel.For(0, m1.Length, i =>
            {
                for (i = 0; i < m1.Length; i++)
                {
                    resultMatrix[i] = new int[m2[0].Length];

                    Parallel.For(0, m2[0].Length, j =>
                    {
                        var sum = 0;
                        for (int k = 0; k < m2.Length; k++)
                        {
                            sum += m1[i][k] * m2[k][j];
                        }
                        resultMatrix[i][j] = sum;
                    });
                }
            });
            return resultMatrix;
        }
    }
}
