using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
using System.Text;

public class Client : MonoBehaviour{
    // Start is called before the first frame update
    #region Network Settings //----------追記
    public string ip;
    public int port;
	#endregion //----------追記
    // Start is called before the first frame update

    float elapsedTime = 0.0f;
    float interval = 0.2f;

    void Awake() {
        OSCHandler.Instance.clientInit("Akaoni", ip,port);//ipには接続先のipアドレスの文字列を入れる。
    }
    // Update is called once per frame
    void FixedUpdate() {
        // FixedUpdate を使わないで 5 FPSの速度で通信する
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime > interval) {
            elapsedTime = 0.0f;

            List<float> positionList = new List<float>();
            float eulerY;

            eulerY = transform.rotation.eulerAngles.y;

            positionList.Add(transform.position.x);
            positionList.Add(transform.position.y);
            positionList.Add(transform.position.z);
            positionList.Add(eulerY);

            OSCHandler.Instance.SendMessageToClient("Akaoni","/position",positionList);//Akaoniでいいのかな
        }
    }

    static public void SpawnSend(Vector3 point){
        List<float> pointList = new List<float>();
        pointList.Add(point.x);
        pointList.Add(point.y);
        pointList.Add(point.z);
        OSCHandler.Instance.SendMessageToClient("Akaoni","/Spawn",pointList);
    }

    static public void ReturnPflag(){
        OSCHandler.Instance.SendMessageToClient("Akaoni","/Pflag","OK");//本来True
    }
    static public void ReturnSflag(){
        OSCHandler.Instance.SendMessageToClient("Akaoni","/Sflag","OK");//本来True
    }
}
