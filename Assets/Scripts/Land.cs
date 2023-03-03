using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Land : MonoBehaviour
{
    public Texture2D[] availableTrees = new Texture2D[0];
    public float minRadiusX = 0, minRadiusY = 0;
    public float adaptationLength = 0;
    public float maxHeight = 100;

    public int seed = 0;


    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
