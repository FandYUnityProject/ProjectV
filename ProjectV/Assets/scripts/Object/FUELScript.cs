using UnityEngine;
using System.Collections;

public class FUELScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt (NowDataNumberScript.nowSaveData + this.name) == 1) {
			GameObject.Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") {

			GameObject.Destroy(gameObject);
			PlayerPrefs.SetInt(NowDataNumberScript.nowSaveData + this.name, 1);
		}
	}
}
