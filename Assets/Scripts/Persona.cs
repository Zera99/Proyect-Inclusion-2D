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
    public float speed;

    private void Awake() {
        _sr = GetComponent<SpriteRenderer>();
        importer = FindObjectOfType<QuestionImporter>();
        menu = FindObjectOfType<PreguntaMenu>();


    }

    private void Start() {

        speed = maxSpeed;

        if (hasIssue) {
            pregunta = importer.GetPregunta(this);
        }

        if (transform.position.x > 0) {
            Direction = Vector3.left;
        } else {
            Direction = Vector3.right;
        }
    }

    private void Update() {
        transform.position += Direction * speed * Time.deltaTime;

        if (transform.position.x > spawner.maxX || transform.position.x < spawner.minX) {
            StartCoroutine(DespawnPersona());
        }
    }

    public void StartQuestion() {
        Debug.Log("Pregunta pregunta pregunta");
        if (!menu.isAnswering) {
            spawner.StartAnswering();
            menu.Appear(pregunta, this);
        }

    }

    public void FinishQuestion() {
        speed = maxSpeed;
        spawner.StopAnswering();
        importer.RemovePregunta(this.pregunta);
    }

    public void ChangeSprite(Sprite newSprite) {
        _sr.sprite = newSprite;
    }

    IEnumerator DespawnPersona() {
        yield return new WaitForSeconds(2.0f);
        spawner.RemovePersona(this);
        Destroy(this.gameObject);
    }

}
