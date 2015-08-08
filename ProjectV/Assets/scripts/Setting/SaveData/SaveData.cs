using UnityEngine;
using System.Collections;

public class SaveData : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
		// シーン遷移しても削除させない
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}