using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour {
    static float density {set; get;} = 0.01f;
    float time = 0.0f;
    float stroke;

    void Start() {
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fog = true;
        RenderSettings.fogColor = Color.red;
        RenderSettings.fogDensity = density;

        stroke = 1.0f / (PlayerStatus.tension);
    }

    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            PlayerStatus.tension += 0.1f * Time.deltaTime;
            Debug.Log("Player : " + PlayerStatus.tension);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            PlayerStatus.tension -= 0.1f * Time.deltaTime;
            Debug.Log("Player : " + PlayerStatus.tension);
        }

        density = 0.01f + PlayerStatus.tension / 25.0f;
        RenderSettings.fogDensity = density;

        time += Time.deltaTime;
    }
}