using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityOSC;

public class Server : MonoBehaviour{
    // Start is called before the first frame update
    #region Network Settings //----------追記
	public string serverName;
	public int inComingPort; //----------追記
	#endregion //----------追記

	private Dictionary<string, ServerLog> servers;

    CameraAdjuster cameraAdjuster;

    static bool limitPflag = false;
    static bool limitSflag = false;
    void Awake() {
        IpGetter ipGetter = new IpGetter();
        string myIP = ipGetter.GetIp();

        if (myIP == IpGetter.phone1IP) {
            serverName = IpGetter.phone2IP;

            if (this.gameObject.name == "Villager") {
                inComingPort = 8000;
            }
            else {
                inComingPort = 8001;
            }
        }
        else {
            serverName = IpGetter.phone1IP;

            if (this.gameObject.name == "Villager") {
                inComingPort = 8001;
            }
            else {
                inComingPort = 8000;
            }
        }

        OSCHandler.Instance.serverInit(serverName,inComingPort); //init OSC　//----------変更
        servers = new Dictionary<string, ServerLog>();
        cameraAdjuster = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<CameraAdjuster>();
    }

    // Update is called once per frame

    void Update() {
        OSCHandler.Instance.UpdateLogs();
		servers = OSCHandler.Instance.Servers;
    }
    
    void LateUpdate(){
        foreach( KeyValuePair<string, ServerLog> item in servers ){
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if(item.Value.log.Count > 0){
				int lastPacketIndex = item.Value.packets.Count - 1;

				// UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}",
				// 	item.Key, // Server name
				// 	item.Value.packets[lastPacketIndex].Address, // OSC address
				// 	item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value

                if(item.Value.packets[lastPacketIndex].Address.ToString() == "/input"){
                    Vector3 velocity;
                    Quaternion rot;

                    velocity.x = (float)item.Value.packets[lastPacketIndex].Data[0];
                    velocity.y = 0.0f;
                    velocity.z = (float)item.Value.packets[lastPacketIndex].Data[1];
                    rot.x = (float)item.Value.packets[lastPacketIndex].Data[2];
                    rot.y = (float)item.Value.packets[lastPacketIndex].Data[3];
                    rot.z = (float)item.Value.packets[lastPacketIndex].Data[4];
                    rot.w = (float)item.Value.packets[lastPacketIndex].Data[5];
                    
                    VelocityController.inputAxis_Left = velocity;

                    // CameraAdjusterにRealSenseから送られてきたrot.eulerAngles.yを割り当てる (float型)
                    // y軸中心の回転のずれだけを補正する (x,z軸についてもずれを補正するのはめんどそう)
                    float eulerY = rot.eulerAngles.y;

                    eulerY = 360.0f - eulerY;
                    if (eulerY > 180.0f) {
                        eulerY -= 360.0f;
                    }

                    // Debug.Log(eulerY);
                    cameraAdjuster.sentAngle = eulerY;
                    cameraAdjuster.Adjust();
                }
                if(item.Value.packets[lastPacketIndex].Address.ToString() == "/position"){
                    Vector3 enemyPosition;
                    float rotY;
                    enemyPosition.x = (float)item.Value.packets[lastPacketIndex].Data[0];
                    enemyPosition.y = (float)item.Value.packets[lastPacketIndex].Data[1];
                    enemyPosition.z = (float)item.Value.packets[lastPacketIndex].Data[2];
                    rotY = (float)item.Value.packets[lastPacketIndex].Data[3];
                    EnemyPositionTracker.enemyPosition = enemyPosition;
                    FootSpawn.enemyAngle = rotY;
				}
				if(item.Value.packets[lastPacketIndex].Address.ToString() == "/Spawn"){
                    Debug.Log("a");
                    Vector3 spawnPosition;
                    spawnPosition.x = (float)item.Value.packets[lastPacketIndex].Data[0];
                    spawnPosition.y = (float)item.Value.packets[lastPacketIndex].Data[1];
                    spawnPosition.z = (float)item.Value.packets[lastPacketIndex].Data[2];
                    Manager.spawnPoint = spawnPosition;
				}
                if(item.Value.packets[lastPacketIndex].Address.ToString() == "/Pflag" && !limitPflag){
                    Master.flagCount++;
                    limitPflag = true;
				}
                if(item.Value.packets[lastPacketIndex].Address.ToString() == "/Sflag" && !limitSflag){
                    Manager.GameStart();
                    limitSflag = true;
				}
			}
		}
        // Debug.Log(Time.deltaTime);
    }
}
