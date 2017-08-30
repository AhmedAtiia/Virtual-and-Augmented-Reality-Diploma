using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    //public Text scoreText;
    //public Text timeText;
    //private int score;
	// Use this for initialization
	void Start ()
	{
        //score = 0;
        //scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnCollisionEnter(Collision col)
	{
		Destroy (gameObject);
        if(col.gameObject.CompareTag("bullet"))
            ScoreManager.score++;
        //score++;
        //scoreText.text = "Score: " + score;
    }
}
