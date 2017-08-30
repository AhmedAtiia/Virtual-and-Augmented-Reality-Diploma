using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float Speed;

    private Vector3 currRot;

    // Use this for initialization
    void Start()
    {
        currRot.y = 180f;
    }

    // Update is called once per frame
    void Update()
    {
        currRot.x -= Input.GetAxis("Mouse Y") * Speed;
        currRot.y += Input.GetAxis("Mouse X") * Speed;

        transform.rotation = Quaternion.Euler(currRot);
    }
}
