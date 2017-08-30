using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float Speed;
	
	private Transform camTrans;
	
	// Use this for initialization
	void Start ()
	{
		camTrans = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var dir = camTrans.position - this.transform.position;
		dir.Normalize ();

		this.transform.position += dir * Speed;
	}
}
