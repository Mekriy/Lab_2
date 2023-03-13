using System.Collections.Generic;
class SquareMatrix
{
    int[,] matrix;
    public int ColAndRowCount { get; set; }
    public SquareMatrix(int count)
    {
        matrix = new int[count, count];
        ColAndRowCount = matrix.GetLength(0);
    }
    public void FillElementsRandomly(int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i < ColAndRowCount; i++)
            for (int j = 0; j < ColAndRowCount; j++)
                matrix[i, j] = rand.Next(min, max + 1);
    }
    public void ShowMatrix()
    {
        for (int i = 0; i < ColAndRowCount; i++) {
            for (int j = 0; j < ColAndRowCount; j++)
            {
                Console.Write(matrix[i, j]+ " ");
            }
            Console.WriteLine();
        }
                
    }
    public void SumOfPositiveRows() {
        int[] sum = new int[ColAndRowCount];
        for(int i = 0; i < ColAndRowCount; i++)
        {
            for(int j = 0; j < ColAndRowCount; j++)
            {
                if (matrix[i, j] > 0)
                    sum[i] += matrix[i, j];
                else
                {
                    sum[i] = 0;
                    break;
                }
            }
            Console.WriteLine("Sum of all positive elements in row["+i+"]: " + sum[i]);
        }
    }
    public void MinSumInParallelDiagonals() {
        int[] sum = new int[2];
        for(int i = 0; i < ColAndRowCount; i++)
        {
            for (int j = 0; j < ColAndRowCount; j++)
            {
                if (i == j + 1)
                {
                    sum[0] += matrix[i, j];
                }
                else if (j == i + 1)
                {
                    sum[1] += matrix[i, j];
                }
            }
        }
        int minSum = int.MaxValue;
        for(int i = 0; i < 2; i++)
        {
            if (sum[i] < minSum)
            {
                minSum = sum[i];
            }
        }
        Console.WriteLine("All sums of diagonals parallel to the main diagonal:");
        for (int i = 0; i < 2; i++)
        {
            Console.Write(sum[i] + " ");
        }
        Console.WriteLine("\nMin sum of diagonals parallel to the main diagonal: " + minSum);
    }
    public static void Main()
    {
        SquareMatrix obj = new SquareMatrix(5);
        obj.FillElementsRandomly(-10, 30);
        obj.ShowMatrix();
        obj.SumOfPositiveRows();
        obj.MinSumInParallelDiagonals();
    }
}