using UnityEngine;
using System.Collections;

public class MapNumberManager : MonoBehaviour {

	public static int mapNumber_X;
	public static int mapNumber_Y;

	public static void AddMapNumberX(int x){
		mapNumber_X += x;
		Debug.Log ("Current Map Number is ("+mapNumber_X +","+ mapNumber_Y+")");
	}
	public static void AddMapNumberY(int y){
		mapNumber_Y += y;
		Debug.Log ("Current Map Number is ("+mapNumber_X +"," + mapNumber_Y+")");
	}
}
