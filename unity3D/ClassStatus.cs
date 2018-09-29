using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClassStatus : MonoBehaviour {
	private CharacterController controller;
    private GameObject player;
	private GameObject enemy;

	public string className;
    public string classAtackType;
    public int classId;
    private float classWalkSpeed;
    private float classRunSpeed;
    private float classSwimmingSpeed;
    private float classHp;
    private float classStamin;
    private float classDef;
    private float classDefM;
    private float classAtack;
    private float classAtackM;
    private float classRegHp;
    private float classRegStamin;

    void Start() {
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
		enemy = GameObject.FindWithTag("Enemy");
    }

    void Update() {

    }

    public int getClassId() {
        return classId;
    }
    public void setClassId(int classId) {
        this.classId = classId;
    }
    public string getClassName() {
        return className;
    }
    public void setClassName(string className) {
        this.className = className;
    }
    public float getClassWalkSpeed() {
        return classWalkSpeed;
    }
    public void setClassWalkSpeed(float classWalkSpeed) {
        this.classWalkSpeed = classWalkSpeed;
    }
    public float getClassRunSpeed() {
        return classRunSpeed;
    }
    public void setClassRunSpeed(float classRunSpeed) {
        this.classRunSpeed = classRunSpeed;
    }
    public float getClassSwimmingSpeed() {
        return classSwimmingSpeed;
    }
    public void setClassSwimmingSpeed(float classSwimmingSpeed) {
        this.classSwimmingSpeed = classSwimmingSpeed;
    }
    public string getClassAtackType() {
        return classAtackType;
    }
    public void setClassAtackType(string classAtackType) {
        this.classAtackType = classAtackType;
    }
    public float getClassAtack() {
        return classAtack;
    }
    public void setClassAtack(float classAtack) {
        this.classAtack = classAtack;
    }
    public float getClassAtackM() {
        return classAtackM;
    }
    public void setClassAtackM(float classAtackM) {
        this.classAtackM = classAtackM;
    }
    public float getClassDef() {
        return classDef;
    }
    public void setClassDef(float classDef) {
        this.classDef = classDef;
    }
    public float getClassDefM() {
        return classDefM;
    }
    public void setClassDefM(float classDefM) {
        this.classDefM = classDefM;
    }
    public float getClassHp() {
        return classHp;
    }
    public void setClassHp(float classHp) {
        this.classHp = classHp;
    }
    public float getClassRegHp() {
        return classRegHp;
    }
    public void setClassRegHp(float classRegHp) {
        this.classRegHp = classRegHp;
    }
    public float getClassStamin() {
        return classStamin;
    }
    public void setClassStamin(float classStamin) {
        this.classStamin = classStamin;
    }
    public float getClassRegStamin() {
        return classRegStamin;
    }
    public void setClassRegStamin(float classRegStamin) {
        this.classRegStamin = classRegStamin;
    }
    public void setClass(int classId) {
    	if(classId == 1) {
			mage();
		}
		if(classId == 2) {
			priest();
		}
		if(classId == 3) {
			buffer();
		}
		if(classId == 4) {
			venomancer();
		}
		if(classId == 5) {
			warrior();
		}
        if (classId == 6) {
			beast();
		}
    }
    public void mage() {
        setClassName("Mage");
        setClassAtackType("magic");
        setClassId(1);
        setClassWalkSpeed(3);
		setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
		setClassStamin(300);
        setClassRegStamin(3);
	}
    public void priest() {
        setClassName("Priest");
        setClassAtackType("magic");
        setClassId(2);
        setClassWalkSpeed(3);
        setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
        setClassStamin(300);
        setClassRegStamin(3);
    }
    public void buffer(){
        setClassName("buffer");
        setClassAtackType("magic");
        setClassId(3);
        setClassWalkSpeed(3);
        setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
        setClassStamin(300);
        setClassRegStamin(3);
    }
    public void venomancer() {
        setClassName("Venomancer");
        setClassAtackType("magic");
        setClassId(4);
        setClassWalkSpeed(3);
        setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
        setClassStamin(300);
        setClassRegStamin(3);
    }
    public void warrior() {
        setClassName("warrior");
        setClassAtackType("physical");
        setClassId(5);
        setClassWalkSpeed(3);
        setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
        setClassStamin(300);
        setClassRegStamin(3);
    }
	public void beast() {
        setClassName("beast");
        setClassAtackType("physical");
        setClassId(6);
        setClassWalkSpeed(3);
        setClassRunSpeed(6);
        setClassSwimmingSpeed(2);
        setClassAtack(3);
        setClassAtackM(7);
        setClassDef(3);
        setClassDefM(7);
        setClassHp(100);
        setClassRegHp(1);
        setClassStamin(300);
        setClassRegStamin(3);
    }

}
