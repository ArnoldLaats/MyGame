using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Vector2 direction;

    public float speed;

    void Update()
    {
        MovePlatform();
    }

    public void MovePlatform()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
