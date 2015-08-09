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
			//Debug.Log(player.transform.position);
			//if(gapOfMap.x > 0f && gapOfMap.y == 0)
			//	MapNumberManager.AddMapNumberX(1);
			//else if(gapOfMap.x < 0f && gapOfMap.y == 0)
			//	MapNumberManager.AddMapNumberX(-1);
			//else if(gapOfMap.x == 0 && gapOfMap.y > 0)
			//	MapNumberManager.AddMapNumberY(1);
			//else if(gapOfMap.x == 0 && gapOfMap.y < 0)
			//	MapNumberManager.AddMapNumberY(-1);

		}
	}
}
