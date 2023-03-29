using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationpublic : MonoBehaviour
{
    GameObject objet_1;

    // Start is called before the first frame update
    void Start()
    {
        objet_1 = new GameObject("objet_1");
        objet_1.transform.Rotate(0f, 90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
