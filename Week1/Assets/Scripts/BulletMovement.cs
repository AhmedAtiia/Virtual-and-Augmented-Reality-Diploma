using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	private float timer;
    private Rigidbody rb;
    public float impulse;
    public static GameObject closest;
    public float speed;
    // Use this for initialization
	void Start ()
	{
        rb = GetComponent<Rigidbody>();
        impulse = 50.0f;
        speed = 50.0f;
        if (PlayerShooting.first)
        {
            rb.AddForce(transform.forward * impulse, ForceMode.Impulse);
            timer = 2f;
        }
        if (!PlayerShooting.first)
        {
            //rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            timer = 5f;
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("enemy");
            closest = null;
            float x = Mathf.Infinity;
            Vector3 pos = transform.position;
            if (gos.Length > 0)
            {
                foreach (GameObject go in gos)
                {
                    Vector3 diff = go.transform.position - pos;
                    float y = diff.magnitude;
                    if (y < x)
                    {
                        x = y;
                        closest = go;
                    }
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!PlayerShooting.first && closest) {
            transform.forward = closest.transform.position - transform.position;
            rb.AddForce(transform.forward *(speed), ForceMode.Force);
        }
        //transform.position += transform.forward * 1.2f;

        if (timer > 0)
			timer -= Time.deltaTime;
		else
			Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		Destroy (gameObject);
	}
}
