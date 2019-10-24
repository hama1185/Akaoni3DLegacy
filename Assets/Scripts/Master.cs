using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
    Vector3[] spawnPoints = new Vector3[8];
    Vector3[] goalPoints = new Vector3[4];

    void Start() {
        InitializePoints();
        CalculateSpawnPoints();
    }

    void CalculateSpawnPoints() {
        int villagerSpawnPointIndex = 0;
        int ogreSpawnPointIndex = 0;
        int goalPointIndex = 0;
        
        villagerSpawnPointIndex = Random.Range(0, 8);
        ogreSpawnPointIndex = (villagerSpawnPointIndex + 1 + Random.Range(0, 5)) % 8;
        goalPointIndex = Random.Range(0, 4);

        Vector3 villagerSpawnPoint;
        Vector3 ogreSpawnPoint;
        Vector3 goalPoint;

        villagerSpawnPoint = spawnPoints[villagerSpawnPointIndex];
        ogreSpawnPoint = spawnPoints[ogreSpawnPointIndex];
        goalPoint = goalPoints[goalPointIndex];

        Manager.spawnPoint = ogreSpawnPoint;
        //OSC
    }
    
    void InitializePoints() {
        spawnPoints[0] = new Vector3(-45.0f,   0.0f,  45.0f);
        spawnPoints[1] = new Vector3(  0.0f,   0.0f,  45.0f);
        spawnPoints[2] = new Vector3( 45.0f,   0.0f,  45.0f);
        spawnPoints[3] = new Vector3( 45.0f,   0.0f,   0.0f);
        spawnPoints[4] = new Vector3( 45.0f,   0.0f, -45.0f);
        spawnPoints[5] = new Vector3(  0.0f,   0.0f, -45.0f);
        spawnPoints[6] = new Vector3(-45.0f,   0.0f, -45.0f);
        spawnPoints[7] = new Vector3(-45.0f,   0.0f,   0.0f);

        goalPoints[0] = new Vector3(-25.0f,    0.0f,  25.0f);
        goalPoints[0] = new Vector3( 25.0f,    0.0f,  25.0f);
        goalPoints[0] = new Vector3( 25.0f,    0.0f, -25.0f);
        goalPoints[0] = new Vector3(-25.0f,    0.0f, -25.0f);
    }
}