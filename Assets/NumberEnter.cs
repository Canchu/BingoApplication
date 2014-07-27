using UnityEngine;
using System.Collections;

public class NumberEnter : MonoBehaviour {
	
	public static bool  Selecting;
	
	public GameObject TestCard;
	public GameObject TestCard2;
	public GameObject TestCard3;
	
	private RaycastHit ray_hit; 
	private Ray ray;
	GameObject hitGameObject;
	GameObject hit;
	Vector3 hitGameObjectOriginalPosition;
	Vector3 hitGameObjectOriginalScale;
	
	void Update () {
		if (Input.GetMouseButton(0) && !Selecting) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out ray_hit, 200)) {
				if(ray_hit.collider.gameObject.transform.parent.gameObject == null){
					hitGameObject = ray_hit.collider.gameObject;
				}
				else{
					hitGameObject = ray_hit.collider.gameObject.transform.parent.gameObject;
				}
				hitGameObjectOriginalPosition = hitGameObject.transform.position;
				hitGameObjectOriginalScale    = hitGameObject.transform.localScale;
			}
		}
	
		if(!Selecting){
			switch(hitGameObject.name){
			case "Card1":
			case "Card2":
			case "Card4":
			case "Card5":
			case "Card9":
			case "Card21":
				hitGameObject.transform.position      =  TestCard.transform.localPosition;
				hitGameObject.transform.localScale    =  TestCard.transform.localScale;
				Selecting = true;
			break;
			case "Card3":
			case "Card6":
			case "Card7":
			case "Card10":
				hitGameObject.transform.position      =  TestCard3.transform.localPosition;
				hitGameObject.transform.localScale    =  TestCard3.transform.localScale;
				Selecting = true;
			break;
			default:
				hitGameObject.transform.position      = TestCard2.transform.position;
				hitGameObject.transform.localScale    = TestCard2.transform.localScale;
				Selecting = true;
			break;
			}
		}
		
	}
	
	void OnGUI(){
		if(Selecting){
			if(GUI.Button (new Rect(30,300,100,60),"Return")){
				hitGameObject.transform.position = hitGameObjectOriginalPosition;
				hitGameObject.transform.localScale = hitGameObjectOriginalScale;
				hitGameObject = null;
				Selecting = false;
			}
		}
	}
}
