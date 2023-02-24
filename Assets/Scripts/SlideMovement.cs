using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SlideMovement : MonoBehaviour
{
    public Transform _referencePoint;
    public Transform _velocityHand;
    public Transform _camera;
    public float _velocity = 0f;


    public float _speed = 10.0f;
    private float _increment;

    private Transform _tfPlayer;
    private float distMax = 0.45f;
    private float distMin = 0.24f;

    // Start is called before the first frame update
    void Start()
    {
        _tfPlayer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _velocityHand.position - _referencePoint.position;
        direction.y = 0;
        float dist = direction.magnitude;
        //float dist = (_referencePoint.position - _velocityHand.position).magnitude;                                                                               //Distance 3D

        dist = Mathf.Clamp(dist, distMin, distMax);
        Debug.Log(dist);
        _increment = _speed * Time.deltaTime * (dist - distMin);

        _tfPlayer.Translate(direction.normalized * _increment);
    }

    private void UpDown()
    {

    }
}
