using UnityEngine;
using System.Collections;

public class MenuEffect2 : MonoBehaviour {

	void OnMouseOver(){
		
		animation.Play("charger une partie");
		
	}
	
	void OnMouseExit(){
		
		animation.Stop("charger une partie");
		
		//transform.position.Set(-508.1646f,79.00017f,489.0824f);
		
	}
	
	void OnMouseDown(){
		
		//audio.Play();
		//Application.LoadLevel("Introduction");
		
	}
}
