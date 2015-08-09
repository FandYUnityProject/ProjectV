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
 * 2015/08/06 Tur - Fujita
 * 
 * Map間のギャップを考慮したカメラ移動に修正(オフセットを設けた)
 * Mapサイズを16:9に固定したので画面サイズの取得を廃止
 * 2015/08/08 Sat - Fujita
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
	public float hSideGapOfMap;
	public float vSideGapOfMap;

	bool isFirstSpawn = false;

	void Start () {
				
		// カメラオブジェクトを取得
		cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		// カメラを取得
		mainCamera = cameraObject.GetComponent<Camera> ();
		// カメラを取得の初期座標を取得
		cameraStartPosition = mainCamera.transform.position;//playerSpawnPoint.transform.position + spawnCameraOffset;

		// Playerオブジェクトを取得
		playerObject = GameObject.FindGameObjectWithTag ("Player");
		// spawnオブジェクトを取得
		playerSpawnPoint = GameObject.Find ("PlayerSpawnPoint");

		mainCamera.transform.position = cameraStartPosition;
		
		// 座標値を出力
		//Debug.Log ("Left,  Top" + mapLeftPosition + ", " + mapTopPosition);
		//Debug.Log ("Right, Bottom" + mapRightPosition + ", " + mapBottomPosition);

		// 初期マップの座標取得
		// マップの縦横の長さ取得
		GetScreenSize ();
		
		// spawnPointに応じて開始地点にカメラ配置
		//mainCamera.transform.position = playerSpawnPoint.transform.position + spawnCameraOffset; 

	}
	
	void Update () {

		if (!isFirstSpawn) {
			
			// spawnPointに応じて開始地点にPlayer配置
			playerObject.transform.position = playerSpawnPoint.transform.position; 
			isFirstSpawn = true;
		}

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
		mainCamera.transform.position -= new Vector3(mapWidth+hSideGapOfMap,0f,0f);
		mapLeftPosition  = mapLeftPosition - (mapWidth+hSideGapOfMap);
		mapRightPosition = mapRightPosition - (mapWidth+hSideGapOfMap);
	}

	void MoveRightScreen(){
		mainCamera.transform.position += new Vector3(mapWidth+hSideGapOfMap,0f,0f);
		mapLeftPosition  = mapLeftPosition + (mapWidth+hSideGapOfMap);
		mapRightPosition = mapRightPosition + (mapWidth+hSideGapOfMap);
	}

	void MoveAvobeScreen(){
		mainCamera.transform.position += new Vector3(0f,mapHeight+vSideGapOfMap,0f);
		mapTopPosition    = mapTopPosition    + (mapHeight+vSideGapOfMap);
		mapBottomPosition = mapBottomPosition + (mapHeight+vSideGapOfMap);
	}

	void MoveBelowScreen(){
		mainCamera.transform.position -= new Vector3(0f,mapHeight+vSideGapOfMap,0f);
		mapTopPosition    = mapTopPosition    - (mapHeight+vSideGapOfMap);
		mapBottomPosition = mapBottomPosition - (mapHeight+vSideGapOfMap);
	}
	
	void GetScreenSize(){
		Vector3 topLeft = mainCamera.ScreenToWorldPoint (Vector3.zero);
		Vector3 bottomRight = mainCamera.ScreenToWorldPoint (new Vector3(Screen.width, Screen.height, 0.0f));

		mapLeftPosition   = topLeft.x;
		mapRightPosition  = bottomRight.x;
		mapTopPosition    = bottomRight.y;
		mapBottomPosition = topLeft.y;

		mapWidth = 16f;//Mathf.Abs(bottomRight.x - topLeft.x);
		mapHeight = 9f;//Mathf.Abs (topLeft.y - bottomRight.y);
	}
}
