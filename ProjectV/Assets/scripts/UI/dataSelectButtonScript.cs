using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dataSelectButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//--- データ選択ボタン内のテキストを変更 ---//
		Text worldName  = GameObject.Find ("UI/" + this.name + "/DataContents01").GetComponent<Text> ();
		Text Fuel_01    = GameObject.Find ("UI/" + this.name + "/DataContents02").GetComponent<Text> ();
		Text Fuel_02    = GameObject.Find ("UI/" + this.name + "/DataContents03").GetComponent<Text> ();
		Text Fuel_03    = GameObject.Find ("UI/" + this.name + "/DataContents04").GetComponent<Text> ();
		Text Fuel_04    = GameObject.Find ("UI/" + this.name + "/DataContents05").GetComponent<Text> ();
		Text Fuel_05    = GameObject.Find ("UI/" + this.name + "/DataContents06").GetComponent<Text> ();
		Text Fuel_06    = GameObject.Find ("UI/" + this.name + "/DataContents07").GetComponent<Text> ();
		Text Fuel_07    = GameObject.Find ("UI/" + this.name + "/DataContents07").GetComponent<Text> ();

		worldName.color = Color.black;
		Fuel_01.color   = Color.black;
		Fuel_02.color   = Color.black;
		Fuel_03.color   = Color.black;
		Fuel_04.color   = Color.black;
		Fuel_05.color   = Color.black;
		Fuel_06.color   = Color.black;
		Fuel_07.color   = Color.black;

		worldName.text  = "";
		Fuel_01.text    = "□";
		Fuel_02.text    = "□";
		Fuel_03.text    = "□";
		Fuel_04.text    = "□";
		Fuel_05.text    = "□";
		Fuel_06.text    = "□";
		Fuel_07.text    = "□";

		// もしNewGameだったら「New Game」と表示
		if (PlayerPrefs.GetInt (this.name + "isNotNewGame") == 0) {
			worldName.text = "New Game";
		} else {
			
			// それ以外だったらセーブデータの中身の一部を表示
			worldName.text = PlayerPrefs.GetString (this.name + "worldName");

			// 現在のFUEL回収状況に応じて表示
			if( PlayerPrefs.GetInt (this.name + "FUEL_01") == 1 ){ Fuel_01.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_02") == 1 ){ Fuel_02.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_03") == 1 ){ Fuel_03.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_04") == 1 ){ Fuel_04.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_05") == 1 ){ Fuel_05.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_06") == 1 ){ Fuel_06.text = "■"; }
			if( PlayerPrefs.GetInt (this.name + "FUEL_07") == 1 ){ Fuel_07.text = "■"; }
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ボタンをクリックするとゲームシーンへ移動する
	public void OnClick() {

		NowDataNumberScript.nowData = this.name;

		// もしNewGameだったら Nonニューゲームフラグを下ろし、ワールド名を「Game Start!」に設定
		// それ以外だったらマップ座標を指定してゲームスタート!
		if (PlayerPrefs.GetInt (this.name + "isNotNewGame") == 0) {

			PlayerPrefs.SetInt (this.name + "isNotNewGame", 1);
			PlayerPrefs.SetString (this.name + "worldName", "Game Start!");
		} else {
			
			// Global.mapNumber_X = PlayerPrefs.GetInt (this.name + "mapNumber_X");
			// Global.mapNumber_Y = PlayerPrefs.GetInt (this.name + "mapNumber_Y");
		}

		// Game Start!!
		Debug.Log( this.name + "Start Game!" );
		Application.LoadLevel ("Level01");
	}

	public void ReData(){

		//--- データ選択ボタン内のテキストを変更 ---//
		Text worldName  = GameObject.Find ("UI/" + this.name + "/DataContents01").GetComponent<Text> ();
		Text Fuel_01    = GameObject.Find ("UI/" + this.name + "/DataContents02").GetComponent<Text> ();
		Text Fuel_02    = GameObject.Find ("UI/" + this.name + "/DataContents03").GetComponent<Text> ();
		Text Fuel_03    = GameObject.Find ("UI/" + this.name + "/DataContents04").GetComponent<Text> ();
		Text Fuel_04    = GameObject.Find ("UI/" + this.name + "/DataContents05").GetComponent<Text> ();
		Text Fuel_05    = GameObject.Find ("UI/" + this.name + "/DataContents06").GetComponent<Text> ();
		Text Fuel_06    = GameObject.Find ("UI/" + this.name + "/DataContents07").GetComponent<Text> ();
		Text Fuel_07    = GameObject.Find ("UI/" + this.name + "/DataContents07").GetComponent<Text> ();
		
		worldName.color = Color.black;
		Fuel_01.color   = Color.black;
		Fuel_02.color   = Color.black;
		Fuel_03.color   = Color.black;
		Fuel_04.color   = Color.black;
		Fuel_05.color   = Color.black;
		Fuel_06.color   = Color.black;
		Fuel_07.color   = Color.black;

		worldName.text = "New Game";
		Fuel_01.text = "□";
		Fuel_02.text = "□";
		Fuel_03.text = "□";
		Fuel_04.text = "□";
		Fuel_05.text = "□";
		Fuel_06.text = "□";
		Fuel_07.text = "□";
	}
}