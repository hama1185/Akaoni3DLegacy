using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    static float time = 0.0f;
    static bool preparedFlag = false;
    static bool startFlag = false;
    public static Vector3 spawnPoint {set; get;}

    void Update() {
        if (startFlag) {
            time += Time.deltaTime;
            if (time >= 10.0f) {
                Debug.Log("Time Up");
            }
        }
    }

    public static void Initialize() {
        CreateSpawnPointMarker(spawnPoint);
    }

    public static void Prepared() {
        preparedFlag = true;
        // preparedFlag が true になった後に地形生成をする
        // 本来は地形生成後 startedFlag を true にする
        GameStart();
    }

    public static void GameStart() {
        startFlag = true;
        GameObject.FindWithTag("Enemy").transform.GetChild(0).gameObject.SetActive(true);
    }

    public static void CreateSpawnPointMarker(Vector3 spawnPoint) {
        GameObject obj = (GameObject)Resources.Load("Prefabs/SpawnPoint");

        Instantiate(obj, spawnPoint, Quaternion.identity);
    }
}