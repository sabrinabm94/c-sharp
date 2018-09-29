using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExpEnemy : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public float expNew;
    public float expForUp;
    public float expLast;
    public int level;
    public float exp;

    void Start() {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        controller = GetComponent<CharacterController>();

        level = enemy.GetComponent<Enemy>().getLevel();
        setExpForUp((level * 1000) * 10);
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
        exp = enemy.GetComponent<Enemy>().getExp();
        exp += newExp;
        enemy.GetComponent<Enemy>().setExp(exp);
        setExpLast(getExpForUp() - enemy.GetComponent<Enemy>().getExp());
        
        if (enemy.GetComponent<Enemy>().getExp() >= getExpForUp()) {
            levelUp();
        }
    }
    public void removeExp(int newExp) {
        exp = enemy.GetComponent<Enemy>().getExp() - newExp;
        if (exp < 0) {
            exp = 0;
        }
        enemy.GetComponent<Enemy>().setExp(exp);
        Debug.Log("Enemy: lose " + newExp + " xp");
    }
    public void levelUp() {
        level += 1;
        enemy.GetComponent<Enemy>().setExp(0);
        setExpForUp(0);
        setExpLast(0);
        enemy.GetComponent<Enemy>().statusFull();
        Debug.Log("Enemy: Congrats, you level up!");
    }
}