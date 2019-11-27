using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour{
    public Text resultText;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Game Finish\n");
            if(other.gameObject.name == "Ogre"){
                resultText.text = "You Win!!!";
            }
            else{
                resultText.text = "You Lose...";
            }
        }
    }
}