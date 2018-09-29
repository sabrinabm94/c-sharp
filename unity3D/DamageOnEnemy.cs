using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageOnEnemy : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    private float atackCounter;
    public float atackTime = 3.0f;

    public bool magicAtack;
    public bool physicalAtack;
    public float damage;

    public bool playerInAtack;
    public float playerAtackM;
	public float playerAtack;

    public float enemyDef;
    public float enemyDefM;
    public float enemyHp;


    void Start(){
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        setPlayerInAtack(false);
        playerAtack = player.GetComponent<Player>().getAtack();
        playerAtackM = player.GetComponent<Player>().getAtackM();

        enemyDef = enemy.GetComponent<Enemy>().getDef();
        enemyDefM = enemy.GetComponent<Enemy>().getDefM();
        enemyHp = enemy.GetComponent<Enemy>().getHp();
    }

	void Update() {

	}

    public void setPlayerInAtack(bool playerInAtack) {
        this.playerInAtack = playerInAtack;
    }
    public bool getPlayerInAtack() {
        return playerInAtack;
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

    public void OnTriggerEnter(Collider other) { 
        if (other.gameObject.tag == "Enemy") {
            damageOnEnemySystem("physical"); 
        } else {
            setPlayerInAtack(false);
        }
    }
    public void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            atackCounter += Time.deltaTime; 
            setAtackCounter(atackCounter);
            if (getAtackCounter() > getAtackTime()) {
                transform.Translate(Vector3.back);
                setAtackCounter(0.0f);
            }
        }
    }
    public void damageOnEnemySystem(string atackType) { 
        setPlayerInAtack(true);
        if (atackType == "physical") {
            magicAtack = false;
            physicalAtack = true;
            if (physicalAtack == true) {
                damage = playerAtack - enemyDef;
            } 
        }
        else if (atackType == "magic") {
            magicAtack = true;
            physicalAtack = false;
            if(magicAtack == true) {
                damage = playerAtackM - enemyDefM;
            }
        }
        setDamage(damage);
        enemyHp = enemyHp - getDamage();
        enemy.GetComponent<Enemy>().hpController(enemyHp); 
    }

    public void directDamage(float directDamageValue) { 
        setDamage(directDamageValue);
        enemyHp = enemyHp - getDamage();
        enemy.GetComponent<Enemy>().hpController(enemyHp);
    }
}
