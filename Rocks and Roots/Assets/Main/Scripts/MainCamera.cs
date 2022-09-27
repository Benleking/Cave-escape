using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset = new Vector3(0, 10, 0);

    private void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerScript>().transform;
        }
    }

    private void FixedUpdate()
    {
        
        Vector3 goalPos = target.position;
        transform.position = goalPos + offset;
        transform.LookAt(target);
    }

}
