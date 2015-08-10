using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	
	// spawnオブジェクト
	public GameObject playerSpawnPoint;
	
	// playerオブジェクト
	private GameObject playerObject;

	private Rigidbody2D rb;

	void Start(){
		
		// Spawnオブジェクトを取得
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");
		
		// Playerオブジェクトを取得
		playerObject = GameObject.FindGameObjectWithTag ("Player");

		
		rb = GetComponent<Rigidbody2D> ();

	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "KillObject") {
			// Destroy (gameObject);
			// 再開時のマップ番地に応じてSpawn場所を変更
			playerSpawnPoint.transform.position = new Vector2 (PlayerPrefs.GetFloat (NowDataNumberScript.nowSaveData + "mapNumber_X")
		                                                  , PlayerPrefs.GetFloat (NowDataNumberScript.nowSaveData + "mapNumber_Y"));

			Vector2 movement = new Vector2(0,0).normalized;
			rb.velocity = movement;

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