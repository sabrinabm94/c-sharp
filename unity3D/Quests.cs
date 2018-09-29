using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Quests : MonoBehaviour {
    public string cultiveName;

    void Start() {    
    }

    void Update(){

    }

    public void setCultiveName(string cultiveName) {
        this.cultiveName = cultiveName;
    }
    public string GetCultiveName() {
        return cultiveName;
    }

    public void getCultive(int cultiveNivel) {
        if(cultiveNivel == 1) {
            setCultiveName("aprendiz");
        }

        if(cultiveNivel == 2) {
            setCultiveName("iniciante");
        }

        if(cultiveNivel == 3) {
            setCultiveName("Especialista");
        }

        if(cultiveNivel == 4) {
            setCultiveName("Mestre");
        }

        if(cultiveNivel == 5) {
            setCultiveName("Oráculo");
        }

         if(cultiveNivel == 6) {
            setCultiveName("Ancião");
        }
    }

}
