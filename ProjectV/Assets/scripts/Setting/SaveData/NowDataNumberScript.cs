using UnityEngine;
using System.Collections;

public class NowDataNumberScript : MonoBehaviour {

	private static bool isSaveControllObject = false;

	public static string nowData = "";
	
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
