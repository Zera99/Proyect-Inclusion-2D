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
        PreguntaBase toReturn;
        int randomIndex;

        if(currentPersona.isAdult) {
            randomIndex = Random.Range(0, AllEstereotipos.Preguntas.Count);
            toReturn = AllEstereotipos.Preguntas[randomIndex];
        } else {
            randomIndex = Random.Range(0, AllPreguntas.Preguntas.Count);
            toReturn = AllPreguntas.Preguntas[randomIndex];
        }

        return toReturn;
    }

    public void RemovePregunta(PreguntaBase p) {
        if(AllPreguntas.Preguntas.Contains(p)) {
            AllPreguntas.Preguntas.Remove(p);
        } else if(AllEstereotipos.Preguntas.Contains(p)) {
            AllEstereotipos.Preguntas.Remove(p);
        }

        if (AllPreguntas.Preguntas.Count == 0 && AllEstereotipos.Preguntas.Count == 0)
            personaSpawner.FinishSpawning();
    }
}
