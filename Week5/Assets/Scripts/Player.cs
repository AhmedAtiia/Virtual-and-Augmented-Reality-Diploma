using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject leftHand;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightHand.transform.position = ViveInput.GetPosition(ViveHand.Right);
        rightHand.transform.rotation = ViveInput.GetRotation(ViveHand.Right);
        leftHand.transform.position = ViveInput.GetPosition(ViveHand.Left);
        leftHand.transform.rotation = ViveInput.GetRotation(ViveHand.Left);
    }
}
