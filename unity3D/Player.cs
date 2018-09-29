using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public string name;
    private int classId;
    private int level;
    private float exp;
    private float hp;
    private float hpFull;
    private float stamin;
    private float staminFull;
    private float hunger;
    private float hungerFull;
    private float foodSatisfaction;
    private float thirst;
    private float thirstFull;
    private float drinkSatisfaction;
    private float def;
    private float defM;
    private float atack;
    private float atackM;
    public float walkSpeed;
    public float runSpeed;
    private float swimmingSpeed;
    private bool isDeath;

    private float armourDef;
    private float armourDefM;
    private float weaponAtack;
    private float weaponAtackM;

    private float classWalkSpeed;
    private float classRunSpeed;
    private float classSwimmingSpeed;
    private float classAtack;
    private float classAtackM;
    private float classDef;
    private float classDefM;
    private float classHp;
    private float classStamin;
    private float classRegHp;
    private float classRegStamin;

    private float buffReg;
    private float buffDef;
    private float buffDefM;
    private float buffAtack;
    private float buffAtackM;
    private float buffSpeed;

    private float playerHp;
    private float enemyHp;

    void Start() {
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");
        controller = GetComponent<CharacterController>();

        enemyHp = enemy.GetComponent<Enemy>().getHp();

        player.GetComponent<ClassStatus>().setClass(6);
        player.GetComponent<MoveType>().setMoveType("stopped");
        enemy.GetComponent<DamageOnEnemy>().setPlayerInAtack(false);
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
        atackEnemy();
        test();
    }

    public void setName(string name) {
        this.name = name;
    }
    public string getName() {
        return name;
    }
    public void setClassId(int classId) {
        this.classId = classId;
    }
    public int getClassId() {
        return classId;
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
    public void atackEnemy() {
        if (enemy.GetComponent<Enemy>().hpController(enemyHp) == false && isDeath == false) {
            enemy.GetComponent<DamageOnEnemy>().damageOnEnemySystem("physical"); //esse valor derá vir de forma dinâmica de acordo com a id de classe do inimigo 
        }
        else if (enemy.GetComponent<Enemy>().hpController(enemyHp) == true && isDeath == false) {
            enemy.GetComponent<Enemy>().die();
            enemy.GetComponent<ExpEnemy>().removeExp(10); //esse valor deverávir de forma dinâmica do level do inimigo que matou
            player.GetComponent<ExpPlayer>().addExp(10); //esse valor deverávir de forma dinâmica da missão escolhida ou level do inimigo morto
        }
    }
    public void runToEnemy() {
        //implementar função para o inimigo perseguir o personagem.
        atackEnemy();
    }
    public void eat(int foodSatisfaction) { //este parâmetro deve fim do script do objeto do tipo da comida
        if (hunger < hungerFull)
        { //só pode se alimentar se a fome não estiver totalmente cheia
            hunger = hunger + foodSatisfaction;
        }
        //implementar função de restaração de hp ao comer e perseguir alimentos ao estar fora do modo de atack
    }
    public void drink(int drinkSatisfaction) { //este parâmetro deve fim do script do objeto do tipo da bebida
        if (thirst < thirstFull)
        { //só pode beber se a sede não estiver totalmente cheia
            thirst = thirst + drinkSatisfaction;
        }
        //implementar função de restaração de hp ao beber e perseguir água ao estar fora do modo de atack
    }
    public bool hpController(float hp) {
        if (hp <= 0) {
            isDeath = true;
            die();
        }
        else {
            isDeath = false;
        }
        return isDeath;
    }
    public void die() {
        enemy.GetComponent<ExpEnemy>().removeExp(10); //vir do painel ou de um arquivo de config
        statusReseted();
        Debug.Log("Player: You are death! ");
        Application.Quit();
    }
    public void getClassStatus() { //pegando as informações da classe
        classWalkSpeed = player.GetComponent<ClassStatus>().getClassWalkSpeed();
        classRunSpeed = player.GetComponent<ClassStatus>().getClassRunSpeed();
        classSwimmingSpeed = player.GetComponent<ClassStatus>().getClassSwimmingSpeed();
        classAtack = player.GetComponent<ClassStatus>().getClassAtack();
        classAtackM = player.GetComponent<ClassStatus>().getClassAtackM();
        classDef = player.GetComponent<ClassStatus>().getClassDef();
        classDefM = player.GetComponent<ClassStatus>().getClassDefM();
        classHp = player.GetComponent<ClassStatus>().getClassHp();
        classStamin = player.GetComponent<ClassStatus>().getClassStamin();
        classRegHp = player.GetComponent<ClassStatus>().getClassRegHp();
        classRegStamin = player.GetComponent<ClassStatus>().getClassRegStamin();
    }
    public void getEquipStatus() { //pegando as informações de armas e armaduras
        armourDef = player.GetComponent<Armour>().getDef();
        armourDefM = player.GetComponent<Armour>().getDefM();
        weaponAtack = player.GetComponent<Weapon>().getAtack();
        weaponAtackM = player.GetComponent<Weapon>().getAtackM();
    }
    public void getBuffStatus() { //pegando informações dos buffs 
        buffReg = player.GetComponent<Buffs>().getBuffReg();
        buffDef = player.GetComponent<Buffs>().getBuffDef();
        buffDefM = player.GetComponent<Buffs>().getBuffDefM();
        buffAtack = player.GetComponent<Buffs>().getBuffAtack();
        buffAtackM = player.GetComponent<Buffs>().getBuffAtackM();
        buffSpeed = player.GetComponent<Buffs>().getBuffSpeed();
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
    public void test() { //exclusivo para personagem e para testes dentro do unity somente, será removido depois
        if (Input.GetKeyDown(KeyCode.Q)) {
            player.GetComponent<ExpPlayer>().addExp(1000);
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            player.GetComponent<DamageOnPlayer>().directDamage(5);
        }
    }
}