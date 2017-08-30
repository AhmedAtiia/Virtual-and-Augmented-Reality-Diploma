using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Bullet1Prefab;
    public GameObject Bullet2Prefab;
    public static bool first;
    // Use this for initialization
    void Start ()
	{
        first = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
            shoot();
		}
	}
	public void shoot(){
        if (first)
        {
            var bullet = Instantiate(Bullet1Prefab);
            bullet.transform.position = this.transform.position + this.transform.forward * 1.4f;
            bullet.transform.rotation = this.transform.rotation;
        }
        if (!first)
        {
            var bullet = Instantiate(Bullet2Prefab);
            bullet.transform.position = this.transform.position + this.transform.forward * 1.4f;
            bullet.transform.rotation = this.transform.rotation;
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("enemy");
            if (gos.Length == 0)
            {
                Destroy(bullet);
            }
        }

    }
} 
