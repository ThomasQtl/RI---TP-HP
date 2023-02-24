using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SlideMovement : MonoBehaviour
{
    public Transform _referencePoint;
    public Transform _velocityHand;
    public float _velocity = 0f;


    public float _speed = 10.0f;
    private float _increment;

    private Transform _tfPlayer;
    private float distMin = 100;
    private float distMax = 0;

    // Start is called before the first frame update
    void Start()
    {
        _tfPlayer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Pow(_referencePoint.position.x - _velocityHand.position.x, 2) + Mathf.Pow(_referencePoint.position.y - _velocityHand.position.y, 2);     //Distance 2D
        dist = Mathf.Sqrt(dist);

        //float dist = (_referencePoint.position - _velocityHand.position).magnitude;                                                                               //Distance 3D

        dist = Mathf.Clamp(dist, distMin, distMax);

        _increment = _speed * Time.deltaTime * dist;

        _tfPlayer.Translate(Input.GetAxis("Horizontal") * _increment, 0, Input.GetAxis("Vertical") * _increment);
    }

    private void UpDown()
    {

    }
}
