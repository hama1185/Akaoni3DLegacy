using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    static float time = 0.0f;
    static bool preparedFlag = false;
    static bool startFlag = false;

    void Update() {
        if (startFlag) {
            time += Time.deltaTime;
            if (time >= 100.0f) {
                Debug.Log("Time Up");
            }
        }
    }

    public static void Prepared() {
        preparedFlag = true;
    }

    public static void GameStart() {
        startFlag = true;
        GameObject.FindWithTag("Enemy").transform.GetChild(0).gameObject.SetActive(true);
    }
}