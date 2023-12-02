using System;

namespace TPL
{
    public class SimpleMatrixMultiplication
    {
        public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2)
        {

            if (matrix1.Col != matrix2.Row)
            {
                return null;
            }

            Matrix matrixResult = new Matrix(matrix1.Row, matrix2.Col);

            for (int i = 0; i < matrix1.Row; i++)
            {
                for (int j = 0; j < matrix2.Col; j++)
                {
                    int item = 0;

                    for (int k = 0; k < matrix2.Row; k++)
                    {
                        item += matrix1[i, k] * matrix2[k, j];
                    }

                    matrixResult[i, j] = item;
                }
            }

            return matrixResult;
        }
    }
}
