using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject EnemeyPrefab;

	private float timer;
	
	// Use this for initialization
	void Start ()
	{
		timer = 2f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			timer = 2f;

			var enemy = Instantiate (EnemeyPrefab);
			var pos = this.transform.position;
			pos.x = Random.Range(-80, 80);
			enemy.transform.position = pos;
		}
	}
}
