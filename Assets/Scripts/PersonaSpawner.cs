using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaSpawner : MonoBehaviour {

    public GameObject PersonaPrefab;
    public List<Sprite> PersonaSprites;
    public List<Persona> spawnedPersonas;
    public float PersonaTimer;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    bool isSpawning;
    public bool isAnswering;
    int lastSpriteIndex;

    private void Start() {
        StartSpawning();
    }

    IEnumerator SpawnPersonCoroutine() {
        while (isSpawning) {
            if (!isAnswering) {
                Persona p = Instantiate(PersonaPrefab).GetComponent<Persona>();
                spawnedPersonas.Add(p);
                p.spawner = this;
                int newIndex = lastSpriteIndex;
                while (newIndex == lastSpriteIndex) {
                    newIndex = Random.Range(0, PersonaSprites.Count);
                }

                p.ChangeSprite(PersonaSprites[newIndex]);
                switch (Random.Range(0, 2)) { // 0 inclusive, 2 exclusive, 0-1 range
                    case 0: {
                        p.transform.position = new Vector3(minX, Random.Range(minY, maxY), 0);
                        break;

                    }
                    case 1: {
                        p.transform.position = new Vector3(maxX, Random.Range(minY, maxY), 0);
                        break;
                    }
                }

                if (Random.Range(0, 2) == 0) {
                    Debug.Log("Has issue");
                    p.hasIssue = true;
                }
                yield return new WaitForSeconds(PersonaTimer);
            }

            yield return new WaitForEndOfFrame();

        }

    }

    public void StartSpawning() {
        isSpawning = true;
        StartCoroutine(SpawnPersonCoroutine());
    }

    public void FinishSpawning() {
        isSpawning = false;
        StopAllCoroutines();
        // EndGame
    }

    public void StartAnswering() {
        isAnswering = true;
        foreach(Persona p in spawnedPersonas) {
            p.speed = 0;
        }
    }

    public void StopAnswering() {
        isAnswering = false;
        foreach (Persona p in spawnedPersonas) {
            p.speed = p.maxSpeed;
        }
    }

    public void RemovePersona(Persona p) {
        spawnedPersonas.Remove(p);
    }
}
