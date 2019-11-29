using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OperationKey : MonoBehaviour
{
    public static Vector3 mousePosition;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
        mousePosition = Input.mousePosition;
        Vector3 transPositon = this.transform.position;
        transPositon.x = ((mousePosition.x - 1280) + 0.01f) / 8;
        transPositon.y = ((mousePosition.y - 720) + 0.01f) / 8;
        this.transform.position = transPositon;
        

        if(Input.GetMouseButtonUp(0)){
            if((this.transform.position.x >= 13.7 && this.transform.position.x <= 20.4) && 
            (this.transform.position.y >= -4.5 && this.transform.position.y <= 3.7)){
                SceneManager.LoadScene("VillagerScene");
            }
            if((this.transform.position.x >= -19.6 && this.transform.position.x <= -12.9) && 
            (this.transform.position.y >= -4.5 && this.transform.position.y <= 3.7)){
                SceneManager.LoadScene("OgreScene");
            }        
        }
    }
}
