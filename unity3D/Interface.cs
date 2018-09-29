using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interfaceAtt : MonoBehaviour {
    public CharacterController controller;
    public GameObject player;
    public GameObject enemy;

    public int level;
    public float hp;
    public float hpFull;
    public float stamin;
    public float staminFull;
    public float exp;
    public float expLast;
    public string className;

    public Image menuHp;
    public Image menuStamin;
    public Text textLevel;
    public Text textHp;

    public Text textStamin;
    public Text textClassName;
    public Text textExp;
    public Text textExpLast;

    public float enemyLevel;
    public float enemyHp;
    public float enemyHpFull;

    public Image menuEnemyHp;
    public Image menuEnemyStamin;
    public Text enemyTextLevel;
	public Text enemyTextHp;

	void Start(){
		player = GameObject.FindWithTag("Player");
		enemy = GameObject.FindWithTag("Enemy");
        controller = GetComponent<CharacterController>();

        level = player.GetComponent<Player>().getLevel();
        hp = player.GetComponent<Player>().getHp();
        hpFull = player.GetComponent<Player>().getHpFull();
        stamin = player.GetComponent<Player>().getStamin();
        staminFull = player.GetComponent<Player>().getStaminFull();
        exp = player.GetComponent<Player>().getExp();
        expLast = player.GetComponent<ExpPlayer>().getExpLast();
        className = player.GetComponent<ClassStatus>().getClassName(); 

        enemyLevel = enemy.GetComponent<Enemy>().getLevel();
        enemyHp = enemy.GetComponent<Enemy>().getHp();
        enemyHpFull = enemy.GetComponent<Enemy>().getHpFull();
    }

	void Update(){
        gameInterface();
    }

	void gameInterface() {
		textLevel.text = level.ToString();
		textExp.text = exp.ToString();
		textExpLast.text = expLast.ToString();
		textHp.text = hp.ToString();
		textStamin.text = stamin.ToString();
		textClassName.text = className;
		enemyTextLevel.text = enemyLevel.ToString();
		enemyTextHp.text = enemyHp.ToString();
	    menuHp.fillAmount = ((1 / hpFull) * hp);
	    menuStamin.fillAmount = ((1 / stamin) * stamin);
	    menuEnemyHp.fillAmount = ((1 / enemyHpFull) * hp);
	}
}