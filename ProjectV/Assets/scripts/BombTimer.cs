using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BombTimer : MonoBehaviour {
	
	public  float Timer = 60.0f;
	public Text timeText;
	public GameObject CanvasObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (FUELScript.isBomb) {
			
			timeText.enabled = true;

			if (Timer > 0) {
				Timer -= Time.deltaTime;
				timeText.text = Timer.ToString ();
				
				//Debug.Log (Timer);
			} else {
				
				Application.LoadLevel ("GameSelect");
			}
		} else {
			timeText.enabled = false;
		}

	}
}
