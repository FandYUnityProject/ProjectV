﻿using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float speed;

	//private Rigidbody2D rb;
	private Animator anim;
	private bool isMove = false;
	private Transform playerTransform;
	public Vector2 scale;//= playerTransform.localScale;
	public float positivePlayerScale_X;
	public float negativePlayerScale_X;

	void Start(){
		//rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerTransform = GetComponent<Transform> ();
	}

	void Update(){
		float horizontalMove = Input.GetAxisRaw ("Horizontal");
		scale = playerTransform.localScale;

		if (horizontalMove > 0f) {
			isMove = true;
			scale.x = negativePlayerScale_X;
		} else if (horizontalMove < 0f) {
			isMove = true;
			scale.x = positivePlayerScale_X;
		} else {
			isMove =false;
		}
		transform.localScale = scale;

		if (isMove) {
			anim.SetBool ("Walking", true);
			Move(horizontalMove);
		} else {
			anim.SetBool ("Walking", false);
		}

	}

	void Move(float horizontalMove){
		Vector2 movement = new Vector2(horizontalMove,0).normalized;
		//rb.velocity = movement * speed;
		transform.Translate(movement * speed);
	}
}
