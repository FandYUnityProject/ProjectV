using UnityEngine;
using System.Collections;

public class WarpByTouch : MonoBehaviour {

	public Vector3 toTransportPosition;
	public Vector3 fromTransportPosition;
	public Vector3 gapOfMap;

	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			fromTransportPosition = coll.transform.position;
			toTransportPosition = fromTransportPosition + gapOfMap;
			player.transform.localPosition = toTransportPosition;
			Debug.Log(player.transform.position);
		}
	}
}
