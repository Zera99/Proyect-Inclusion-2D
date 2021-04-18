using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChoice : MonoBehaviour
{
    public PlayerSO playerData;
    public Texture2D myTexture;

    public void OnClick() {
        playerData.cursorTexture = myTexture;
        Cursor.SetCursor(playerData.cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
