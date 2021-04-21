using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.Networking;

public class QuestionImporter : MonoBehaviour {

    string PreguntasPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Preguntas.json");
    string EstereotiposPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Estereotipos.json");
    string PreguntaJson;
    string EstereotipoJson;
    public PreguntasObject AllPreguntas;
    public PreguntasObject AllEstereotipos;
    public PersonaSpawner personaSpawner;
    Persona currentPersona;
    int randomIndex;

    [SerializeField]
    public List<PreguntaBase> preguntasInUse;

    private void Awake() {
        StartCoroutine(GetJson());
    }

    IEnumerator GetJson() {
        WWW www = new WWW(PreguntasPath);
        yield return www;
        PreguntaJson = www.text;

        WWW www2 = new WWW(EstereotiposPath);
        yield return www;
        EstereotipoJson = www.text;


        AllPreguntas = JsonUtility.FromJson<PreguntasObject>(PreguntaJson);
        AllEstereotipos = JsonUtility.FromJson<PreguntasObject>(EstereotipoJson);
        personaSpawner = FindObjectOfType<PersonaSpawner>();
        preguntasInUse = new List<PreguntaBase>();

        personaSpawner.BeginGame();
    }

    public PreguntaBase GetPregunta(Persona p) {
        currentPersona = p;
        PreguntaBase toReturn;
        

        if(currentPersona.isAdult) {
            StartCoroutine(CheckEstereotipo());
            toReturn = AllEstereotipos.Preguntas[randomIndex];

        } else {
            StartCoroutine(CheckPregunta());
            toReturn = AllPreguntas.Preguntas[randomIndex];
        }

        preguntasInUse.Add(toReturn);

        return toReturn;
    }

    public void ReleaseQuestion(PreguntaBase p) {
        if (preguntasInUse.Contains(p))
            preguntasInUse.Remove(p);
    }

    public void RemovePregunta(PreguntaBase p) {
        preguntasInUse.Remove(p);
        if(AllPreguntas.Preguntas.Contains(p)) {
            AllPreguntas.Preguntas.Remove(p);
        } else if(AllEstereotipos.Preguntas.Contains(p)) {
            AllEstereotipos.Preguntas.Remove(p);
        }

        if (AllPreguntas.Preguntas.Count == 0 && AllEstereotipos.Preguntas.Count == 0)
            personaSpawner.FinishSpawning();
    }

    IEnumerator CheckEstereotipo() {
        randomIndex = Random.Range(0, AllEstereotipos.Preguntas.Count);
        while (preguntasInUse.Contains(AllEstereotipos.Preguntas[randomIndex])) {
            randomIndex = Random.Range(0, AllEstereotipos.Preguntas.Count);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CheckPregunta() {
        randomIndex = Random.Range(0, AllPreguntas.Preguntas.Count);
        while (preguntasInUse.Contains(AllPreguntas.Preguntas[randomIndex])) {
            randomIndex = Random.Range(0, AllPreguntas.Preguntas.Count);
            yield return new WaitForEndOfFrame();
        }
    }


}
