using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    private ViveHand hand;
    private Rigidbody rb;
    private GameObject gobj;
    private bool isExist;

    // Use this for initialization
    void Start()
    {
        isExist = false;
        hand = ViveInput.GetHand(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ViveInput.GetButtonDown(hand, ViveButton.Trigger))
        {
            Collider[] cols = Physics.OverlapSphere(gameObject.transform.position, 0.05f);
            if (cols.Length > 0 && cols[0].gameObject.GetComponent<Rigidbody>())
            {
                gobj = cols[0].gameObject;
                rb = cols[0].gameObject.GetComponent<Rigidbody>();
                isExist = true;
                gobj.transform.SetParent(gameObject.transform);
                rb.isKinematic = true;
            }
        }

        if (ViveInput.GetButtonUp(hand, ViveButton.Trigger) && isExist)
        {
            {
                rb.isKinematic = false;
                gobj.transform.SetParent(null);
                rb.velocity = ViveInput.GetVelocity(hand);
                rb.angularVelocity = ViveInput.GetAngularVelocity(hand);
                isExist = false;
            }
        }
    }
}
