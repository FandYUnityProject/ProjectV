using UnityEngine;
using System.Collections;

public class FUELScript : MonoBehaviour {
	
	public static int getFUEL_01;
	public static int getFUEL_02;
	public static int getFUEL_03;
	public static int getFUEL_04;
	public static int getFUEL_05;
	public static int getFUEL_06;
	public static int getFUEL_07;

	// Use this for initialization
	void Start () {
		
		getFUEL_01 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_01");
		getFUEL_02 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_02");
		getFUEL_03 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_03");
		getFUEL_04 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_04");
		getFUEL_05 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_05");
		getFUEL_06 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_06");
		getFUEL_07 = PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + "FUEL_07");

		if (PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + this.name) == 1) {
			GameObject.Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {

			if( this.name == "FUEL_01" ){ getFUEL_01 = 1; }
			if( this.name == "FUEL_02" ){ getFUEL_02 = 1; }
			if( this.name == "FUEL_03" ){ getFUEL_03 = 1; }
			if( this.name == "FUEL_04" ){ getFUEL_04 = 1; }
			if( this.name == "FUEL_05" ){ getFUEL_05 = 1; }
			if( this.name == "FUEL_06" ){ getFUEL_06 = 1; }
			if( this.name == "FUEL_07" ){ getFUEL_07 = 1; }

			GameObject.Destroy(gameObject);
		}
	}
}
