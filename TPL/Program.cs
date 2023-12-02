using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TPL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row1 = 600;
            int col1 = 500;
            int row2 = 500;
            int col2 = 400;

            Matrix matrix1 = CreateMatrix(row1, col1);
            Matrix matrix2 = CreateMatrix(row2, col2);

            #region ---== Matrix multiplication without parallelism ==---

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            var simpleMatrixResult = SimpleMatrixMultiplication.MultiplyMatrices(matrix1, matrix2);
            sw1.Stop();

            Console.WriteLine($"Time          without parallesim: {sw1.ElapsedTicks} Ticks");

            #endregion

            #region ---== Matrix multiplication with parallesim ==---

            #region --- Matrix multiplication with parallesim with One Parallel.For ---

            Stopwatch sw4 = new Stopwatch();
            sw4.Start();
            var parallelMatrixResult_1 = ParallelMatrixMultiplication_1.MultiplyMatrices(matrix1, matrix2);
            sw4.Stop();

            long BestElapsedTicksWithParallesim = sw4.ElapsedTicks;
            string countOfParallelFor = "One";

            Console.WriteLine($"Time             with parallesim: {sw4.ElapsedTicks} Ticks. One Parallel.For.");

            #endregion

            #region --- Matrix multiplication with parallesim with Two Parallel.For ---

            Stopwatch sw5 = new Stopwatch();
            sw5.Start();
            var parallelMatrixResult_2 = ParallelMatrixMultiplication_2.MultiplyMatrices(matrix1, matrix2);
            sw5.Stop();

            if(sw5.ElapsedTicks < BestElapsedTicksWithParallesim)
            {
                BestElapsedTicksWithParallesim = sw5.ElapsedTicks;
                countOfParallelFor = "Two";
            }

            Console.WriteLine($"Time             with parallesim: {sw5.ElapsedTicks} Ticks. Two Parallel.For.");

            #endregion

            #region --- Matrix multiplication with parallesim with Three Parallel.For ---

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            var parallelMatrixResult_3 = ParallelMatrixMultiplication_3.MultiplyMatrices(matrix1, matrix2);
            sw2.Stop();

            if (sw2.ElapsedTicks < BestElapsedTicksWithParallesim)
            {
                BestElapsedTicksWithParallesim = sw5.ElapsedTicks;
                countOfParallelFor = "Three";
            }

            Console.WriteLine($"Time             with parallesim: {sw2.ElapsedTicks} Ticks. Three Parallel.For.");

            #endregion

            #endregion

            Console.WriteLine();

            #region ---== Matrix multiplication with parallesim and options ==---

            List<int> maxDegreeOfParallelism = new List<int>()
                                               { 1, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32 };

            long ElapsedTicks = 0;

            #region --- Matrix multiplication with parallesim and options. One Parallel.For ---

            long bestResultWithOptions_1 = Int64.MaxValue;
            int BestMaxDegreeOfParallelism_1 = 0;

            for (int i = 0; i < maxDegreeOfParallelism.Count; i++)
            {
                Stopwatch sw7 = new Stopwatch();
                sw7.Start();
                var parallelMatrixResultWithOptions_1 = ParallelMatrixMultiplicationWithOptions_1
                                                      .MultiplyMatrices(matrix1, matrix2, maxDegreeOfParallelism[i]);
                sw7.Stop();

                ElapsedTicks = sw7.ElapsedTicks;

                Console.WriteLine($"Time with parallesim and options: {ElapsedTicks} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[i]}. One Parallel.For.");

                if(ElapsedTicks < bestResultWithOptions_1)
                {
                    bestResultWithOptions_1 = ElapsedTicks;
                    BestMaxDegreeOfParallelism_1 = i;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Best result");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_1} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_1]}. One Parallel.For.");

            #endregion

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            #region --- Matrix multiplication with parallesim and options. Two Parallel.For ---

            long bestResultWithOptions_2 = Int64.MaxValue;
            int BestMaxDegreeOfParallelism_2 = 0;

            for (int i = 0; i < maxDegreeOfParallelism.Count; i++)
            {
                Stopwatch sw6 = new Stopwatch();
                sw6.Start();
                var parallelMatrixResultWithOptions_2 = ParallelMatrixMultiplicationWithOptions_2
                                                      .MultiplyMatrices(matrix1, matrix2, maxDegreeOfParallelism[i]);
                sw6.Stop();

                ElapsedTicks = sw6.ElapsedTicks;

                Console.WriteLine($"Time with parallesim and options: {ElapsedTicks} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[i]}. Two Parallel.For.");

                if (ElapsedTicks < bestResultWithOptions_2)
                {
                    bestResultWithOptions_2 = ElapsedTicks;
                    BestMaxDegreeOfParallelism_2 = i;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Best result");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_2} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_2]}. Two Parallel.For.");

            #endregion

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            #region --- Matrix multiplication with parallesim and options. Three Parallel.For ---

            long bestResultWithOptions_3 = Int64.MaxValue;
            int BestMaxDegreeOfParallelism_3 = 0;

            for (int i = 0; i < maxDegreeOfParallelism.Count; i++)
            {
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                var parallelMatrixResultWithOptions_3 = ParallelMatrixMultiplicationWithOptions_3
                                                      .MultiplyMatrices(matrix1, matrix2, maxDegreeOfParallelism[i]);
                sw3.Stop();

                ElapsedTicks = sw3.ElapsedTicks;

                Console.WriteLine($"Time with parallesim and options: {ElapsedTicks} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[i]}. Three Parallel.For.");

                if (ElapsedTicks < bestResultWithOptions_3)
                {
                    bestResultWithOptions_3 = ElapsedTicks;
                    BestMaxDegreeOfParallelism_3 = i;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Best result");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_3} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_3]}. Three Parallel.For.");

            #endregion

            Console.WriteLine();

            #endregion

            #region ---== Best results ==---

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Best results");
            Console.WriteLine($"Time          without parallesim: {sw1.ElapsedTicks} Ticks");
            Console.WriteLine($"Time             with parallesim: {BestElapsedTicksWithParallesim} Ticks. {countOfParallelFor} Parallel.For.");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_1} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_1]}. One Parallel.For.");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_2} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_2]}. Two Parallel.For.");
            Console.WriteLine($"Time with parallesim and options: {bestResultWithOptions_3} Ticks. " +
                                  $"MaxDegreeOfParallelism = {maxDegreeOfParallelism[BestMaxDegreeOfParallelism_3]}. Three Parallel.For.");

            #endregion

            Console.ReadKey();
        }

        public static Matrix CreateMatrix(int row, int col)
        {
            Matrix matrix = new Matrix(row, col);

            for (int i = 0; i < matrix.Row; i++)
            {
                for (int j = 0; j < matrix.Col; j++)
                {
                    matrix[i, j] = RandomData.GetIntNumber(10000);
                }
            }

            return matrix;
        }
    }
}
