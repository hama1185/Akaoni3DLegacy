using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAdjuster : MonoBehaviour {
    public static float sentAngle{get; set;} = 0.0f;
    GameObject phoneCam;

    public Text GyroText;
    public Text RealText;
    public Text AdjustText;
    public Text SubText;
    
    float LEVEL = 1.0f;
    float cumulatedSubtraction = 0.0f;

    void Start(){
        phoneCam = this.transform.GetChild(0).gameObject;
    }

    void Update(){
        float subtraction = sentAngle - phoneCam.transform.localEulerAngles.y - this.transform.localEulerAngles.y;

        if (subtraction < -180.0f) {
            subtraction += 360.0f;
        }
        while (subtraction > 360.0f) {
            subtraction -= 360.0f;
        }
        if (subtraction > 180.0f) {
            subtraction -= 360.0f;
        }
        
        GyroText.text = phoneCam.transform.localEulerAngles.y.ToString();
        RealText.text = sentAngle.ToString();
        AdjustText.text = this.transform.localEulerAngles.y.ToString();
        SubText.text = subtraction.ToString();
        // Debug.Log(subtraction);

        if (subtraction > LEVEL) {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, subtraction + this.transform.localEulerAngles.y, 0.0f));
        }
    }
}
