using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buffs : MonoBehaviour {
    public float buffCountReg;
    public float buffCountSpeed;
    public float buffCountDef;
    public float buffCountDefM;
    public float buffCountAtack;
    public float buffCountAtackM;

    public string buffType;
    public float buffReg;
    public float buffSpeed;
    public float buffDef;
    public float buffDefM;
    public float buffAtack;
    public float buffAtackM;

    void Start() {
        buffCountReg = 360.0f;
        buffCountSpeed = 360.0f;
        buffCountDef = 360.0f;
        buffCountDefM = 360.0f;
        buffCountAtack = 360.0f;
        buffCountAtackM = 360.0f;

        buffReg = 0;
        buffSpeed = 0;
        buffDef = 0;
        buffDefM = 0;
        buffAtack = 0;
        buffAtackM = 0;
    }

    void Update() {
    
    }

    public void setBuffType(string buffType) {
        this.buffType = buffType;
    }
    public string getBuffType() {
        return buffType;
    }
    public void setBuffReg(float buffReg) {
        this.buffReg = buffReg;
    }
    public float getBuffReg() {
        return buffReg;
    }
    public void setBuffSpeed(float buffSpeed) {
        this.buffSpeed = buffSpeed;
    }
    public float getBuffSpeed() {
        return buffSpeed;
    }
    public void setBuffDef(float buffDef) {
        this.buffDef = buffDef;
    }
    public float getBuffDef() {
        return buffDef;
    }
    public void setBuffDefM(float buffDefM) {
        this.buffDefM = buffDefM;
    }
    public float getBuffDefM() {
        return buffDefM;
    }
    public void setBuffAtack(float buffAtack) {
        this.buffAtack = buffAtack;
    }
    public float getBuffAtack() {
        return buffAtack;
    }
    public void setBuffAtackM(float buffAtackM) {
        this.buffAtackM = buffAtackM;
    }
    public float getBuffAtackM() {
        return buffAtackM;
    }

    public void buffSystem(string buffType) {          
        if(getBuffType() == "regeneration") {
            setBuffReg(3); //valor que será acrecentado nos calculos do status do personagem
            buffCountReg -= Time.deltaTime; //pega o tempo total do buff e vai descencendo com o passar do tempo
            buffCounterSystem(buffCountReg, getBuffReg(), buffType); //chama a função para verificar se o tempo do buff já acabou
        } else if(getBuffType() == "speed") {
            setBuffSpeed(3);
            buffCountSpeed -= Time.deltaTime;
            buffCounterSystem(buffCountSpeed, getBuffSpeed(), buffType);
        } else if(getBuffType() == "def") {
            setBuffDef(3);
            buffCountDef -= Time.deltaTime;
            buffCounterSystem(buffCountDef, getBuffDef(), buffType);
        } else if (getBuffType() == "defm") {
            setBuffDefM(3);
            buffCountDefM -= Time.deltaTime;
            buffCounterSystem(buffCountDefM, getBuffDefM(), buffType);
        } else if (getBuffType() == "atack") {
            setBuffAtack(3);
            buffCountAtack -= Time.deltaTime;
            buffCounterSystem(buffCountAtack, getBuffAtack(), buffType);
        } else if (getBuffType() == "atackm") {
            setBuffAtackM(3);
            buffCountAtackM -= Time.deltaTime;
            buffCounterSystem(buffCountAtackM, getBuffAtackM(), buffType);
        }
        UnityEngine.Debug.Log("You have the buff " + buffType + " actived.");
    }

    public void buffCounterSystem(float buffCounter, float buffToZero, string buffType) {
        if (buffCounter <= 0) { //se o tempo do buff acabou
            buffToZero = 0; //zera o valor do buff para não ser considerado no status do personagem
            buffCounter = 360.0f; //reseta o valor inicial do buff
            UnityEngine.Debug.Log("Your buff " + buffType + " is ended.");
        }
    }
}
