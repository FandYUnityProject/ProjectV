using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour {

	private bool isActive = false;
	private Transform zPosition;
	Vector3 v;

	void Star(){
		zPosition = GetComponent<Transform> ();
		v = zPosition.transform.position;
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			isActive = true;
		}
	}

	void Update(){

		if (isActive) {
			SaveGame();
		}
	}

	void SaveGame(){
		v.z = -1f;
		transform.localPosition = v;
		Debug.Log ("Save");
	}
}
