using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float offsetY;
    public float offsetX;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void FixedUpdate()
    {
        //transform.position = new Vector3(target.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        transform.position = new Vector3
            (
                Mathf.Clamp(target.position.x + offsetX, minX, maxX),
                target.position.y + offsetY,
                transform.position.z
            ) ;
    }
}
