using System.Threading.Tasks;

namespace TPL
{
    public class ParallelMatrixMultiplication_2
    {
        public static Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Col != matrix2.Row)
            {
                return null;
            }

            Matrix matrixResult = new Matrix(matrix1.Row, matrix2.Col);

            Parallel.For(0, matrix1.Row, i =>
            {
                Parallel.For(0, matrix2.Col, j =>
                {
                    int item = 0;

                    for (int k = 0; k < matrix2.Row; k++)
                    {
                        item += matrix1[i, k] * matrix2[k, j];
                    }

                    matrixResult[i, j] = item;
                });
            });

            return matrixResult;
        }
    }
}
