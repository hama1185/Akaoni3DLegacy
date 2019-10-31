using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSpawn : MonoBehaviour
{
    public GameObject footObject;
    float time = 0;
    public static float beatRate{set;get;} = 0.35f;
    public static float enemyAngle{set;get;}
    void Start() {
        footObject = (GameObject)Resources.Load("Prefabs/RedFoot");    
    }
    // Update is called once per frame
    void Update(){
        this.time += Time.deltaTime;
        if(this.time > beatRate){
            this.time = 0;
            Vector3 position = transform.position;
            //敵のrotationも欲しいかも
            position.y = 0.1f;
            Instantiate(footObject, position, Quaternion.Euler(0, enemyAngle, 0));
        }
    }
}
