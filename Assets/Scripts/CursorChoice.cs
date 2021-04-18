using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChoice : MonoBehaviour
{
    PlayerSO playerData;
    public Texture2D myTexture;

    public void OnClick() {
        playerData.cursorTexture = myTexture;
    }
}
