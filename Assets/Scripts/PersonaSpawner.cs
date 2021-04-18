﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PersonaSpawner : MonoBehaviour {

    public GameObject PersonaPrefab;
    public List<Sprite> AdultosSprites;
    public List<AnimationClip> AdultosAnim;
    public List<Sprite> NiñosSprites;
    public List<AnimationClip> NiñosAnim;
    public List<Persona> spawnedPersonas;
    public float PersonaTimer;
    public float minX;
    public float maxX;
    public List<float> yPositions;

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

                p.isAdult = Random.Range(0, 2) == 0; // 0 inclusive, 2 exclusive, 0-1 range

                if (p.isAdult) {
                    int newIndex = lastSpriteIndex;
                    while (newIndex == lastSpriteIndex) {
                        newIndex = Random.Range(0, AdultosSprites.Count);
                    }
                    p.ChangeSprite(AdultosSprites[newIndex], AdultosAnim[newIndex]);
                    lastSpriteIndex = newIndex;


                } else {
                    int newIndex = lastSpriteIndex;
                    while (newIndex == lastSpriteIndex) {
                        newIndex = Random.Range(0, NiñosSprites.Count);
                    }
                    p.ChangeSprite(NiñosSprites[newIndex], NiñosAnim[newIndex]);
                    lastSpriteIndex = newIndex;

                }

                switch (Random.Range(0, 2)) { // 0 inclusive, 2 exclusive, 0-1 range
                    case 0: {
                        p.transform.position = new Vector3(minX, yPositions[Random.Range(0, yPositions.Count)], 0);
                        break;

                    }
                    case 1: {
                        p.transform.position = new Vector3(maxX, yPositions[Random.Range(0, yPositions.Count)], 0);
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
        StartCoroutine(EndLevel());
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

    IEnumerator EndLevel() {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
