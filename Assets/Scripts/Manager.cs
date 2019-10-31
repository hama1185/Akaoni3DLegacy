using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    static float time = 0.0f;
    static public bool pointedFlag = false;
    static public bool preparedFlag = false;
    static public bool startFlag = false;
    static public bool endFlag = false;
    public static Vector3 spawnPoint {set; get;} = Vector3.zero;

    void Update() {
        if (spawnPoint != Vector3.zero && !pointedFlag) {
            CreateSpawnPointMarker(spawnPoint);
            pointedFlag = true;
        }
        if (startFlag) {
            time += Time.deltaTime;
            if (time >= 100.0f && !endFlag) {
                Debug.Log("Time Up");
                endFlag = true;
            }
        }
    }

    public static void Prepared() {
        preparedFlag = true;

        if(GameObject.FindWithTag("Player").name == "Ogre") {
            Master.flagCount++;
        }
        else {
            Client.ReturnPflag();
        }
        // preparedFlag が true になった後に地形生成をする
        // 本来は地形生成後 startedFlag を true にする
    }

    public static void GameStart() {
        startFlag = true;
        GameObject.FindWithTag("Enemy").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Walls").transform.GetChild(0).gameObject.SetActive(true);
        if(GameObject.FindWithTag("Player").name == "Ogre"){
            GameObject.FindWithTag("Enemy").GetComponent<FootSpawn>().enabled = true;
            GameObject.FindWithTag("Player").transform.GetChild(0).gameObject.GetComponent<PostEffect>().enabled = true;
        }
    }

    public static void CreateSpawnPointMarker(Vector3 spawnPoint) {
        GameObject obj = (GameObject)Resources.Load("Prefabs/SpawnPoint");

        Instantiate(obj, spawnPoint, Quaternion.identity);
    }
}