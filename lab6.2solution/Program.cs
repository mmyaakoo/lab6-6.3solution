using System;


class Program
{
    static void Main()
    {
        // Example for numbers
        int num1 = 5, num2 = 10;
        Console.WriteLine($"Addition of two integers: {MathOperations.Add(num1, num2)}");

        double double1 = 2.5, double2 = 3.5;
        Console.WriteLine($"Addition of two doubles: {MathOperations.Add(double1, double2)}");

        // Example for arrays
        int[] array1 = { 1, 2, 3 };
        int[] array2 = { 4, 5, 6 };
        Console.WriteLine($"Addition of two integer arrays: [{string.Join(", ", MathOperations.Add(array1, array2))}]");

        double[] doubleArray1 = { 1.5, 2.5, 3.5 };
        double[] doubleArray2 = { 0.5, 1.5, 2.5 };
        Console.WriteLine($"Addition of two double arrays: [{string.Join(", ", MathOperations.Add(doubleArray1, doubleArray2))}]");

        // Example for matrices
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        Console.WriteLine("Addition of two integer matrices:");
        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                Console.Write($"{MathOperations.Add(matrix1[i, j], matrix2[i, j])} ");
            }
            Console.WriteLine();
        }

        double[,] doubleMatrix1 = { { 1.5, 2.5 }, { 3.5, 4.5 } };
        double[,] doubleMatrix2 = { { 0.5, 1.5 }, { 2.5, 3.5 } };
        Console.WriteLine("Addition of two double matrices:");
        for (int i = 0; i < doubleMatrix1.GetLength(0); i++)
        {
            for (int j = 0; j < doubleMatrix1.GetLength(1); j++)
            {
                Console.Write($"{MathOperations.Add(doubleMatrix1[i, j], doubleMatrix2[i, j])} ");
            }
            Console.WriteLine();
        }
    }
}
