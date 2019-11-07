using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    Rigidbody character;
    VelocityController velocityController;
    float sensitivity;
    (string moveH, string moveV, string viewH, string viewV) key;
    
    void Start() {
        character = this.GetComponent<Rigidbody>();
        velocityController = this.GetComponent<VelocityController>();
        sensitivity = 5.0f;
        key = KeyConfig.SetKeyConfig();
    }

    void Update() {
        Vector3 angle = Vector3.zero;
        float rotH = 0.0f;
        float rotV = 0.0f;

        rotH = Input.GetAxis(key.viewH) * sensitivity;
	    // rotV = Input.GetAxis(key.viewV) * sensitivity;

        angle = new Vector3(rotV, rotH, 0.0f);

        this.transform.Rotate(angle);



        character.velocity = velocityController.velocity;

        Debug.Log("speed : " + character.velocity.magnitude + "    vecter : " + character.velocity);
        // Debug.Log(Time.deltaTime);
    }

    // ゲームパッドの通常入力操作
    // CharacterController character;
    // float sensibility;
    // float speed;
    // (string moveH, string moveV, string viewH, string viewV) key;
    
    // void Start() {
    //     character = GetComponent<CharacterController>();
    //     sensibility = 5.0f;
    //     speed = 10.0f;
    //     key = KeyConfig.SetKeyConfig();
    // }

    // void Update() {
    //     Vector3 angle = Vector3.zero;
    //     float rotH = 0.0f;
    //     float rotV = 0.0f;

    //     rotH = Input.GetAxis(key.viewH) * sensibility;
	//     // rotV = Input.GetAxis(key.viewV) * sensibility;

    //     angle = new Vector3(rotV, rotH, 0.0f);

    //     this.transform.Rotate(angle);



    //     Vector3 movement = Vector3.zero;
	// 	float moveLR = 0.0f;
    //     float moveFB = 0.0f;
        
    //     moveLR = Input.GetAxis(key.moveH) * speed;
	//     moveFB = Input.GetAxis(key.moveV) * speed;

    //     movement = new Vector3(moveLR, 0.0f, moveFB);
    //     movement = this.transform.rotation * movement;

    //     character.Move(movement * Time.deltaTime);

        // Debug.Log(character.velocity.magnitude);

        // if (character.velocity.magnitude < OgreStatus.GetMAX_SPEED()) {
        //     character.Move(movement * Time.deltaTime);
        // }
        // else {
        //     character.Move(Vector3.zero);
        // }
	// }
}