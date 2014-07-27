using UnityEngine;
using System.Collections;

public class CheckBingo : MonoBehaviour {
	
	public static int [,,]Value = new int [40,5,5]; 
	
	private string text;
	private GameObject []Card = new GameObject[40];
	private int BingoNumber;
	private int Tatecount;
	private int Yokocount;
	private int Nanamecount1;
	private int Nanamecount2;
	
	void Start(){
		int i;
		int j;
		int k;
		
		text = "";
		
		for(i=0; i<40; i++){
			for(j=0; j<5; j++){
				for(k=0; k<5; k++){
					if(j == 2 && k == 2){
						Value[i,j,k] = 0;
					}
					else{
						Value[i,j,k] = 76;
					}
				}
			}
		}
	}
	
	void OnGUI () {
		if(StartButton.GameStart){
			text = GUI.TextField(new Rect(30,400,100,60),text,2);
			if(GUI.Button (new Rect(70,460,50,20),"Bingo!")){
				BingoNumber = int.Parse (text);
				TurnBlack ();
				Check();
				text = "";
			}
		}
	}
	
	void TurnBlack(){
		int i;
		int j;
		int k;
		int l;
		
		for(i=0; i<40; i++){
			for(j=0; j<5; j++){
				for(k=0; k<5; k++){
					if(Value[i,j,k] == BingoNumber){
						Value[i,j,k] = 0;
						Card = GameObject.FindGameObjectsWithTag("Card");
						for(l=0; l<40; l++){
							if(int.Parse (Card[l].name.Substring (4))-1 == i){
								Card[l].transform.FindChild("Number" + (j*5+k+1)).renderer.material.color = Color.black;
							}
						}
					}
				}
			}
		}
		
	}
	
	
	void Check(){
		int i;
		int j;
		int k;
	
	    //横走査
		for(i=0; i<40; i++){
			for(j=0; j<5; j++){
				for(k=0; k<5; k++){
					if(Value[i,j,k] == 0){
						Yokocount++;
					}
				}
				if( Yokocount == 5){
					BingoColorChange(i);
					Debug.Log ("YokoBingo");
				}
				else if(Yokocount == 4){
					ReachColorChange(i);
					Debug.Log ("YokoReach");
				}
				Yokocount = 0;
			}
			Yokocount = 0;
		}
		
		//縦走査
		for(i=0; i<40; i++){
			for(k=0; k<5; k++){
				for(j=0; j<5; j++){
					if(Value[i,j,k] == 0){
						Tatecount++;
					}
				}
				if( Tatecount == 5){
					BingoColorChange (i);
					Debug.Log ("TateBingo");
				}
				else if(Tatecount == 4){
					ReachColorChange (i);
					Debug.Log ("TateReach");
				}
				Tatecount = 0;
			}
			Tatecount = 0;
		}
		
		//ななめ走査
		for(i=0; i<40; i++){
			for(j=0; j<5; j++){
				if(Value[i,j,j] == 0){
					Nanamecount1++;
				}
				if( Nanamecount1 == 5){
					BingoColorChange(i);
					Debug.Log ("NaNameBingo");
				}
				else if(Nanamecount1 == 4){
					ReachColorChange(i);
					Debug.Log ("NaNameReach");
				} 
			}
			Nanamecount1 = 0;
		}
		
		for(i=0; i<40; i++){
			for(j=0; j<5; j++){
				for(k=0; k<5; k++){
					if(j+k == 4){
						if(Value[i,j,k] == 0){
							Nanamecount2++;
						}
					}
				}
				if(Nanamecount2 == 5){
					BingoColorChange(i);
					Debug.Log ("NaNameBingo");
				}
				else if(Nanamecount2 == 4){
					ReachColorChange(i);
					Debug.Log ("NaNameReach");
				}
			}
			Nanamecount2 = 0;
		}	
	}
	
	void BingoColorChange(int CardNum){
		int l;
		
		for(l=0; l<40; l++){
			if(int.Parse (Card[l].name.Substring (4))-1 == CardNum){
				switch(Card[l].name){
					case "Card1":
					case "Card2":
					case "Card3":
					case "Card4":
					case "Card5":
					case "Card6":
					case "Card7":
					case "Card9":
					case "Card10":
					case "Card21":
						Card[l].transform.FindChild("Card").renderer.material.color = Color.red;
					break;
					default:
						Card[l].transform.renderer.material.color = Color.red;
					break;
				}
			}
		}
	}
	
	void ReachColorChange(int CardNum){
		int l;
		
		for(l=0; l<40; l++){
			if(int.Parse (Card[l].name.Substring (4))-1 == CardNum){
					switch(Card[l].name){
					case "Card1":
					case "Card2":
					case "Card3":
					case "Card4":
					case "Card5":
					case "Card6":
					case "Card7":
					case "Card9":
					case "Card10":
					case "Card21":
						Card[l].transform.FindChild("Card").renderer.material.color = Color.yellow;
					break;
					default:
						Card[l].transform.renderer.material.color = Color.yellow;
					break;
				}
			}
		}
	}
	

}
