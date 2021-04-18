using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChoicePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform != null) {
                rayHit.transform.gameObject.GetComponent<CursorChoice>().OnClick();

            }
        }
    }
}
