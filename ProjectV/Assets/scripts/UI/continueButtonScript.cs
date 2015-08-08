using UnityEngine;
using System.Collections;

public class continueButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	// ボタンをクリックするとセーブデータセレクトシーンへ移動する
	public void OnClick() {
		
		// ゲームシーンへ移動
		Debug.Log("Data Select");
		Application.LoadLevel ("GameSelect");
	}
}
