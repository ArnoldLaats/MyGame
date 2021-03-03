using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        if(target == null)
        {
            target = GameObject.Find("Player").transform;
        }
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x + offset.x,offset.y, offset.z);
    }
}
