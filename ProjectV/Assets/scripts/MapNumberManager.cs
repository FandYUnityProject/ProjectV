using UnityEngine;
using System.Collections;

public class MapNumberManager : MonoBehaviour {

	public static float mapNumber_X;
	public static float mapNumber_Y;
	
	// spawnオブジェクト
	public GameObject playerSpawnPoint;

	// playerオブジェクト
	private GameObject playerObject;

	void Start(){

		// 再開時のマップ番地を取得
		mapNumber_X = PlayerPrefs.GetFloat(NowDataNumberScript.nowSaveData + "mapNumber_X");
		mapNumber_Y = PlayerPrefs.GetFloat(NowDataNumberScript.nowSaveData + "mapNumber_Y");

		
		// 再開時のマップ番地に応じてSpawn場所を変更
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");
		playerSpawnPoint.transform.position = new Vector2(mapNumber_X, mapNumber_Y);

		// Playerオブジェクトを取得
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		// spawnPointに応じて開始地点にPlayer配置
		playerObject.transform.position = playerSpawnPoint.transform.position;

		// 開始時の重力反転情報を取得
		if (PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "isNotGravity") == 0) {
			GravityInversion2D.isGravity = true;
		} else {
			GravityInversion2D.isGravity = false;
		}
	}
	//2015/8/9 MapNumberの取得を廃止
	//public static void AddMapNumberX(int x){
	//	mapNumber_X += x;
	//	Debug.Log ("Current Map Number is ("+mapNumber_X +","+ mapNumber_Y+")");
	//}
	//public static void AddMapNumberY(int y){
	//	mapNumber_Y += y;
	//	Debug.Log ("Current Map Number is ("+mapNumber_X +"," + mapNumber_Y+")");
	//}
}
