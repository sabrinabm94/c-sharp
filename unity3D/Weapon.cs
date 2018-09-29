using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public bool weaponOn = false;
    public int requiredLevel;
    public bool canEquip;
    public string name;
    public float atack;
    public float atackM;

    public void Start() {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
    }
    public void Update() {
        setWeaponOn(true);
        if (player.GetComponent<Player>().getLevel() >= getRequiredLevel()) {
            setCanEquip(true);
        }
        else {
            setCanEquip(false);
        }
        if (getCanEquip() == true && getWeaponOn() == true) {
            setAtack(1);
            setAtackM(1);
        }
    }
    public void setWeaponOn(bool weaponOn) {
        this.weaponOn = weaponOn;
    }
    public bool getWeaponOn() {
        return weaponOn;
    }
    public void setRequiredLevel(int requiredLevel) {
        this.requiredLevel = requiredLevel;
    }
    public int getRequiredLevel() {
        return requiredLevel;
    }
    public void setCanEquip(bool canEquip) {
        this.canEquip = canEquip;
    }
    public bool getCanEquip() {
        return canEquip;
    }
    public void setName(string name) {
        this.name = name;
    }
    public string getName() {
        return name;
    }
    public void setAtack(int atack) {
        this.atack = atack;
    }
    public float getAtack() {
        return atack;
    }
    public void setAtackM(float atackM) {
        this.atackM = atackM;
    }
    public float getAtackM() {
        return atackM;
    }
}
