using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    static float MAX_SPEED = 10.0f;
    public static Vector3 spawnPoint{set; get;}

    public static float GetMAX_SPEED() {
        return MAX_SPEED;
    }
}