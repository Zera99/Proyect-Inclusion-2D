using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class PreguntaMenu : MonoBehaviour {
    public GameObject menu;
    Persona currentPersona;
    public TextMeshProUGUI PregText;
    public Respuesta firstOption;
    public Respuesta secondOption;
    public Respuesta thirdOption;

    private void Start() {
        menu.gameObject.SetActive(false);
    }

    public void Appear(PreguntaBase preg, Persona p) {
        PregText.text = preg.Pregunta;
        currentPersona = p;
        int randomChoice = Random.Range(0, 3);
        switch (randomChoice) {
            case 0: {
                firstOption.RespText.text = preg.RespuestaCorrecta;
                secondOption.RespText.text = preg.RespuestaA;
                thirdOption.RespText.text = preg.RespuestaB;
                break;
            }
            case 1: {
                firstOption.RespText.text = preg.RespuestaA;
                secondOption.RespText.text = preg.RespuestaCorrecta;
                thirdOption.RespText.text = preg.RespuestaB;
                break;
            }
            case 2: {
                firstOption.RespText.text = preg.RespuestaB;
                secondOption.RespText.text = preg.RespuestaA;
                thirdOption.RespText.text = preg.RespuestaCorrecta;
                break;
            }

        }

        menu.gameObject.SetActive(true);


    }

    public void Disappear() {
        currentPersona.FinishQuestion();
        menu.gameObject.SetActive(false);
    }

}
