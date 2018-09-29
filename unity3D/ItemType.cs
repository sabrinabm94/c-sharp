using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemType : MonoBehaviour {
	public int itemType;
    public float goldDrop;
    public float goldNow;
    public string resourceDrop;
    public string lootDrop;
    public string[] inventary = new string[30];
    private int randomNumber;

    //ver como fazer onde colocar o item se o invertário estiver com o slot aleatorio cheio

    void Start(){
    	if(itemType == 1){
            randomNumberSystem();
            if(inventary[randomNumber] == ""){
                inventary[randomNumber] = lootDrop;
            }
    	}

    	if(itemType == 2){
            randomNumberSystem();
            if(inventary[randomNumber] == ""){
    		  inventary[randomNumber] = resourceDrop;
            }
    	}

    	if(itemType == 3){
    		goldNow += goldDrop; 
    	}
    }

    void Update(){

    }

    void randomNumberSystem() {       
        // Random randomNumber = new Random();
        // return randomNumber.Next(0, 29); 
    }
}
