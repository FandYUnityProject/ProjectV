using UnityEngine;
using System.Collections;

public class startButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ボタンをクリックするとゲームシーンへ移動する
	public void OnClick() {

		// ゲームシーンへ移動
		Debug.Log("Start Game!");
		Application.LoadLevel ("GameScene");
	}
}