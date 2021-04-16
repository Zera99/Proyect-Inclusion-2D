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
            // Feedback Bueno
        } else {
            // Feedback Malo
            Debug.Log("It's wrong");
        }

        menu.Disappear();
    }
}
