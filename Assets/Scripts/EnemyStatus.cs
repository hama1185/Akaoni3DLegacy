using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {
    Transform player;
    static float MAX_SPEED = 10.0f;

    // 緊張度パラメータ(仮)
    public static float tension {set; get;} = 0.2f;
    // public static float distaneWithPlayer {set; get;}

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    // void Update() {
    // //     distaneWithPlayer = Mathf.Pow(Mathf.Pow(Mathf.Abs(this.transform.position.x - player.position.x), 2) + Mathf.Pow(Mathf.Abs(this.transform.position.z - player.position.z), 2), 0.5f);
    // // }

    public static float GetMAX_SPEED() {
        return MAX_SPEED;
    }
}