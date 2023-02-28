using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PerlinNoise
{
    float columns, rows;

    float[][] parameters;

    public PerlinNoise(int seed, int columns, int rows)
    {
        var rnd = new System.Random(seed);

        parameters = new float[rows][];

        for (int j = 0; j < rows; j++)
        {
            var column = new float[columns];

            for (int i = 0; i < columns; i++)
            {
                column[i] = rnd.
            }

            parameters[j] = column;
        }
    }
}

public class Land : MonoBehaviour
{
    public Texture2D[] availableTrees = new Texture2D[0];
    public float minRadiusX = 0, minRadiusY = 0;
    public float adaptationLength = 0;
    public float maxHeight = 100;

    public int seed = 0;


    // Start is called before the first frame update
    void Start()
    {
        hash = new XXHash(seed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
