using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour {
    public PlayerSO PlayerData;

    private void Awake() {
        PlayerData.Init();
    }

    public void AddScore() {
        PlayerData.TotalScore++;

    }

}
