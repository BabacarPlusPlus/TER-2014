using UnityEngine;
using System.Collections;

public class MenuEffect4 : MonoBehaviour {

	void OnMouseOver(){
		
		animation.Play("credits");
		
	}
	
	void OnMouseExit(){
		
		animation.Stop("credits");
		
		//transform.position.Set(-508.1646f,79.00017f,489.0824f);
		
	}
	
	void OnMouseDown(){

		renderer.enabled = false;
		GameObject.Find("Nouvelle partie").renderer.enabled = false;
		GameObject.Find("Quitter").renderer.enabled = false;
		GameObject.Find("Aide").renderer.enabled = false;
		GameObject.Find("Charger une partie").renderer.enabled = false;

		//spacenavigator
		GameObject.Find("Citerne001").renderer.enabled = false;
		GameObject.Find("Citerne002").renderer.enabled = false;
		GameObject.Find("Citerne003").renderer.enabled = false;
		GameObject.Find("Sph_re001").renderer.enabled = false;
		GameObject.Find("Sph_re002").renderer.enabled = false;

		//clavier
		GameObject.Find("default").renderer.enabled = false;
		GameObject.Find("default001").renderer.enabled = false;

		//kinect
		GameObject.Find("Bo_te001").renderer.enabled = false;
		GameObject.Find("Cylindre001").renderer.enabled = false;
		GameObject.Find("Cylindre004").renderer.enabled = false;

		//oculus
		GameObject.Find("rift").renderer.enabled = false;
		GameObject.Find("straps").renderer.enabled = false;

		//credit animation
		GameObject.Find("Liste").animation.Play("liste");


	}

	void Update(){

		if (Input.GetKeyUp(KeyCode.Escape)){
			
			renderer.enabled = true;
			GameObject.Find("Nouvelle partie").renderer.enabled = true;
			GameObject.Find("Quitter").renderer.enabled = true;
			GameObject.Find("Aide").renderer.enabled = true;
			GameObject.Find("Charger une partie").renderer.enabled = true;
			//spacenavigator
			GameObject.Find("Citerne001").renderer.enabled = true;
			GameObject.Find("Citerne002").renderer.enabled = true;
			GameObject.Find("Citerne003").renderer.enabled = true;
			GameObject.Find("Sph_re001").renderer.enabled = true;
			GameObject.Find("Sph_re002").renderer.enabled = true;
			
			//credit animation
			Application.LoadLevel("Menu");
		}

	}
}
