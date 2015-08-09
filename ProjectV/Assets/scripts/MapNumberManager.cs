using UnityEngine;
using System.Collections;

public class MapNumberManager : MonoBehaviour {

	public static int mapNumber_X;
	public static int mapNumber_Y;
	
	// spawnオブジェクト
	public GameObject playerSpawnPoint;

	void Start(){

		// 再開時のマップ番地を取得
		mapNumber_X = PlayerPrefs.GetInt(NowDataNumberScript.nowSaveData + "mapNumber_X");
		mapNumber_Y = PlayerPrefs.GetInt(NowDataNumberScript.nowSaveData + "mapNumber_Y");

		
		// spawnオブジェクトを取得し、セーブデータに応じてプレイヤーを配置
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");
		playerSpawnPoint.transform.position = new Vector2(mapNumber_X * 20, mapNumber_Y * 10);
	}

	public static void AddMapNumberX(int x){
		mapNumber_X += x;
		Debug.Log ("Current Map Number is ("+mapNumber_X +","+ mapNumber_Y+")");
	}
	public static void AddMapNumberY(int y){
		mapNumber_Y += y;
		Debug.Log ("Current Map Number is ("+mapNumber_X +"," + mapNumber_Y+")");
	}
}
