using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	
	// spawnオブジェクト
	public GameObject playerSpawnPoint;
	
	// playerオブジェクト
	private GameObject playerObject;

	void Start(){
		
		// Spawnオブジェクトを取得
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");
		
		// Playerオブジェクトを取得
		playerObject = GameObject.FindGameObjectWithTag ("Player");
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "KillObject") {
			// Destroy (gameObject);
			
			// 再開時のマップ番地に応じてSpawn場所を変更
			playerSpawnPoint.transform.position = new Vector2 (PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "mapNumber_X") * 20
		                                                  , PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "mapNumber_Y") * 10);
			
			// spawnPointに応じて開始地点にPlayer配置
			playerObject.transform.position = playerSpawnPoint.transform.position;
			
			// 開始時の重力反転情報を取得
			if (PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "isNotGravity") == 0) {
				GravityInversion2D.isGravity = true;
			} else {
				GravityInversion2D.isGravity = false;
			}
		}
	}
}