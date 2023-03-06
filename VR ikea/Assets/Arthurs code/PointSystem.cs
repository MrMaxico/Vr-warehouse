using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public float timeLimit = 30f; // The time limit for the task in seconds
    public int pointsPerTask = 100; // The number of points to award for completing the task
    public Text scoreText; // The UI text component that displays the player's score

    private float timeRemaining;
    private bool isTaskComplete;
    private int score;

    // Start is called before the first frame update
    void Start() {
        timeRemaining = timeLimit;
        isTaskComplete = false;
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!isTaskComplete) {
            // Update the timer
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0) {
                // The timer has run out
                timeRemaining = 0;
                isTaskComplete = true;
            }
        }

        // Update the score if the task is complete
        if (isTaskComplete) {
            score += pointsPerTask;
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
