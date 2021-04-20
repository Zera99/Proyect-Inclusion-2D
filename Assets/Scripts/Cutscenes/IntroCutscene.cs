using RedBlueGames.Tools.TextTyper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class IntroCutscene : MonoBehaviour {

    public TMPro.TextMeshProUGUI text;
    public List<string> allTextos;
    public List<GameObject> allScenes;
    public GameObject tutorialImage;
    int index;
    int sceneIndex;
    bool isDone;

    public TextTyper typer;
    public float DelayBetweenLetters;

    private void Awake() {
    }



    // Start is called before the first frame update
    void Start() {
        index = 0;
        sceneIndex = 0;
        typer.TypeText(allTextos[index], DelayBetweenLetters);
        allScenes[sceneIndex].SetActive(true);
        isDone = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) ) {
            if(!isDone) {
                allScenes[sceneIndex].SetActive(false);
                sceneIndex++;
                index++;

                if (index == 5) {
                    tutorialImage.SetActive(true);
                    isDone = true;
                }

                if (sceneIndex < allScenes.Count)
                    allScenes[sceneIndex].SetActive(true);

                if (index < allTextos.Count) {
                    typer.TypeText(allTextos[index], DelayBetweenLetters);

                }
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
           

        }
    }

}



