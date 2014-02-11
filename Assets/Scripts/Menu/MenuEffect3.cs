using UnityEngine;
using System.Collections;

public class MenuEffect3 : MonoBehaviour {

	void OnMouseOver(){
		
		animation.Play("Aide");
		
	}
	
	void OnMouseExit(){
		
		animation.Stop("Aide");
		
		//transform.position.Set(-508.1646f,79.00017f,489.0824f);
		
	}
	
	void OnMouseDown(){
		
		//audio.Play();
		//Application.LoadLevel("Introduction");
		
	}
}
