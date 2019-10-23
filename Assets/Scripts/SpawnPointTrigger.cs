using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            Manager.Prepared();
            this.gameObject.SetActive(false);
        }
    }
}
