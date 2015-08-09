/*
  * 重力反転( 2Dゲーム用 )
  ※ プログラム適用時、適用するオブジェクトに”Rididbody2D”を適用させる必要がある。
  * 2015/07/25 Sat - Guttyon
 */

using UnityEngine;
using System.Collections;

public class GravityInversion2D : MonoBehaviour {

	public static bool isGravity = true;
	bool isGravityInversion = false;	// 重力反転中か（接地するまで重力反転は１度のみ）
	bool isTouch = false;
	public Vector2 Gravityparameta = new Vector2(0,20);
	
	// Update is called once per frame
	void Update () {
		// Spaceキー入力を受け取る
		if (Input.GetKeyDown (KeyCode.Space) && !isGravityInversion ){
			isGravity = !isGravity;
			isGravityInversion = true;
		}
		
		if ( isGravity ){
			Physics2D.gravity = Vector2.Scale( Vector2.down, Gravityparameta);
		} else {
			Physics2D.gravity = Vector2.Scale( Vector2.up, Gravityparameta);
		}

	}

	public void OnTriggerExit2D(Collider2D coll){
		Vector2 scale = transform.localScale;
		if (coll.gameObject.tag == "Floor" && isTouch) {
			scale.y = -1;
			transform.localScale = scale;
			isTouch = false;
		}
		if (coll.gameObject.tag == "Roof" && isTouch) {
			scale.y = 1;
			transform.localScale = scale;
			isTouch = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D coll){
		Vector2 scale = transform.localScale;
		if (coll.gameObject.tag == "Floor" && !isTouch) {
			scale.y = 1;
			transform.localScale = scale;
		}
		if (coll.gameObject.tag == "Roof" && !isTouch) {
			scale.y = -1;
			transform.localScale = scale;
		}
	}

	/// <summary>
	/// 接触した（=着地）
	/// </summary>
	/// <param name="coll">Player以外の物体</param>
	public void OnCollisionEnter2D(Collision2D coll)
	{
		isGravityInversion    = false;
		isTouch = true;

		// 接触した物体タグ>が”gravityInversionObject”(重力反転装置)なら重力反転
		if (coll.gameObject.tag == "gravityInversionObject") {
			isGravity = !isGravity;
		}
	}
}
