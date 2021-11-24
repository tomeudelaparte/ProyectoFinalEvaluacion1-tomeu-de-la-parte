using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool isVertical = false;
    public float speed = 2000f;

    void Update()
    {
        if (!isVertical)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
        }
    }
}
