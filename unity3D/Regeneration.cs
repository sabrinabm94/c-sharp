using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Regeneration : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
	private GameObject enemy;

    private float regeneration;
    private float regenerationHp;
    private float regenerationStamin;

    private float buffRegeneration;
    private float classRegHp;
    private float classRegStamin;

    private int playerLevel;
    private bool playerInAtack;
    private float playerHp;
    private float playerHpFull;
    private float playerStamin;
    private float playerStaminFull;

    private int enemyLevel;
    private bool enemyInAtack;
    private float enemyHp;
    private float enemyHpFull;
    private float enemyStamin;
    private float enemyStaminFull;

    void Start(){
        player = GameObject.FindWithTag("Player");
		enemy = GameObject.FindWithTag("Enemy");
        controller = GetComponent<CharacterController>();

        playerInAtack = enemy.GetComponent<DamageOnEnemy>().getPlayerInAtack();
        playerLevel = player.GetComponent<Player>().getLevel();
        playerHp = player.GetComponent<Player>().getHp();
        playerHpFull = player.GetComponent<Player>().getHpFull();
        playerStamin = player.GetComponent<Player>().getStamin();
        playerStaminFull = player.GetComponent<Player>().getStaminFull();

        enemyInAtack = player.GetComponent<DamageOnPlayer>().getEnemyInAtack();
        enemyHp = enemy.GetComponent<Enemy>().getHp();
        enemyHpFull = enemy.GetComponent<Enemy>().getHpFull();
        enemyStamin = enemy.GetComponent<Enemy>().getStamin();
        enemyStaminFull = enemy.GetComponent<Enemy>().getStaminFull();

        buffRegeneration = player.GetComponent<Buffs>().getBuffReg();
        classRegHp = player.GetComponent<ClassStatus>().getClassRegHp();
        classRegStamin = player.GetComponent<ClassStatus>().getClassRegStamin();
    }

    void Update(){
        regenerationPlayer();
        regenerationEnemy();
    }
	
	public void regenerationPlayer() { //tem buff de regeneração
		if(player.GetComponent<Player>().hpController(playerHp) == false) {
			if (playerInAtack == false) {
				regeneration = 2f + (playerLevel * 2) / player.GetComponent<Player>().getLevel();
            } else {
                regeneration = 1f + (playerLevel * 2) / player.GetComponent<Player>().getLevel();
            }
			regenerationStamin = (((regeneration + buffRegeneration) / 100) + ((playerLevel * classRegStamin) / 10));
			regenerationHp = (((regeneration + buffRegeneration) / 100) + ((playerLevel * classRegHp) / 10));

			if(playerHp < playerHpFull) {
				playerHp += regenerationHp * Time.deltaTime;
			}
			if(playerStamin < playerStaminFull) {
                playerStamin += regenerationStamin * Time.deltaTime;
			}
		}
	}
    public void regenerationEnemy() { //não tem buff de regeneração
        if (enemy.GetComponent<Enemy>().hpController(enemyHp) == false) {
            if (enemyInAtack == false) {
                regeneration = 2f + (enemy.GetComponent<Enemy>().getLevel() * 2) / enemy.GetComponent<Enemy>().getLevel();
            } else {
                regeneration = 1f + (enemy.GetComponent<Enemy>().getLevel() * 2) / enemy.GetComponent<Enemy>().getLevel();
            }
            regenerationStamin = (((regeneration) / 100) + ((enemy.GetComponent<Enemy>().getLevel() * classRegStamin) / 10));
            regenerationHp = (((regeneration) / 100) + ((enemy.GetComponent<Enemy>().getLevel() * classRegHp) / 10));

            if (enemyHp < enemyHpFull) {
                enemyHp += regenerationHp * Time.deltaTime;
            }
            if (enemyStamin < enemyStaminFull) {
                enemyStamin += regenerationStamin * Time.deltaTime;
            }
        }
    }
}