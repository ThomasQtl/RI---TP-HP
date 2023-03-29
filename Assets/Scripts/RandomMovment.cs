using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovment : MonoBehaviour
{
    // Start is called before the first frame update
    Collider _area_Collider;
    Vector3 _direction = new Vector3(0, 0, 0);
    Vector3 _randVec;
    public int _speed = 50;
    void Start()
    {
        _area_Collider = GameObject.Find("AreaOfMovement").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        _randVec = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        _direction += _randVec;
        if (_direction.x < -1.0f) _direction.x = -1.0f;
        if (_direction.x > 1.0f) _direction.x = 1.0f;
        if (_direction.y < -1.0f) _direction.y = -1.0f;
        if (_direction.y > 1.0f) _direction.y = 1.0f;
        if (_direction.z < -1.0f) _direction.y = -1.0f;
        if (_direction.z > 1.0f) _direction.y = 1.0f;

        transform.position += (_speed * _direction * Time.deltaTime);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "AreaOfMovement")
        {
            Debug.Log("Putting Back in Area cause of trigger");
            _direction = Vector3.Normalize(_area_Collider.gameObject.transform.position - transform.position);
            PutBackInBounds(_area_Collider);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "AreaOfMovement")
        {
            _direction = -_direction;
        }
    }

    bool IsInArea(Collider other, Vector3 pos)
    {
        if (other == null) return false;
        if (other.bounds.Contains(pos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void PutBackInBounds(Collider other)
    {
        int _count = 0;
        while (!IsInArea(_area_Collider, transform.position)) {
            _count += 1;
            transform.position += (_speed * Vector3.Normalize(_area_Collider.gameObject.transform.position - transform.position) * Time.deltaTime);
            //Debug.Break();
        }
        Debug.Log("Did My thing : " + _count + " times");
    }
}
