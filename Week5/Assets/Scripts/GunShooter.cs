using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour
{

    public ViveHand hand;
    public GameObject bullet;
    public Transform muzleTrans;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetButtonDown(hand, ViveButton.Trigger))
        {
            var bull = Instantiate(bullet);
            bull.transform.position = muzleTrans.position;
            bull.transform.rotation = muzleTrans.rotation;
            bull.GetComponent<Rigidbody>().AddForce(muzleTrans.forward * 10, ForceMode.Impulse);
        }
    }
}
