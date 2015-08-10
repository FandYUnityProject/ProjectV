/*
 * ちくわブロック（？）機能 
 * アタッチしたスプライトに触れると、一定時間後に消滅する
 *  2015/08/09 Guttyon
*/
using UnityEngine;
using System.Collections;

public class ChikuwaBlockScript : MonoBehaviour {
	
	float fadeOutTime  		= 1.0f;	// 消滅するまでの時間
	float fadeOutWaitTime	= 0.9f;	// 消滅開始するまでの時間
	float fadeOutSpeed      = 0.05f; // 消滅時間の調整
	float remakeTime   		= 1.5f;	// 復活するまでの時間
	float currentRemainTime;		// 消滅するまでの残り時間を保持
	float currentRemakeTime;		// 復活するまでの残り時間を保持
	bool  isChikuwaHit    = false;	// スプライトに触れたかどうか
	bool  isChikuwaDelete = false;	// スプライトが消滅したかどうか
	
	SpriteRenderer spRenderer;	// アタッチするスプライト

	// Use this for initialization
	void Start () {
	
		// 初期化
		currentRemainTime = fadeOutTime + fadeOutWaitTime;
		currentRemakeTime = remakeTime;
		spRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isChikuwaHit) {
			
			// スプライトに触れたら消滅までの残り時間を更新
			currentRemainTime -= Time.deltaTime + fadeOutSpeed;

			if ( currentRemainTime <= 0.0f ) {

				// 残り時間が無くなったら消滅フラグを立てる
				currentRemainTime = 0;
				isChikuwaDelete   = true;
			}

			//--- 消滅（縮小）処理 ---//
			float objectScale = currentRemainTime / fadeOutTime;
			
			if ( currentRemainTime >= 1.57f ){
				objectScale = 1.57f;
			}
			spRenderer.transform.localScale = new Vector2(objectScale, objectScale);

			/*
			 * フェードアウトの場合
			if ( currentRemainTime <= 0f ) {

				// 残り時間が無くなったら自分自身を消滅
				GameObject.Destroy(gameObject);
				return;
			}

			//--- フェードアウト ---//
			float alpha = currentRemainTime / fadeOutTime;	// 消滅までの残り時間に合わせて透過していく
			var color = spRenderer.color;
			color.a = alpha;
			spRenderer.color = color;
			*/
		}

		// 消滅したら
		if (isChikuwaDelete) {

			// 復活までの残り時間を更新
			currentRemakeTime -= Time.deltaTime;

			if(currentRemakeTime <= 0f ){

				// 残り時間が無くなったら復活させ、消滅までの残り時間を初期化する
				isChikuwaHit = false;
				spRenderer.transform.localScale = new Vector2(1.57f, 1.57f);
				currentRemainTime = fadeOutTime + fadeOutWaitTime;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {

			// プレイヤーに触れたことを検知（消滅開始）
			isChikuwaHit    = true;
			isChikuwaDelete = false;
			currentRemakeTime = remakeTime;
		}
	}
}