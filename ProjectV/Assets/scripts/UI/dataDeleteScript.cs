using UnityEngine;
using System.Collections;

public class dataDeleteScript : MonoBehaviour {
	
	public GameObject dataButtonObject;
	dataSelectButtonScript dataSelectButton;

	// Use this for initialization
	void Start () {
	
		dataSelectButton = dataButtonObject.GetComponent<dataSelectButtonScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ボタンをクリックするとゲームシーンへ移動する
	public void OnClick() {

		if( this.name == "Delete01" ){
			PlayerPrefs.SetInt ("Data01isNotNewGame", 0);
			
			PlayerPrefs.SetInt("Data01mapNumber_X", 0 );
			PlayerPrefs.SetInt("Data01mapNumber_Y", 0 );
			PlayerPrefs.SetString("Data01worldName", "" );
			PlayerPrefs.SetInt("Data01FUEL_01", 0 );
			PlayerPrefs.SetInt("Data01FUEL_02", 0 );
			PlayerPrefs.SetInt("Data01FUEL_03", 0 );
			PlayerPrefs.SetInt("Data01FUEL_04", 0 );
			PlayerPrefs.SetInt("Data01FUEL_05", 0 );
			PlayerPrefs.SetInt("Data01FUEL_06", 0 );
			PlayerPrefs.SetInt("Data01FUEL_07", 0 );

			dataSelectButton.ReData();
		}

		if( this.name == "Delete02" ){
			PlayerPrefs.SetInt ("Data02isNotNewGame", 0);
			
			PlayerPrefs.SetInt("Data02mapNumber_X", 0 );
			PlayerPrefs.SetInt("Data02mapNumber_Y", 0 );
			PlayerPrefs.SetString("Data02worldName", "" );
			PlayerPrefs.SetInt("Data02FUEL_01", 0 );
			PlayerPrefs.SetInt("Data02FUEL_02", 0 );
			PlayerPrefs.SetInt("Data02FUEL_03", 0 );
			PlayerPrefs.SetInt("Data02FUEL_04", 0 );
			PlayerPrefs.SetInt("Data02FUEL_05", 0 );
			PlayerPrefs.SetInt("Data02FUEL_06", 0 );
			PlayerPrefs.SetInt("Data02FUEL_07", 0 );
			
			dataSelectButton.ReData();
		}

		if( this.name == "Delete03" ){
			PlayerPrefs.SetInt ("Data03isNotNewGame", 0);
			
			PlayerPrefs.SetInt("Data03mapNumber_X", 0 );
			PlayerPrefs.SetInt("Data03mapNumber_Y", 0 );
			PlayerPrefs.SetString("Data03worldName", "" );
			PlayerPrefs.SetInt("Data03FUEL_01", 0 );
			PlayerPrefs.SetInt("Data03FUEL_02", 0 );
			PlayerPrefs.SetInt("Data03FUEL_03", 0 );
			PlayerPrefs.SetInt("Data03FUEL_04", 0 );
			PlayerPrefs.SetInt("Data03FUEL_05", 0 );
			PlayerPrefs.SetInt("Data03FUEL_06", 0 );
			PlayerPrefs.SetInt("Data03FUEL_07", 0 );
			
			dataSelectButton.ReData();
		}
	}
}
