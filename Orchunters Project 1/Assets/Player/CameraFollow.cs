using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset; 

    private void FixedUpdate()
    {
        Vector3 desiredPostion = target.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed);
        transform.position = smoothedPostion;

        transform.LookAt(target);
    }








}