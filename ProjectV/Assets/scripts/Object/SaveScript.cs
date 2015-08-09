using UnityEngine;
using System.Collections;

public class SaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			
			Debug.Log ("Save");

			// プレイヤーに触れたら、現在のデータをセーブする
			Debug.Log("mapNumber_XY: " + NowDataNumberScript.nowSaveData + "MAP" + MapNumberManager.mapNumber_X + MapNumberManager.mapNumber_Y);
			
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "mapNumber_X", MapNumberManager.mapNumber_X);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "mapNumber_Y", MapNumberManager.mapNumber_Y);
			PlayerPrefs.SetString(NowDataNumberScript.nowSaveData + "worldName","MAP:" + MapNumberManager.mapNumber_X + MapNumberManager.mapNumber_Y);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_01", FUELScript.getFUEL_01);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_02", FUELScript.getFUEL_02);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_03", FUELScript.getFUEL_03);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_04", FUELScript.getFUEL_04);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_05", FUELScript.getFUEL_05);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_06", FUELScript.getFUEL_06);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_07", FUELScript.getFUEL_07);
		}
	}
}
