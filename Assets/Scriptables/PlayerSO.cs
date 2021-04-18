using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerData")]
public class PlayerSO : ScriptableObject {
    public int TotalScore;
    public Texture2D cursorTexture;

    public void Init() {
        TotalScore = 0;

    }
}
