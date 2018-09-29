using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageOnPlayer : MonoBehaviour { //todas as classes no unity devem ser do tipo MonoBehaviour
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    private float atackCounter;
    public float atackTime = 3.0f; //todo numero foat tem que ter o f no valor no c#;

    public bool magicAtack;
    public bool physicalAtack;
    public float damage;

    public bool enemyInAtack;
    public float enemyAtackM;
    public float enemyAtack;

    public float playerDef;
    public float playerDefM;
    public float playerHp;


    void Start() {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
       
        setEnemyInAtack(false);
        //pegando valores das variáveis do script player
        playerDef = player.GetComponent<Player>().getDef(); 
        playerDefM = player.GetComponent<Player>().getDefM();
        playerHp = player.GetComponent<Player>().getHp();

        //mesmo para o enemy
        enemyAtack = enemy.GetComponent<Enemy>().getAtack();
        enemyAtackM = enemy.GetComponent<Enemy>().getAtackM();
    }

    void Update() {

    }

    public void setEnemyInAtack(bool enemyInAtack) {
        this.enemyInAtack = enemyInAtack;
    }
    public bool getEnemyInAtack() {
        return enemyInAtack;
    }
    public void setAtackCounter(float atackCounter) {
        this.atackCounter = atackCounter;
    }
    public float getAtackCounter() {
        return atackCounter;
    }
    public void setAtackTime(float atackTime) {
        this.atackTime = atackTime;
    }
    public float getAtackTime() {
        return atackTime;
    }
    public void setDamage(float damage) {
        this.damage = damage;
    }
    public float getDamage() {
        return damage;
    }

    public void OnTriggerEnter(Collider other) { //se o enimigo entrar na área do box collider do personagem acionará a função de dano no personagem
        if (other.gameObject.tag == "Enemy") {
            damageOnPlayerSystem("physical"); //passando o tipo de dano como físico, pensar em como fazer o dano mágico (não precisa estar tão perto para dar dano)
        } else {
            setEnemyInAtack(false);
        }
    }
    public void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            atackCounter += Time.deltaTime; //enquanto o inimigo estiver dentro da área de box collider do personagem girará um contador de arack x tempo
            setAtackCounter(atackCounter); //descrecendo contador do buff
            if (getAtackCounter() > getAtackTime()) {
                transform.Translate(Vector3.back);
                setAtackCounter(0.0f); //tempo do buff acabou
            }
        }
    }
    public void damageOnPlayerSystem(string atackType) { //chamada a função de dano no personagem passado o tipo
        setEnemyInAtack(true);
        if (atackType == "physical") {
            magicAtack = false;
            physicalAtack = true;
            if (physicalAtack == true) {
                damage = enemyAtack - playerDef; //considerado as info de cada tipo de atack para formar o dano
            }
                
        } else if (atackType == "magic") {
            magicAtack = true;
            physicalAtack = false;
            if (magicAtack == true) {
                damage = enemyAtackM - playerDefM;
            }
        }
        setDamage(damage);
        playerHp = playerHp - getDamage(); //diminuindo do hp do personagem
        player.GetComponent<Player>().hpController(playerHp); //retorando o novo valor do hp para a função hpController da classe personagem
    }

    public void directDamage(float directDamageValue) { //usado para o dano de queda e para os testes de dano
        setDamage(directDamageValue);
        playerHp = playerHp - getDamage();
        player.GetComponent<Player>().hpController(playerHp);
    }
}
