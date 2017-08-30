using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VR;

public class Player : NetworkBehaviour
{

    public GameObject rightHand;
    public GameObject leftHand;
    public float rotationSpeed;
    private Transform camTrans;
    float xMouse;
    float yMouse;
    public ViveHand rHand;
    public ViveHand lHand;
    // Use this for initialization
    void Start()
    {
        rHand = ViveHand.Right;
        lHand = ViveHand.Left;
        camTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority) return;
        if (!VRDevice.isPresent)
        {
            float h = Input.GetAxis("Horizontal") * Time.deltaTime * 3f;
            float v = Input.GetAxis("Vertical") * Time.deltaTime * 3f;
            xMouse += Input.GetAxis("Mouse X");
            yMouse += Input.GetAxis("Mouse Y");

            camTrans.rotation = Quaternion.Euler(-yMouse, xMouse, 0);

            //camTrans.Rotate(-yMouse * rotationSpeed * Time.deltaTime , xMouse * rotationSpeed * Time.deltaTime, 0);
            //camTrans.right += new Vector3(h, 0, 0);
            //camTrans.forward += new Vector3(0, 0, v);
            //pos.x += h * 20 * Time.deltaTime;
            //pos.z = v * 20 * Time.deltaTime;
            //camTrans.Translate(h * 20 * Time.deltaTime, 0, v*20*Time.deltaTime);
            var pos = camTrans.position;
            pos += camTrans.forward * v + camTrans.right * h;
            pos.y = 1.7f;
            camTrans.position = pos;
        }
        else
        {
            rightHand.transform.position = ViveInput.GetPosition(rHand);
            rightHand.transform.rotation = ViveInput.GetRotation(rHand);

            leftHand.transform.position = ViveInput.GetPosition(lHand);
            leftHand.transform.rotation = ViveInput.GetRotation(lHand);

        }

        transform.position = camTrans.position;
        transform.rotation = camTrans.rotation;
    }

    public override void OnStartLocalPlayer()
    {
        Color col = Random.ColorHSV();
        gameObject.GetComponent<MeshRenderer>().material.color = col;
        rightHand.GetComponent<MeshRenderer>().material.color = col;
        leftHand.GetComponent<MeshRenderer>().material.color = col;
    }
}
