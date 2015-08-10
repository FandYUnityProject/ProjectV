using UnityEngine;
using System.Collections;

public class DamageByContact : MonoBehaviour {

	private AudioSource av;

	void Start(){
		av = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			av.Play();
		}
	}
}