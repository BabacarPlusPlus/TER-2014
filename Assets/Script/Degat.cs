using UnityEngine;
using System.Collections;

public class Degat : MonoBehaviour {

	private int vie;


	void Awake () {
		vie = Vaisseau.vie;
	}
	
	// Update is called once per frame
	void Update () {
		if(vie <= 0){
			Debug.Log("Perdu");
			Application.LoadLevel("Jeu");	
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("rocket")){
			vie--;	
			Debug.Log(vie);
		}
	}
}
