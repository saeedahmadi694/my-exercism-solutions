using System;

public class SpiralMatrix
{

    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int num = 1;
        int totalLayers = (size + 1) / 2; 

        for (int layer = 0; layer < totalLayers; layer++)
        {
            for (int i = layer; i < size - layer; i++)
            {
                matrix[layer, i] = num++;
            }
            for (int i = layer + 1; i < size - layer; i++)
            {
                matrix[i, size - layer - 1] = num++;
            }
            for (int i = size - layer - 2; i >= layer; i--)
            {
                matrix[size - layer - 1, i] = num++;
            }
            for (int i = size - layer - 2; i > layer; i--)
            {
                matrix[i, layer] = num++;
            }
        }

        return matrix;
    }
}
