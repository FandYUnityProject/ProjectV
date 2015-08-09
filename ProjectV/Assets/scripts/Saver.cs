using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour {

	private bool isActive = false;
	private Transform zPosition;
	Vector3 v;
	public float saverCoolTime = 1f;
	public float saverWaitTime = 1f;
	public float timer;

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
		timer += Time.deltaTime;
		if (isActive && timer > saverCoolTime) {
			SaveGame ();
		} else if(!isActive && timer > saverWaitTime){
			v.z = 1f;
			transform.localPosition = v;
		}
	}

	void SaveGame(){
		v.z = -1f;
		transform.localPosition = v;
		isActive = false;
		timer = 0;
	}
}
