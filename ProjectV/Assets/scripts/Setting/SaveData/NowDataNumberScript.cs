using UnityEngine;
using System.Collections;

public class NowDataNumberScript : MonoBehaviour {

	private static bool isSaveControllObject = false;

	public static string nowSaveData = "";
	bool isLoadData = false;

	// セーブデータの値保存用変数
	public static int MST_mapNumber_X;
	public static int MST_mapNumber_Y;
	public static string MST_worldName;
	public static int MST_FUEL_01;
	public static int MST_FUEL_02;
	public static int MST_FUEL_03;
	public static int MST_FUEL_04;
	public static int MST_FUEL_05;
	public static int MST_FUEL_06;
	public static int MST_FUEL_07;
	
	// saveContoroll(Object)が重複作成されるのを防ぐ
	void Awake (){
		if (!isSaveControllObject) {
			
			// シーン遷移しても削除させない
			DontDestroyOnLoad (this);
			isSaveControllObject = true;
		} else {
			
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// ゲームシーンに移動したら、セーブデータ毎のデータを取得する
		if (Application.loadedLevelName == "Level01" && !isLoadData) {

			Debug.Log(nowSaveData);

			MST_mapNumber_X = PlayerPrefs.GetInt(nowSaveData + "mapNumber_X");
			MST_mapNumber_Y = PlayerPrefs.GetInt(nowSaveData + "mapNumber_Y");
			MST_worldName   = PlayerPrefs.GetString(nowSaveData + "worldName");
			MST_FUEL_01     = PlayerPrefs.GetInt(nowSaveData + "FUEL_01");
			MST_FUEL_02     = PlayerPrefs.GetInt(nowSaveData + "FUEL_02");
			MST_FUEL_03     = PlayerPrefs.GetInt(nowSaveData + "FUEL_03");
			MST_FUEL_04     = PlayerPrefs.GetInt(nowSaveData + "FUEL_04");
			MST_FUEL_05     = PlayerPrefs.GetInt(nowSaveData + "FUEL_05");
			MST_FUEL_06     = PlayerPrefs.GetInt(nowSaveData + "FUEL_06");
			MST_FUEL_07     = PlayerPrefs.GetInt(nowSaveData + "FUEL_07");

			Debug.Log("MST_mapNumber_X: " + MST_mapNumber_X + ", MST_mapNumber_Y: " + MST_mapNumber_Y + ", MST_worldName: " + MST_worldName + ", MST_FUEL_01: " + MST_FUEL_01 + ", MST_FUEL_02: " + MST_FUEL_02 + ", MST_FUEL_03: " + MST_FUEL_03 + ", MST_FUEL_04: " + MST_FUEL_04 + ", MST_FUEL_05: " + MST_FUEL_05 + ", MST_FUEL_06: " + MST_FUEL_06 + ", MST_FUEL_07: " + MST_FUEL_07);

			isLoadData = true;
			return;
		}
	
	}
}
