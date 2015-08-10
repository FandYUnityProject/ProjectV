using UnityEngine;
using System.Collections;

public class SaveScript : MonoBehaviour {

	public string mapName;
	private AudioSource av;

	// Use this for initialization
	void Start () {
		av = GetComponent<AudioSource> ();
	
	}
	
	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {
			
			Debug.Log ("Save");
			av.Play();
			// プレイヤーに触れたら、現在のデータをセーブする
			Debug.Log("mapNumber_XY: " + NowDataNumberScript.nowSaveData + "MAP" + MapNumberManager.mapNumber_X + MapNumberManager.mapNumber_Y);
			
			PlayerPrefs.SetFloat(NowDataNumberScript.nowSaveData + "mapNumber_X", this.transform.position.x);
			PlayerPrefs.SetFloat(NowDataNumberScript.nowSaveData + "mapNumber_Y", this.transform.position.y);
			PlayerPrefs.SetString(NowDataNumberScript.nowSaveData + "worldName", mapName);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_01", FUELScript.getFUEL_01);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_02", FUELScript.getFUEL_02);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_03", FUELScript.getFUEL_03);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_04", FUELScript.getFUEL_04);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_05", FUELScript.getFUEL_05);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_06", FUELScript.getFUEL_06);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "FUEL_07", FUELScript.getFUEL_07);

			if ( !GravityInversion2D.isGravity ){
				PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "isNotGravity", 1);
			} else {
				PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + "isNotGravity", 0);
			}
		}
	}
}
