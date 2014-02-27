using UnityEngine;
using System.Collections;

public class ChoixDispositif : MonoBehaviour {

	public GameObject kinect;
	public GameObject manette;
	public GameObject occulus;
	public GameObject navigator;
	public GameObject clavier;
	public GameObject[] texture;

	void Awake(){

	}

	void OnMouseDown(){
		if( this.name == "Kinect"){

			kinect.SetActive(true);
			ActiveDispositif.kinect = true;
			disableTexture();

		}

 		if( this.name == "Manette"){
			manette.SetActive(true);
			ActiveDispositif.manette = true;
			disableTexture();
			
		}

		if( this.name == "Occulus"){
			ActiveDispositif.occulus = true;
			Application.LoadLevel("Jeu");
			
		}

		if( this.name == "pasOcculus"){
			ActiveDispositif.occulus = false;
			Application.LoadLevel("Jeu");
			
		}

		if( this.name == "SpaceNavigator"){
			navigator.SetActive(true);
			ActiveDispositif.navigator = true;
			disableTexture();
			
		}

		if( this.name == "Clavier"){
			clavier.SetActive(true);
			ActiveDispositif.clavier = true;
			disableTexture();
			
		}



	}

	void disableTexture(){
		foreach(GameObject g in texture){
			g.SetActive(false);
		}
	}
}
