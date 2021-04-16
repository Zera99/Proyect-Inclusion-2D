using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour {
    float _totalScore;
    float timeLeft;
    float maxTime;
    bool isInQuestion;

    public float TotalScore { get; set; }


    private void Update() {
        if(isInQuestion) {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0) {
                Wrong();
            }
        }
    }


    public void AddScore() {
        TotalScore += timeLeft;
    }

    public void Wrong() {
        ResetTimer();
    }

    void ResetTimer() {
        timeLeft = maxTime;
    }
}
