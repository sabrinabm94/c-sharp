using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public string name;
    public int level;
    public float exp;
    public float hp;
    public float hpFull;
    public float stamin;
    public float staminFull;
    private float hunger;
    private float hungerFull;
    private float foodSatisfaction;
    private float thirst;
    private float thirstFull;
    private float drinkSatisfaction;
    public float def;
    public float defM;
    public float atack;
    public float atackM;
    public float walkSpeed;
    public float runSpeed;
    public bool isDeath;

    public float armourDef;
    public float armourDefM;
    public float weaponAtack;
    public float weaponAtackM;

    public float classWalkSpeed;
    public float classRunSpeed;
    public float classSwimmingSpeed;
    public float classAtack;
    public float classAtackM;
    public float classDef;
    public float classDefM;
    public float classHp;
    public float classStamin;
    public float classRegHp;
    public float classRegStamin;

    public float buffReg;
    public float buffDef;
    public float buffDefM;
    public float buffAtack;
    public float buffAtackM;
    public float buffSpeed;

    public float playerHp;
    public float swimmingSpeed;

    void Start() {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        
        playerHp = player.GetComponent<Player>().getHp();

        enemy.GetComponent<ClassStatus>().setClass(5);
        enemy.GetComponent<MoveType>().setMoveType("stopped");
        player.GetComponent<DamageOnPlayer>().setEnemyInAtack(false);
        setLevel(1);
        getClassStatus();
        getEquipStatus();
        getBuffStatus();
        setStatus();
        statusFull();
    }
	
	void Update() {
        getEquipStatus();
        getBuffStatus();
        setStatus();
        atackPlayer();
        test();
	}

    public void setName(string name) {
        this.name = name;
    }
    public string getName() {
        return name;
    }
    public void setLevel(int level) {
        this.level = level;
    }
    public int getLevel() {
        return level;
    }
    public void setExp(float exp) {
        this.exp = exp;
    }
    public float getExp() {
        return exp;
    }
    public void setHp(float hp) {
        this.hp = hp;
    }
    public float getHp() {
        return hp;
    }
    public void setHpFull(float hpFull) {
        this.hpFull = hpFull;
    }
    public float getHpFull() {
        return hpFull;
    }
    public void setStamin(float stamin) {
        this.stamin = stamin;
    }
    public float getStamin() {
        return stamin;
    }
    public void setStaminFull(float staminFull) {
        this.staminFull = staminFull;
    }
    public float getStaminFull() {
        return staminFull;
    }
    public void setHunger(float hunger) {
        this.hunger = hunger;
    }
    public float getHunger() {
        return hunger;
    }
    public void setHungerFull(float hungerFull) {
        this.hungerFull = hungerFull;
    }
    public float getHungerFull() {
        return hungerFull;
    }
    public void setThirst(float thirst) {
        this.thirst = thirst;
    }
    public float getThirst() {
        return thirst;
    }
    public void setThirstFull(float thirstFull) {
        this.thirstFull = thirstFull;
    }
    public float getThirstFull() {
        return thirstFull;
    }
    public void setDef(float def) {
        this.def = def;
    }
    public float getDef() {
        return def;
    }
    public void setDefM(float defM) {
        this.defM = defM;
    }
    public float getDefM() {
        return defM;
    }
    public void setAtack(float atack) {
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
    public void setWalkSpeed(float walkSpeed) {
        this.walkSpeed = walkSpeed;
    }
    public float getWalkSpeed() {
        return walkSpeed;
    }
    public void setRunSpeed(float runSpeed) {
        this.runSpeed = runSpeed;
    }
    public float getRunSpeed() {
        return runSpeed;
    }
    public void setSwimmingSpeed(float swimmingSpeed) {
        this.swimmingSpeed = swimmingSpeed;
    }
    public float getSwimmingSpeed() {
        return swimmingSpeed;
    }
    public void atackPlayer() {
        if (player.GetComponent<Player>().hpController(playerHp) == false && isDeath == false) {
            player.GetComponent<DamageOnPlayer>().damageOnPlayerSystem("physical"); 
        } else if (player.GetComponent<Player>().hpController(playerHp) == true && isDeath == false) {
            player.GetComponent<Player>().die();
            player.GetComponent<ExpPlayer>().removeExp(10); 
            enemy.GetComponent<ExpEnemy>().addExp(10); 
        }
    }
    public void runToPlayer() {
        atackPlayer();
    }
    public void eat(int foodSatisfaction) { 
        if(hunger < hungerFull) {
            hunger = hunger + foodSatisfaction;
        }
    }
    public void drink(int drinkSatisfaction) { 
        if (thirst < thirstFull) {
            thirst = thirst + drinkSatisfaction;
        }
    }
    public bool hpController(float hp) {
        if(hp <= 0) {
            isDeath = true;
            die();
        } else {
            isDeath = false;
        }
        return isDeath;
    }
    public void die() {
        enemy.GetComponent<ExpEnemy>().removeExp(10);
        statusReseted();
        Debug.Log("Enemy: You are death! ");
        Application.Quit();
    }
    public void getClassStatus() {
        classWalkSpeed = enemy.GetComponent<ClassStatus>().getClassWalkSpeed();
        classRunSpeed = enemy.GetComponent<ClassStatus>().getClassRunSpeed();
        classSwimmingSpeed = enemy.GetComponent<ClassStatus>().getClassSwimmingSpeed();
        classAtack = enemy.GetComponent<ClassStatus>().getClassAtack();
        classAtackM = enemy.GetComponent<ClassStatus>().getClassAtackM();
        classDef = enemy.GetComponent<ClassStatus>().getClassDef();
        classDefM = enemy.GetComponent<ClassStatus>().getClassDefM();
        classHp = enemy.GetComponent<ClassStatus>().getClassHp();
        classStamin = enemy.GetComponent<ClassStatus>().getClassStamin();
        classRegHp = enemy.GetComponent<ClassStatus>().getClassRegHp();
        classRegStamin = enemy.GetComponent<ClassStatus>().getClassRegStamin();
    }
    public void getEquipStatus() {
        armourDef = enemy.GetComponent<Armour>().getDef();
        armourDefM = enemy.GetComponent<Armour>().getDefM();
        weaponAtack = enemy.GetComponent<Weapon>().getAtack();
        weaponAtackM = enemy.GetComponent<Weapon>().getAtackM();
    }
    public void getBuffStatus() {
        buffReg = enemy.GetComponent<Buffs>().getBuffReg();
        buffDef = enemy.GetComponent<Buffs>().getBuffDef();
        buffDefM = enemy.GetComponent<Buffs>().getBuffDefM();
        buffAtack = enemy.GetComponent<Buffs>().getBuffAtack();
        buffAtackM = enemy.GetComponent<Buffs>().getBuffAtackM();
        buffSpeed = enemy.GetComponent<Buffs>().getBuffSpeed();
    }
    public void setStatus() {
        hpFull = ((level * classHp) + classHp);
        setHpFull(hpFull);

        staminFull = ((level * classStamin) + classStamin);
        setStaminFull(staminFull);

        def = ((level * classDef) + classDef) + armourDef + buffDef;
        setDef(def);

        defM = ((level * classDefM) + classDefM) + armourDefM + buffDefM;
        setDefM(defM);

        atack = ((level * classAtack) + classAtack) + weaponAtack + buffAtack;
        setAtack(atack);

        atackM = ((level * classAtack) + classAtackM) + weaponAtackM + buffAtackM;
        setAtackM(atackM);

        walkSpeed = classWalkSpeed + buffSpeed;
        setWalkSpeed(walkSpeed);

        runSpeed = classRunSpeed + buffSpeed;
        setRunSpeed(runSpeed);

        swimmingSpeed = classRunSpeed + buffSpeed;
        setSwimmingSpeed(swimmingSpeed);
    }
    public void statusReseted() {
        setHp(0);
        setStamin(0);
        setRunSpeed(0);
        setThirst(0);
        setHunger(0);
        player.GetComponent<MoveType>().setMoveType("stopped");
    }
    public void statusFull() {
        setHp(hpFull);
        setStamin(staminFull);
        setThirst(thirstFull);
        setHunger(hungerFull);
    }
    public void test() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            enemy.GetComponent<ExpEnemy>().addExp(1000);
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            enemy.GetComponent<DamageOnPlayer>().directDamage(5);
        }
    }
}
