using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {

	private static bool isSaveControllObject = false;

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

		// 【デバッグ用】仮セーブ
		PlayerPrefs.SetString("Data01_Contents01", "セーブ01の中身");
		PlayerPrefs.SetString("Data02_Contents01", "セーブ02の中身");
		PlayerPrefs.SetString("Data03_Contents01", "セーブ03の中身");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}