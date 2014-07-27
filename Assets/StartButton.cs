using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	
	public static bool GameStart;
	
	void OnGUI(){
		if(GUI.Button (new Rect(30,30,100,40),"BingoStart")){
			GameStart = true;
		}
	}
}
