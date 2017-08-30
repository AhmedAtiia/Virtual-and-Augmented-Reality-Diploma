using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCont : MonoBehaviour
{

    private Animator anim;
    public GameObject cube;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetButtonDown(ViveHand.Right, ViveButton.Trigger))
            anim.SetTrigger("dance Trigger");
    }

    public void Inst()
    {
        Instantiate(cube);
    }
    public void Del()
    {
        Destroy(GameObject.FindGameObjectWithTag("cube"));
    }
}
