/*
 * 2Dロックマン式カメラ移動
 * カメラのtagは”Main Camera”にすること。
 * Playerのtagは”Player”にすること。
 * "gameControll.cs" をgemeControllオブジェクト(ゲーム全体を管理する空のオブジェクト)にアタッチすること。
 * "mapControll"と連携。
 * 2015/07/26 Sun - Guttyon
 * 
 * カメラの取得にtagを採用
 * playerの取得にtagを採用
 * cameraの初期位置問題を解消
 * spawmオブジェクトの利用によりmapControllとの連携を削除
 * Map番地の管理はSpawnPointを基準にすることでScript間の連携ではなくSpawnのアタッチで済ませる
 * saveも同様に管理する
 * 
 * 2015/08/06 Tur - Fujita
*/

/*
 * カメラ座標取得例
 * 	Top,Left = (-16, 12 )
 * 	Bottom,Right = (16 , -12)
*/

/*
 * mapの番地イメージ
 *  [
 *    [-2,2]  ,[-1,2]  ,[0,2]  ,[1,2]  ,[2,2]
 *   ,[-2,1]  ,[-1,1]  ,[0,1]  ,[1,1]  ,[2,2]
 *   ,[-2,0]  ,[-1,0]  ,[0,0]  ,[1,0]  ,[2,0]
 *   ,[-2,-1] ,[-1,-1] ,[0,-1] ,[1,-1] ,[2,-1]
 *   ,[-2,-2] ,[-1,-2] ,[0,-2] ,[1,-2] ,[2,-2]
 *  ]
*/
using UnityEngine;
using System.Collections;

public class moveMapRockman : MonoBehaviour {

	// camera component
	private Camera mainCamera;
	
	// playerオブジェクト Spawnオブジェクト　cameraオブジェクト
	private GameObject cameraObject;
	private GameObject playerObject;
	public GameObject playerSpawnPoint;

	// cameraの初期座標 cameraのオフセット
	public Vector3 cameraStartPosition;
	public Vector3 spawnCameraOffset;

	// 現在のmapの端座標を保存する変数
	public  float mapLeftPosition;	// Left
	public  float mapRightPosition;	// Right
	public  float mapTopPosition;	// Top
	public  float mapBottomPosition;	// Bottom

	// mapの縦横の長さを保存する変数
	public float mapWidth;	//横
	public float mapHeight;	//縦

	void Start () {
				
		// カメラオブジェクトを取得
		cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		// カメラを取得
		mainCamera = cameraObject.GetComponent<Camera> ();
		// カメラを取得の初期座標を取得
		cameraStartPosition = playerSpawnPoint.transform.position + spawnCameraOffset;

		// Playerオブジェクトを取得
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		// spawnオブジェクトを取得
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");

		mainCamera.transform.position = cameraStartPosition;
		
		// 座標値を出力
		Debug.Log ("Left,  Top" + mapLeftPosition + ", " + mapTopPosition);
		Debug.Log ("Right, Bottom" + mapRightPosition + ", " + mapBottomPosition);

		// 初期マップの座標取得
		// マップの縦横の長さ取得
		GetScreenSize ();
		
		// spawnPointに応じて開始地点にカメラ配置
		mainCamera.transform.position = playerSpawnPoint.transform.position + spawnCameraOffset; 

		// spawnPointに応じて開始地点にPlayer配置
		playerObject.transform.position = playerSpawnPoint.transform.position; 

	}
	
	void Update () {
		/* --- Playerが画面端に行くとカメラを移動させる --- */

		// 左端
		if (playerObject.transform.position.x < mapLeftPosition) {
			MoveLeftScreen();
		}
		// 右端
		if (playerObject.transform.position.x > mapRightPosition) {
			MoveRightScreen ();
		}
		// 上端
		if (playerObject.transform.position.y > mapTopPosition) {
			MoveAvobeScreen();
		}
		// 下端
		if (playerObject.transform.position.y < mapBottomPosition) {
			MoveBelowScreen();
		}
	}

	void MoveLeftScreen(){
		mainCamera.transform.position -= new Vector3(mapWidth+4f,0f,0f);
		mapLeftPosition  = mapLeftPosition - mapWidth;
		mapRightPosition = mapRightPosition - mapWidth;
	}

	void MoveRightScreen(){
		mainCamera.transform.position += new Vector3(mapWidth+4f,0f,0f);
		mapLeftPosition  = mapLeftPosition + mapWidth;
		mapRightPosition = mapRightPosition + mapWidth;
	}

	void MoveAvobeScreen(){
		mainCamera.transform.position += new Vector3(0f,mapHeight+1f,0f);
		mapTopPosition    = mapTopPosition    + mapHeight;
		mapBottomPosition = mapBottomPosition + mapHeight;
	}

	void MoveBelowScreen(){
		mainCamera.transform.position -= new Vector3(0f,mapHeight+1f,0f);
		mapTopPosition    = mapTopPosition    - mapHeight;
		mapBottomPosition = mapBottomPosition - mapHeight;
	}
	
	void GetScreenSize(){
		Vector3 topLeft = mainCamera.ScreenToWorldPoint (Vector3.zero);
		Vector3 bottomRight = mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));

		mapLeftPosition   = topLeft.x;
		mapRightPosition  = bottomRight.x;
		mapTopPosition    = bottomRight.y;
		mapBottomPosition = topLeft.y;

		mapWidth = Mathf.Abs(bottomRight.x - topLeft.x);
		mapHeight = Mathf.Abs (topLeft.y - bottomRight.y);
	}
}
