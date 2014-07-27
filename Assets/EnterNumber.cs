using UnityEngine;
using System.Collections;

public class EnterNumber : MonoBehaviour {
	
	public Material [] NumberMaterial=new Material[75];
	private RaycastHit ray_hit; 
	private Ray ray;
	bool Enterform;
	private string text;
	int CardNum;
	int gyou;
	int retu;
	
	void Start () {
		text = "";
		Enterform = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(NumberEnter.Selecting && Input.GetMouseButtonDown(0) &&!Enterform){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out ray_hit, 100);
			if(ray_hit.collider.gameObject.tag == "Number"){
				ray_hit.collider.gameObject.renderer.material.color = Color.red;
				Enterform = true;
			}
		}
	}
	
	void OnGUI(){
		
		int Num;
		
		if(Enterform){
			text = GUI.TextField(new Rect(30,400,100,60),text,2);
			if(GUI.Button (new Rect(70,460,50,20),"Define")){

				ray_hit.collider.gameObject.renderer.material = NumberMaterial[int.Parse(text)-1];
				
				CardNum = int.Parse(ray_hit.collider.gameObject.transform.parent.name.Substring(4))-1;
				
				switch(int.Parse (ray_hit.collider.gameObject.name.Substring (6))%5){
					case 0:   retu = 4; break;
					case 1:   retu = 0; break;
					case 2:   retu = 1; break;
					case 3:   retu = 2; break;
					case 4:   retu = 3; break;
				}
			
				Num = int.Parse (ray_hit.collider.gameObject.name.Substring (6));
				if(Num != 5 && Num != 10 && Num!=15 && Num!=20 && Num!=25){
						switch((int)(Num/5)){
							case 0:   gyou = 0; break;
							case 1:   gyou = 1; break;
							case 2:   gyou = 2; break;
							case 3:   gyou = 3; break;
							case 4:   gyou = 4; break;
						}
					}
				else{
						switch(Num){
							case  5:	gyou = 0;   break;
							case 10:    gyou = 1;	break;
							case 15:    gyou = 2;	break;
							case 20:    gyou = 3;	break;
							case 25:    gyou = 4;	break;
						}
					}
				
				CheckBingo.Value[CardNum,gyou,retu] = int.Parse(text);
				Enterform = false;
			}
		}
	}
}
