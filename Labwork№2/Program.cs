using System.Collections.Generic;
using System.Drawing;

class SquareMatrix
{
    int[,] matrix;
    private int size;
    public int ColAndRowCount
    {
        get => size; 
        set
        {
            if (value < 0) 
                throw new ApplicationException("Error! Matrix's size must be greater than 0");
            size = value;
        }
    }
    public SquareMatrix(int count)
    {
        ColAndRowCount = count;
        matrix = new int[ColAndRowCount, ColAndRowCount];
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
        Console.WriteLine("Type size of matrix: ");
        int size = Convert.ToInt32(Console.ReadLine());
        SquareMatrix obj = null;
        try
        {
            obj = new SquareMatrix(size);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message + "\nTry again: ");
            size = Convert.ToInt32(Console.ReadLine());
            obj = new SquareMatrix(size);
        }
        obj.FillElementsRandomly(-10, 30);
        obj.ShowMatrix();
        obj.SumOfPositiveRows();
        obj.MinSumInParallelDiagonals();
    }
}