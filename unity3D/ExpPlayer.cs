using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExpPlayer : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    private float expNew;
    private float expForUp;
    private float expLast;
    private int level;
    public float exp;

    void Start() {
        //mapeando os objetos pela tag
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        //pegando valores de variáveis de outros scripts
        exp = player.GetComponent<Player>().getExp();
    }

    void Update() {

    }

    public void setExpForUp(float expForUp) {
        this.expForUp = expForUp;
    }
    public float getExpForUp() {
        return expForUp;
    }
    public void setExpLast(float expLast) {
        this.expLast = expLast;
    }
    public float getExpLast() {
        return expLast;
    }

    public void addExp(int newExp) {
        exp = exp + newExp; //acrécimo de exp
        setExpForUp((level * 1000) * 10); //formula simples para sempre acrescentar a exp necessária para o próximo level
        setExpLast(getExpForUp() - exp); //diminuição de exp necessária para o próximo level
        player.GetComponent<Player>().setExp(exp);
        if (exp >= getExpForUp()) {
            levelUp();
        }
    }
    public void removeExp(int newExp) { //chamado ao morrer
        exp = exp - newExp;
        if (exp < 0) {
            exp = 0; //impedindo valores menores que 0
        }
        player.GetComponent<Player>().setExp(exp);
        Debug.Log("You lose " + newExp + " xp");
    }
    public void levelUp() { //chamada após matar inimigos ou fazer missões
        level = player.GetComponent<Player>().getLevel(); //pegando valor atualizado do level
        level += 1; //acrescimo do level e zerando variáveis de controle de exp
        player.GetComponent<Player>().setLevel(level); //setando novo level no personagem
        exp = 0;
        player.GetComponent<Player>().setExp(exp);
        setExpForUp(0);
        setExpLast(0);
        player.GetComponent<Player>().statusFull(); //resetando os status atuais para cheio após do up
        Debug.Log("congrats, you level up!");
    }
}