using UnityEngine;
using System.Collections;

public class Moji : MonoBehaviour {

	void OnGUI(){
		if(this.gameObject.name == "EntertheNumbers"){
			if(StartButton.GameStart){
				Destroy(GetComponent<GUIText>());
			}
		}
	}
}
