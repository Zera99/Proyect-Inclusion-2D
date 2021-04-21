using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadCredits() {
        SceneManager.LoadScene(5);
    }

    public void Exit() {
        Application.Quit();
    }
}
