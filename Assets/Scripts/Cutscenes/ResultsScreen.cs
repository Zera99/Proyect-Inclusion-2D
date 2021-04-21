using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour {
    public GameObject ResultadoBueno;
    public GameObject ResultadoMeh;
    public GameObject ResultadoMalo;
    public PlayerSO playerData;


    private void Awake() {
        if (playerData.TotalScore >= 14) {
            ResultadoBueno.SetActive (true);
        } else if (playerData.TotalScore >= 7) {
            ResultadoMeh.SetActive (true);
        } else {

            ResultadoMalo.SetActive (true);
        }
    }
}
