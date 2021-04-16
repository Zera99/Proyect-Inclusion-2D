using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Persona target;
    public ScoringSystem Score;

    // Start is called before the first frame update
    void Start() {

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
