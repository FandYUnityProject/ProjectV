using UnityEngine;
using System.Collections;

public class dataDeleteScript : MonoBehaviour {
	
	public GameObject dataButtonObject;
	dataSelectButtonScript dataSelectButton;
	string dataNumberName;

	// Use this for initialization
	void Start () {
	
		dataSelectButton = dataButtonObject.GetComponent<dataSelectButtonScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ボタンをクリックするとゲームシーンへ移動する
	public void OnClick() {
		
		if( this.name == "Delete01" ){ dataNumberName = "Data01"; }
		if( this.name == "Delete02" ){ dataNumberName = "Data02"; }
		if( this.name == "Delete03" ){ dataNumberName = "Data03"; }

		PlayerPrefs.SetInt(dataNumberName + "isNotNewGame", 0);
		PlayerPrefs.SetInt(dataNumberName + "mapNumber_X", 0 );
		PlayerPrefs.SetInt(dataNumberName + "mapNumber_Y", 0 );
		PlayerPrefs.SetString(dataNumberName + "worldName", "" );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_01", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_02", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_03", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_04", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_05", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_06", 0 );
		PlayerPrefs.SetInt(dataNumberName + "FUEL_07", 0 );
		PlayerPrefs.SetInt(dataNumberName + "isNotGravity", 0 );

		if(dataSelectButton!=null){
			dataSelectButton.ReData();
		} else {
			Debug.LogWarning("Set Game Object!!");
		}

	}
}
