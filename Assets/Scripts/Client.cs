using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityOSC;
using System.Text;
using System.Threading.Tasks;

public class Client : MonoBehaviour{
    // Start is called before the first frame update
    #region Network Settings //----------追記
    public string ip;
    public int port;
	#endregion //----------追記
    // Start is called before the first frame update

    float elapsedTime = 0.0f;
    float interval = 0.2f;

    GameObject CameraAngle;

    void Awake() {
        IpGetter ipGetter = new IpGetter();
        string myIP = ipGetter.GetIp();

        if (myIP == IpGetter.phone1IP) {
            ip = IpGetter.phone2IP;
        }
        else {
            ip = IpGetter.phone1IP;
        }
        
        if (this.gameObject.name == "Ogre") {
            port = 8001;
        }
        else {
            port = 8000;
        }

        Debug.Log("client IP : " + ip + "   port : " + port);

        OSCHandler.Instance.clientInit("Akaoni", ip,port);//ipには接続先のipアドレスの文字列を入れる。
    }
    void Start() {
        CameraAngle = this.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
    }
    void Update() {
        // FixedUpdate を使わないで 5 FPSの速度で通信する
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime > interval) {
            elapsedTime = 0.0f;

            List<float> positionList = new List<float>();
            float eulerY;

            eulerY = CameraAngle.transform.eulerAngles.y;

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

    static public async void ReturnPflag(){
        for (int i = 0; i < 30; i++) {
            OSCHandler.Instance.SendMessageToClient("Akaoni","/Pflag","OK");//本来True
            await Task.Delay(15);
        }
    }
    static public async void ReturnSflag(){
        for (int i = 0; i < 30; i++) {
            await Task.Delay(15);
            OSCHandler.Instance.SendMessageToClient("Akaoni","/Sflag","OK");//本来True
        }
    }
}
