using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Persona target;
    bool isAnswering;
    public ScoringSystem Score;

    // Start is called before the first frame update
    void Start() {
        isAnswering = false;
    }

    // Update is called once per frame
    void Update() {
        if (!isAnswering && Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform != null && !isAnswering) {
                target = rayHit.transform.gameObject.GetComponent<Persona>();
                if (target.hasIssue) {
                    isAnswering = true;
                    target.StartQuestion();
                }
            }
        }
    }
}
