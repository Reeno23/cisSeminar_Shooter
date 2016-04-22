using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public int score = 0;

    Text scoreDisplay;
    void Start()
    {
        scoreDisplay = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        score = (GlobalStats.enemiesKilled * 10) + GlobalStats.stopwatch.Elapsed.Seconds;
        scoreDisplay.text="Score: " + score;
    }
}
