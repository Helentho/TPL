using System;

namespace TPL
{
    public class Matrix
    {
        private int _row;
        private int _col;
        private int[,] _matrixBody;

        public Matrix(int row, int col)
        {
            if (row <= 0 && col <= 0)
            {
                throw new ArgumentException("The number of rows should be > 0. " +
                                            "The number of columns should be > 0.");
            }

            _row = row;
            _col = col;
            _matrixBody = new int[_row, _col];
        }

        public int Row => _row;
        public int Col => _col;

        public int this[int row, int col]
        {
            get
            {
                if (!(row < _row && col < _col && row >= 0 && col >= 0))
                {
                    throw new ArgumentException($"The row number has to be < {_row} and >= 0. " +
                                                $"The column number has to be < {_col} and >= 0.");
                }

                return _matrixBody[row, col];
            }
            set
            {
                if (!(row < _row && col < _col && row >= 0 && col >= 0))
                {
                    throw new ArgumentException($"The row number has to be < {_row} and >= 0. " +
                                                $"The column number has to be < {_col} and >= 0.");
                }

                _matrixBody[row, col] = value;
            }
        }
    }
}
