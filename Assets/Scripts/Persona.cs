using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour {
    public bool hasIssue;
    public QuestionImporter importer;
    PreguntaBase pregunta;
    public PreguntaMenu menu;
    public PersonaSpawner spawner;

    SpriteRenderer _sr;

    Vector3 Direction;
    public float maxSpeed;
    float speed;

    private void Awake() {
        _sr = GetComponent<SpriteRenderer>();
        importer = FindObjectOfType<QuestionImporter>();
        menu = FindObjectOfType<PreguntaMenu>();

        if(transform.position.x > 0) {
            Direction = Vector3.left;
        } else {
            Direction = Vector3.right;
        }
    }

    private void Start() {
        Destroy(this.gameObject, 10.0f);
        if(hasIssue) {
            pregunta = importer.GetPregunta(this);
            speed = maxSpeed;
        }
    }

    private void Update() {
        transform.position += Direction * speed * Time.deltaTime;
    }

    public void StartQuestion() {
        speed = 0;
        Debug.Log("Pregunta pregunta pregunta");
        menu.Appear(pregunta, this);
    }

    public void FinishQuestion() {
        speed = maxSpeed;
    }

    public void ChangeSprite(Sprite newSprite) {
        _sr.sprite = newSprite;
    }



}
