using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPositionTracker : MonoBehaviour {
    public static Vector3 enemyPosition{set; get;}
    private void Update() {
        this.transform.position = enemyPosition;
    }
}