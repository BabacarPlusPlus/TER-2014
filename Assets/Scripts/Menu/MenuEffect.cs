using UnityEngine;
using System.Collections;

public class MenuEffect : MonoBehaviour {

	void OnMouseOver(){
	
		animation.Play("nouvelle partie");

	}
	
	void OnMouseExit(){
		
		animation.Stop("nouvelle partie");
	
		//transform.position.Set(-508.1646f,79.00017f,489.0824f);
		
	}
	
	void OnMouseDown(){
		
		//audio.Play();
		Application.LoadLevel("Jeu");
		
	}
}
