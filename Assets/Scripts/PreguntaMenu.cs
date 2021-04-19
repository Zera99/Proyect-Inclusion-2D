using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class PreguntaMenu : MonoBehaviour {
    public bool isAnswering;
    public GameObject menu;
    Persona currentPersona;
    public TextMeshProUGUI PregText;
    public Respuesta firstOption;
    public Respuesta secondOption;
    public Respuesta thirdOption;

    float timeLeft;
    public float maxTime;

    public AudioClip goodFeedback;
    public AudioClip badFeedback;
    public AudioSource source;

    private void Awake() {
        timeLeft = maxTime;
    }
    private void Start() {
        menu.gameObject.SetActive(false);
    }
    private void Update() {
        if (isAnswering) {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0) {
                Disappear(false);
            }
        }
    }

    public void Appear(PreguntaBase preg, Persona p) {
        currentPersona = p;
        currentPersona.hasIssue = false;
        isAnswering = true;
        PregText.text = preg.Pregunta;
        int randomChoice = Random.Range(0, 3);
        switch (randomChoice) {
            case 0: {
                firstOption.RespText.text = preg.RespuestaCorrecta;
                firstOption.isCorrect = true;
                secondOption.RespText.text = preg.RespuestaA;
                secondOption.isCorrect = false;
                thirdOption.RespText.text = preg.RespuestaB;
                thirdOption.isCorrect = false;
                break;
            }
            case 1: {
                firstOption.RespText.text = preg.RespuestaA;
                firstOption.isCorrect = false;
                secondOption.RespText.text = preg.RespuestaCorrecta;
                secondOption.isCorrect = true;
                thirdOption.RespText.text = preg.RespuestaB;
                thirdOption.isCorrect = false;
                break;
            }
            case 2: {
                firstOption.RespText.text = preg.RespuestaB;
                firstOption.isCorrect = false;
                secondOption.RespText.text = preg.RespuestaA;
                secondOption.isCorrect = false;
                thirdOption.RespText.text = preg.RespuestaCorrecta;
                thirdOption.isCorrect = true;
                break;
            }

        }

        menu.gameObject.SetActive(true);


    }

    public void Disappear(bool correct) {
        isAnswering = false;
        currentPersona.FinishQuestion();
        menu.gameObject.SetActive(false);
        timeLeft = maxTime;

        if(correct) {
            currentPersona.FeedbackBueno();
            source.PlayOneShot(goodFeedback);
        } else {
            source.PlayOneShot(badFeedback);
        }


    }

}
