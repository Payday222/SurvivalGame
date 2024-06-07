using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    Vector3 camoffset;
    void Start()
    {
        camoffset = transform.position - target.position; //    - new Vector3(0, 0, 0);
    }
    void Update()
    {
        transform.position = target.position + camoffset;
    }
}
