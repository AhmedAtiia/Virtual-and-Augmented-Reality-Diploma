using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{

    public Button bullet1;
    public Button bullet2;

    // Use this for initialization
    void Start()
    {

        //GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //bullet1.onClick.AddListener(ChangeToBullet1);
        //bullet2.onClick.AddListener(ChangeToBullet2);
    }

    public void ChangeToBullet1()
    {
        Debug.Log("One");
        PlayerShooting.first = true;
    }

    public void ChangeToBullet2()
    {
        Debug.Log("Two");
        PlayerShooting.first = false;
    }
}
