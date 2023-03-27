using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SlideMovement : MonoBehaviour
{
    public Transform _referencePoint;
    public Transform _velocityHand;
    public SteamVR_Action_Vector2 input;


    public float _speed;
    public float _forceMultiplieur;
    public float _maxSpeed;
    private float _increment;

    private Rigidbody _rbPlayer;
    private float distMax = 0.75f;
    private float distMin = 0.40f;

    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = _velocityHand.position - _referencePoint.position;
        direction.y = 0;
        float dist = direction.magnitude;
        if (input.setActive)
        {
            direction.y += input.axis.y * Time.deltaTime * 100;
        }
        else
        {
            direction.y -= _rbPlayer.velocity.y;
        }
        
        dist = Mathf.Clamp(dist, distMin, distMax);
        _increment = _speed * Time.fixedDeltaTime * (dist - distMin) * _forceMultiplieur;
        if(_increment == 0)
        {
            _rbPlayer.AddForce(-1 * _rbPlayer.velocity, ForceMode.Acceleration);
        }
        else
        {
            if (Mathf.Abs(Vector3.Angle(direction, _rbPlayer.velocity)) > 45)
            {
                _increment *= _forceMultiplieur;
            }
            _rbPlayer.AddForce(direction.normalized * _increment, ForceMode.Acceleration);
            if(_rbPlayer.velocity.magnitude > _maxSpeed)
            {
                _rbPlayer.velocity = _rbPlayer.velocity.normalized * _maxSpeed;
            }
        }
    }
}
