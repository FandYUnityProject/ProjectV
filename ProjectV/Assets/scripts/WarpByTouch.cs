using UnityEngine;
using System.Collections;

public class WarpByTouch : MonoBehaviour {

	public Vector3 toTransportPosition;
	public Vector3 fromTransportPosition;

	void OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			fromTransportPosition = coll.transform.position;
		}
	}
}
