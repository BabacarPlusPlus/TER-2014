using UnityEngine;
using System.Collections;

public class MenuEffect6 : MonoBehaviour {

	void OnMouseOver(){
		
		animation.Play("quit");
		
	}
	
	void OnMouseExit(){
		
		animation.Stop("quit");
		
		//transform.position.Set(-508.1646f,79.00017f,489.0824f);
		
	}
	
	void OnMouseDown(){
		
		//audio.Play();sdsd
		//Application.LoadLevel("Introduction");
		
	}
}
