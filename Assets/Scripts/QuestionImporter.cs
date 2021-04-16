using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class QuestionImporter : MonoBehaviour {

    string PreguntasPath = "Assets/Resources/Preguntas.json";
    string EstereotiposPath = "Assets/Resources/Estereotipos.json";
    string PreguntaJson;
    string EstereotipoJson;
    PreguntasObject AllPreguntas;
    PreguntasObject AllEstereotipos;
    public PersonaSpawner personaSpawner;
    Persona currentPersona;

    private void Awake() {
        StreamReader preguntasReader = new StreamReader(PreguntasPath);
        StreamReader estereotipoReader = new StreamReader(EstereotiposPath);
        PreguntaJson = preguntasReader.ReadToEnd();
        EstereotipoJson = estereotipoReader.ReadToEnd();
        AllPreguntas = JsonUtility.FromJson<PreguntasObject>(PreguntaJson);
        AllEstereotipos = JsonUtility.FromJson<PreguntasObject>(EstereotipoJson);
        personaSpawner = FindObjectOfType<PersonaSpawner>();
    }

    public PreguntaBase GetPregunta(Persona p) {
        currentPersona = p;
        int randomIndex = Random.Range(0, AllPreguntas.Preguntas.Count);
        PreguntaBase toReturn = AllPreguntas.Preguntas[randomIndex];
        AllPreguntas.Preguntas.RemoveAt(randomIndex);
        if (AllPreguntas.Preguntas.Count == 0 && AllEstereotipos.Preguntas.Count == 0)
            personaSpawner.FinishSpawning();

        return toReturn;

    }

    public void PreguntaFinished() {
        currentPersona.FinishQuestion();
    }

}
