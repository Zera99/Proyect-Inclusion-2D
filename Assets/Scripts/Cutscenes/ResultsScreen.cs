using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour {
    public Image ResultadoBueno;
    public Image ResultadoMeh;
    public Image ResultadoMalo;
    public PlayerSO playerData;


    private void Awake() {
        if (playerData.TotalScore == 20) {
            ResultadoBueno.enabled = true;
        } else if (playerData.TotalScore >= 8) {
            ResultadoMeh.enabled = true;
        } else {

            ResultadoMalo.enabled = true;
        }
    }
}
