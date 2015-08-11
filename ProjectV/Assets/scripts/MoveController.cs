using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float speed;

	//private Rigidbody2D rb;
	private Animator anim;
	private bool isMove = false;
	private Transform playerTransform;
	private AudioSource av;
	
	public AudioClip TouchSound;
	public AudioClip DamageClip;
	public AudioClip GetFuelClip;

	void Start(){
		//rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		playerTransform = GetComponent<Transform> ();
		av = GetComponent<AudioSource> ();
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
		Vector2 movement = new Vector2(horizontalMove,0).normalized;
		//rb.velocity = movement * speed;
		transform.Translate(movement * speed);
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject) {
			av.clip = TouchSound;
			av.Play ();
		}
		if (coll.gameObject.tag == "KillObject") {
			av.clip = DamageClip;
			av.Play();
		}
	}

	void OnTirrigerEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Fuel") {
			av.clip = GetFuelClip;
			av.Play();
		}
	}
}
