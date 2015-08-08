using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dataSelectButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {


		Text dataContents01  = GameObject.Find ("UI/" + this.name + "/DataContents01").GetComponent<Text> ();
		Debug.Log (dataContents01.text);

		dataContents01.color = Color.black;
		dataContents01.text  = PlayerPrefs.GetString(this.name + "_Contents01");
		
		Debug.Log (dataContents01.text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ボタンをクリックするとゲームシーンへ移動する
	public void OnClick() {
		
		// グローバル変数にセーブごとの値を代入してゲームスタート!
		// ex.) Global.mapNumber_X = PlayerPrefs.GetInt(this.name + "_mapNumber_X");

		Debug.Log( this.name + "Start Game!" );
		Application.LoadLevel ("GameScene");
	}
}