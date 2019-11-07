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

    static bool limitPflag = false;
    static bool limitSflag = false;
    void Awake() {
        OSCHandler.Instance.serverInit(serverName,inComingPort); //init OSC　//----------変更
        servers = new Dictionary<string, ServerLog>();    
    }

    // Update is called once per frame
    void Update(){
        OSCHandler.Instance.UpdateLogs();
		servers = OSCHandler.Instance.Servers;

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
                    float rotY;
                    velocity.x = (float)item.Value.packets[lastPacketIndex].Data[0];
                    velocity.y = 0.0f;
                    velocity.z = (float)item.Value.packets[lastPacketIndex].Data[1];
                    rotY = (float)item.Value.packets[lastPacketIndex].Data[2];
                    VelocityController.inputAxis_Left = velocity;
                    // rotYをCharacterMovement scriptに割り当てる
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
