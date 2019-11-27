using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour {
    public static Vector3 inputAxis_Left {get; set;} = Vector3.zero;
    public Vector3 velocity {get; set;}
    float MAX_SPEED = 5.0f;
    float speed;
    float level;
    (string moveH, string moveV, string viewH, string viewV) key;

    void Start() {
        speed = 10.0f;
        level = 0.38f * speed;
        key = KeyConfig.SetKeyConfig();
    }

    void Update() {
		// // // ゲームパッドによる速度入力

        // float moveLR = 0.0f;
        // float moveFB = 0.0f;
        // moveLR = Input.GetAxis(key.moveH) * speed;
	    // moveFB = Input.GetAxis(key.moveV) * speed;

        // inputAxis_Left = new Vector3(moveLR, 0.0f, moveFB);
        // inputAxis_Left = this.transform.rotation * inputAxis_Left;

        // // //

        inputAxis_Left *= speed;

        float magnitude = Mathf.Sqrt(Mathf.Pow(inputAxis_Left.x, 2) + Mathf.Pow(inputAxis_Left.z, 2));
        if (magnitude > MAX_SPEED) {
            inputAxis_Left = new Vector3(inputAxis_Left.x * MAX_SPEED / magnitude, 0.0f, inputAxis_Left.z * MAX_SPEED / magnitude);
        }

        if (magnitude < level) {
            velocity = Vector3.zero;
        }
        else {
            velocity = inputAxis_Left;
        }

        // Debug.Log(Time.deltaTime);
    }
}
