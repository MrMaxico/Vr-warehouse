using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public float timeLimit = 30f; // The time limit for the task in seconds
    public float pointsOnComplete = 100; // The number of points to award for completing the task
    public Text scoreText; // The UI text component that displays the player's score

    public float timeSpent;
    public float overTime;
    public float overTimePointsPanneltyMultiplier;
    private bool isTaskComplete;
    private float score;

    // Start is called before the first frame update
    void Start() {
        isTaskComplete = false;
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!isTaskComplete) {
            // Update the timer
            timeSpent += Time.deltaTime;
        }

        // Update the score if the task is complete
        if (isTaskComplete) {
            
        }
    }
    public void LevelComplete() {
        if(timeSpent > timeLimit) {
            overTime = timeSpent - timeLimit;
            pointsOnComplete =- overTime * overTimePointsPanneltyMultiplier;
        }
        score = pointsOnComplete;
        scoreText.text = "Score: " + score.ToString();
    }
}
