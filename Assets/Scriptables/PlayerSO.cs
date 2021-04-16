using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerSO : ScriptableObject {
    public int TotalScore;

    public void Init() {
        TotalScore = 0;

    }
}
