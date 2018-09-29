using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveType : MonoBehaviour {
    private CharacterController controller;
    private GameObject player;
    private GameObject enemy;

    public string moveType;
    private float lastPositionY;
    private float fallDistance;
    public float minFallForDamage = 5;
    private bool fall;
    private float damageFall;
    private float hp;
    private float hpFull;

    public float classWalkSpeed;
    public float classRunSpeed;
    public float classSwimmingSpeed;

    void Start() {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        enemy = GameObject.FindWithTag("Enemy");

        fall = false;
        hpFull = player.GetComponent<Player>().getHpFull();
    }

    void Update() {
        fallSystem();
    }

    public void setMoveType(string moveType) {
        if(moveType == "stopped") {
            player.GetComponent<ClassStatus>().setClassWalkSpeed(0);
            player.GetComponent<ClassStatus>().setClassRunSpeed(0);
        }
    	if(moveType == "walking") {
            classWalkSpeed = player.GetComponent<ClassStatus>().getClassWalkSpeed();
            player.GetComponent<ClassStatus>().setClassWalkSpeed(0);
        }
        if (moveType == "running") {
            classRunSpeed = player.GetComponent<ClassStatus>().getClassRunSpeed();
            player.GetComponent<ClassStatus>().setClassRunSpeed(0);
        }
        if (moveType == "swimming") {
            classSwimmingSpeed = player.GetComponent<ClassStatus>().getClassSwimmingSpeed();
            player.GetComponent<ClassStatus>().setClassSwimmingSpeed(classSwimmingSpeed);
        }
    	if(moveType == "flying") {
            //classFlyingSpeed = player.GetComponent<>().getClassFlyingSpeed();
            //player.GetComponent<>().setFlyingSpeed(0);
        }
        if (moveType == "falling") {
            player.GetComponent<ClassStatus>().setClassWalkSpeed(0);
            player.GetComponent<ClassStatus>().setClassRunSpeed(0);
        }
    }
    public string getMoveType() {
        return moveType;
    }
    public void fallSystem () {        
        if (lastPositionY > player.transform.position.y && controller.velocity.y < 0){
            fallDistance += lastPositionY - player.transform.position.y;
        }
        lastPositionY = player.transform.position.y;
        if (fallDistance >= minFallForDamage && controller.isGrounded){
            setMoveType("falling");    
            fallDistance = 0;
            lastPositionY = 0;
        }
        if (fallDistance < minFallForDamage && controller.isGrounded) {
            fall = false;
            fallDistance = 0;
            lastPositionY = 0;
        }
        if(getMoveType() == "falling") {
            damageFall = hpFull / 5;
            player.GetComponent<DamageOnPlayer>().directDamage(damageFall);
        }
    }

}
