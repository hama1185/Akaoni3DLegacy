using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public static float sentAngle{set;get;}
    GameObject PhoneCam;
    // Start is called before the first frame update
    void Start(){
        PhoneCam = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update(){
        float subtraction = sentAngle - PhoneCam.transform.rotation.eulerAngles.y;
        //まだ修正

        this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, -subtraction, 0.0f));
    }
}
