using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Land : MonoBehaviour
{
    public Texture2D[] availableTrees = new Texture2D[0];

    [Min(0)]
    public float minRadiusX = 0;
    [Min(0)]
    public float minRadiusY = 0;

    public float adaptationLength = 0;
    public float maxHeight = 100;

    [Min(0.001f)]
    public float width = 10;
    [Min(0.001f)]
    public float height = 10;

    [Min(2)]
    public int rows = 100;

    [Min(2)]
    public int cols = 100;

    public uint seed = 0;

    private NoiseGenerator generator;

    private Mesh mesh;

    void SpawnGenerator()
    {
        XXNoiseGenerator noise = new XXNoiseGenerator(seed);


        generator = noise;
    }

    void Awake()
    {
        SpawnGenerator();

        GenerateMesh();
    }

    void GenerateMesh()
    {
        mesh = new Mesh();

        (mesh.vertices, mesh.uv) = GeneratePoints();

        mesh.triangles = GenerateTriangles();

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().sharedMesh = mesh;
    }

    (Vector3[], Vector2[]) GeneratePoints()
    {
        Vector3[] points = new Vector3[rows * cols];
        Vector2[] uvs = new Vector2[rows * cols];

        float x0 = - width / 2f;
        float y0 = - height / 2f;

        float dx = width / (rows-1);
        float dy = height / (cols-1);
        uint i = 0;

        for (uint row = 0; row < rows; row++)
        {
            float x = x0 + dx * row;

            for (uint col = 0; col < cols; col++)
            {
                float y = y0 + dy * col;

                points[i] = new Vector3(x, maxHeight * generator.Generate(x, y), y);
                uvs[i] = new Vector2(x, y);

                i++;
            }
        }

        return (points, uvs);
    }

    int PositionFromIndex(int row, int col)
    {
        return row * cols + col;
    }

    int[] GenerateTriangles()
    {
        int[] triangles = new int[6 * (rows - 1) * (cols - 1)];
        int i = 0;

        for (int row = 0; row < rows - 1; row ++)
        {
            for (int col = 0; col < cols - 1; col ++)
            {
                triangles[i++] = PositionFromIndex(row + 1, col);
                triangles[i++] = PositionFromIndex(row, col);
                triangles[i++] = PositionFromIndex(row, col + 1);
                triangles[i++] = PositionFromIndex(row + 1, col);
                triangles[i++] = PositionFromIndex(row, col + 1);
                triangles[i++] = PositionFromIndex(row + 1, col + 1);
            }
        }

        return triangles;
    }

    void Update()
    {
        SpawnGenerator();

        GenerateMesh();
    }
}
