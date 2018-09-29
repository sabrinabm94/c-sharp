using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Armour : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public bool armourOn = false;
	public int requiredLevel;
	public bool canEquip;
	public string name; 
	public float def;
	public float defm;

    public void Start() { //a intormação dessas variáveis deve vir do painel do objeto com esse script, setado lá
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        setName(name);
    	setRequiredLevel(requiredLevel);
        setDef(def);
        setDefm(defm);
    }
    public void Update() {
    	setArmourOn(true); //a intormação dessas variáveis deve vir do painel do objeto com esse script, setado lá
    	if(player.GetComponent<Player>().getLevel() >= getRequiredLevel()) {
    		setCanEquip(true);
    	} else {
    		setCanEquip(false);
    	}
    	if(getCanEquip() == true && getArmourOn() == true) {
        	player.GetComponent<Player>().setDef(getDef());
        	player.GetComponent<Player>().setDefM(getDefM());
    	}
    }
    public void setArmourOn(bool armourOn) {
		this.armourOn = armourOn;
	}
	public bool getArmourOn() {
		return armourOn;
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
	public void setDef(float def) {
		this.def = def;
	}
	public float getDef() {
		return def;
	}
	public void setDefm(float defm) {
		this.defm = defm;
	}
	public float getDefM() {
		return defm;
	}
}
