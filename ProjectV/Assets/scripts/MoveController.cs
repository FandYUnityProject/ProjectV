using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;
	private Animator anim;
	private bool isMove = false;
	private Transform playerTransform;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerTransform = GetComponent<Transform> ();
	}

	void Update(){
		float horizontalMove = Input.GetAxisRaw ("Horizontal");
		Vector2 scale = playerTransform.localScale;

		if (horizontalMove > 0f) {
			isMove = true;
			scale.x = -1f;
		} else if (horizontalMove < 0f) {
			isMove = true;
			scale.x = 1f;
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
		Vector2 movement = new Vector2(horizontalMove,0);
		rb.velocity = movement * speed;
	}
}
