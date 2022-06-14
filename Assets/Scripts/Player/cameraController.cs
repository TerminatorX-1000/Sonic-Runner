using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform _target;
    private Vector3 _offset;

    public float smoothSpeed = 0.15f;
    void Start()
    {
       _target = GameObject.FindGameObjectWithTag("Player").transform;
       _offset = transform.position - _target.position;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
       transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
