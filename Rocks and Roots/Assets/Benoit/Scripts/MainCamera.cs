using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector3 _offset = new Vector3(0, 0, -5);

    private void FixedUpdate()
    {
        
        Vector3 goalPos = _target.position;
        goalPos.y = transform.position.y;
        transform.position = goalPos + _offset;
        transform.LookAt(_target);
    }

}
