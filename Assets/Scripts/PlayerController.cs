using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Persona target;
    public ScoringSystem Score;
    PlayerSO playerData;

    void OnMouseEnter() {
        if(playerData.cursorTexture != null)
            Cursor.SetCursor(playerData.cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Start is called before the first frame update
    void Start() {
        // Setear Cursor
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform != null) {
                target = rayHit.transform.gameObject.GetComponent<Persona>();
                if (target.hasIssue) {
                    target.StartQuestion();
                }
            }
        }
    }
}
