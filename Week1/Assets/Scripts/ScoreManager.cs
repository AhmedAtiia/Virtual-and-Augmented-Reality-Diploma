using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public static int score;
    private float time;
    public Text scoreText;
    public Text timeText;
    // Use this for initialization
    void Start()
    {
        score = 0;
        time = 0;
        scoreText.text = "Score: " + score;
        timeText.text = "Time: " + time;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + (int)time;
        scoreText.text = "Score: " + score;
    }
}
