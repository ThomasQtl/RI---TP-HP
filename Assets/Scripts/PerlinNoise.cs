using System;
using UnityEngine;

public class PerlinNoise : NoiseGenerator
{
    readonly Vector2[][] parameters;
    readonly float width, height;
    readonly float lw, lh;

    public PerlinNoise(NoiseGenerator generator, float width, float height, int columns, int rows)
    {
        this.width = width;
        this.height = height;

        lw = width / columns;
        lh = height / rows;

        parameters = new Vector2[rows][];

        for (int j = 0; j < rows; j++)
        {
            var column = new Vector2[columns];
            float y = j * lh;

            for (int i = 0; i < columns; i++)
            {
                float x = i * lw;

                float dx = (float)generator.Next(x, y);
                float dy = (float)generator.Next(x, y);

                float norm = MathF.Sqrt(x * x + y * y);

                column[i] = new Vector2(
                    x / norm,
                    y / norm
                );
            }

            parameters[j] = column;
        }
    }

    float SmoothStep(float w)
    {
        if (w < 0) return 0;
        if (w > 1) return 1;
        return w * w * (3 - 2 * w);
    }

    float Interpolate(float a0, float a1, float w)
    {
        return a0 + (a1 - a0) * SmoothStep(w);
    }

    float DotGridGradient(int i, int j, float x, float y)
    {
        float dx = x - lw * i;
        float dy = y - lh * i;

        Vector2 gradient = parameters[i][j];

        return dx * gradient.x + dy * gradient.y;
    }

    public float Generate(float x, float y)
    {
        int i0 = (int)(x / lw);
        int i1 = i0 + 1;

        int j0 = (int)(y / lh);
        int j1 = j0 + 1;

        float sx = x - i0 * lw;
        float sy = y - j0 * lh;

        float n0, n1;

        n0 = DotGridGradient(i0, j0, x, y);
        n1 = DotGridGradient(i1, j0, x, y);

        float ix0 = Interpolate(n0, n1, sx);

        n0 = DotGridGradient(i0, j1, x, y);
        n1 = DotGridGradient(i1, j1, x, y);

        float ix1 = Interpolate(n0, n1, sx);

        return Interpolate(ix0, ix1, sy);
    }
}