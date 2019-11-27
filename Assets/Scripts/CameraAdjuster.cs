using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAdjuster : MonoBehaviour {
    public float sentAngle{get; set;} = 0.0f;
    GameObject phoneCam;
    GameObject trackSpace;

    public Text TrackText;
    public Text GyroText;
    public Text RealText;
    public Text AdjustText;
    public Text SubText;

    float LEVEL = 1.5f;
    float cumulatedSubtraction = 0.0f;

    float[] gyro;
    void Start(){
        phoneCam = this.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        trackSpace = this.transform.GetChild(0).GetChild(0).gameObject;
        gyro = new float[4] {0.0f ,0.0f ,0.0f, 0.0f};
    }

    public void Adjust(){
        for(int i = 0;i < 3; i++){
            gyro[i] = gyro[i+1];
        }
        gyro[3] = phoneCam.transform.localEulerAngles.y;      
        float subtraction = sentAngle - gyro[0] - this.transform.localEulerAngles.y;
        if (subtraction < -180.0f) {
            subtraction += 360.0f;
        }
        while (subtraction > 360.0f) {
            subtraction -= 360.0f;
        }
        if (subtraction > 180.0f) {
            subtraction -= 360.0f;
        }
        TrackText.text = trackSpace.transform.localEulerAngles.y.ToString();
        GyroText.text = gyro[0].ToString();
        RealText.text = sentAngle.ToString();
        AdjustText.text = this.transform.localEulerAngles.y.ToString();
        SubText.text = subtraction.ToString();
        // Debug.Log(subtraction);

        if (Mathf.Abs(subtraction) > LEVEL) {
            this.transform.localRotation = Quaternion.Euler(new Vector3(0.0f, subtraction + this.transform.localEulerAngles.y, 0.0f));
        }
    }
}
