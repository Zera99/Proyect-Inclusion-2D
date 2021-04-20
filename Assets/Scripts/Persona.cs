using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour {
    public bool hasIssue;
    public bool isAdult;
    public QuestionImporter importer;
    PreguntaBase pregunta;
    public PreguntaMenu menu;
    public PersonaSpawner spawner;

    SpriteRenderer _sr;
    Color originalColor;
    public Color onMouseOverColor;
    public GameObject globito;

    Vector3 Direction;
    public float maxSpeed;
    public float speed;
    bool isFlipped;
    Animator _anim;
    Animator globitoAnimator;


    private void Awake() {
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        globitoAnimator = globito.GetComponent<Animator>();
        importer = FindObjectOfType<QuestionImporter>();
        menu = FindObjectOfType<PreguntaMenu>();
        originalColor = _sr.color;

    }

    private void Start() {

        speed = maxSpeed;

        if (hasIssue) {
            globito.SetActive(true);
            pregunta = importer.GetPregunta(this);
            if (isAdult) {
                globitoAnimator.Play("GlobitoEstereotipo");
            } else {
                globitoAnimator.Play("GlobitoPregunta");
            }
        }

        if (transform.position.x > 0) {
            Direction = Vector3.left;
        } else {
            Direction = Vector3.right;
            FlipGlobito();
            if (hasIssue) {
                if (isAdult) {
                    globito.GetComponent<SpriteRenderer>().flipX = true;
                    globitoAnimator.Play("GlobitoEstereotipo");
                } else {
                    globitoAnimator.Play("GlobitoPreguntaReverse");
                }
            }

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

    public void FinishQuestion(bool correct) {
        if (!correct)
            globito.SetActive(false);

        speed = maxSpeed;
        spawner.StopAnswering();
        importer.RemovePregunta(this.pregunta);
    }

    public void ChangeSprite(Sprite newSprite, AnimationClip clip) {
        _sr.sprite = newSprite;
        _anim.Play(clip.name);
    }

    IEnumerator DespawnPersona() {
        yield return new WaitForSeconds(2.0f);
        spawner.RemovePersona(this);
        Destroy(this.gameObject);
    }

    void FlipGlobito() {
        globito.transform.localPosition = new Vector3(globito.transform.localPosition.x * -1 + 0.055f, globito.transform.localPosition.y, globito.transform.localPosition.z);
        _sr.flipX = true;
        isFlipped = true;


    }

    public void FeedbackBueno() {
        if (isFlipped) {
            globito.GetComponent<SpriteRenderer>().flipX = true;
        }
        globitoAnimator.Play("GlobitoCorrecto");
    }

    private void OnMouseEnter() {
        if(hasIssue)
            _sr.color = onMouseOverColor;
    }

    private void OnMouseExit() {
        _sr.color = originalColor;
    }
}
