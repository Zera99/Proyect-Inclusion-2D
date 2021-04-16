using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Respuesta : MonoBehaviour
{
    public ScoringSystem scores;
    public bool isCorrect;
    public TMPro.TextMeshProUGUI RespText;

    public void OnClick(PreguntaMenu menu) {

        if(isCorrect) {
            Debug.Log("It's correct");
            scores.AddScore();
        } else {
            Debug.Log("It's wrong");
            scores.Wrong();
        }

        menu.Disappear();
    }
}
