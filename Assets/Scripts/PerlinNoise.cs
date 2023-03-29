using System;
using UnityEngine;

public class PerlinNoise : NoiseGenerator
{
    readonly Vector2[][] parameters;
    readonly float x0, y0;
    readonly float width, height;
    readonly float lw, lh;

    public PerlinNoise(NoiseGenerator generator, float width, float height, int columns, int rows)
    {
        this.width = width;
        this.height = height;

        x0 = - width / 2;
        y0 = - height / 2;
        
    }

    public float Generate(float x, float y, int _i)
    {
        return 0;
    }
}