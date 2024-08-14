using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var counter = 1;
        int xCounter, yCounter = size;
        int[,] array = new int[size, size];

        for (var i = 1; i < size; i++)
        {
            for (var j = 1; j < size; j++)
            {
                array[i, i] = counter++;
            }
        }

        return array;
    }

    static int[,] RotateMatrixCounterClockwise(int[,] oldMatrix)
    {
        int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
        int newColumn, newRow = 0;
        for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
        {
            newColumn = 0;
            for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
            {
                newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                newColumn++;
            }
            newRow++;
        }
        return newMatrix;
    }
}
