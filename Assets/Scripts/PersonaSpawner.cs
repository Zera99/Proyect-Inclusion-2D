using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaSpawner : MonoBehaviour {

    public GameObject PersonaPrefab;
    public List<Sprite> PersonaSprites;
    public float PersonaTimer;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    bool isSpawning;
    bool isAnswering;
    int lastSpriteIndex;

    private void Start() {
        StartSpawning();
    }

    IEnumerator SpawnPersonCoroutine() {
        while (isSpawning) {
            
            Persona p = Instantiate(PersonaPrefab).GetComponent<Persona>();
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
                p.hasIssue = true;
            }

            yield return new WaitForSeconds(PersonaTimer);
        }

    }

    public void StartSpawning() {
        isSpawning = true;
        StartCoroutine(SpawnPersonCoroutine());
    }

    public void FinishSpawning() {
        isSpawning = false;
        StopAllCoroutines();
    }
}
