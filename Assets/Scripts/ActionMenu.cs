using UnityEngine;
using System.Collections;

public class ActionMenu : MonoBehaviour {
	
	public GUITexture image;
	public GUITexture Logo;
	public GUIText reprendre; 
	public GUIText quitter;
	public GUIText recommencer;
	public bool pause=false;
	//public GameObject obj; 
	
	
	// Use this for initialization
	void Start () {
		//obj = GameObject.Find("Vaisseau");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() 
	{
		
		
		if( this.name == "quitter") 
		{
			enDpauseBots();
			Time.timeScale = 1.0f;
			Application.LoadLevel("Menu");
		}
		
		if( this.name == "reprendre") 
		{
			pause = false;
			enDpauseBots() ;
			Time.timeScale = 1.0f;
			image.enabled = false;
			Logo.enabled = false;
			reprendre.enabled = false; 
			quitter.enabled = false;
			//obj.GetComponent<ClavierControle>().enabled = true;
		}
		
		if( this.name == "recommencer") 
		{
			pause = false;
			enDpauseBots();
			Time.timeScale = 1.0f;
			Application.LoadLevel("Jeu");
		}


		if( this.name == "commencer") 
		{
			GameObject theworld = GameObject.Find("World");
			if(theworld) 
				theworld.GetComponent< World >().begin = false;
		}
		//recommencer / dans world
	}
	
	void pauseBots() 
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		GameObject baseB = GameObject.FindWithTag("baseB");
		GameObject[] ennemi1 = GameObject.FindGameObjectsWithTag("botB");
		GameObject[] ennemi2 = GameObject.FindGameObjectsWithTag("botA");
		
		baseA.GetComponent<Base>().enabled = false;
		baseB.GetComponent<Base>().enabled = false;
		
		foreach (GameObject go in ennemi1) {
			go.GetComponent<Ia_bot>().enabled = false;
		}
		
		foreach (GameObject go in ennemi2) {
			go.GetComponent<Ia_bot>().enabled = false;
		}
	}
	
	void enDpauseBots() 
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		GameObject baseB = GameObject.FindWithTag("baseB");
		GameObject[] ennemi1 = GameObject.FindGameObjectsWithTag("botB");
		GameObject[] ennemi2 = GameObject.FindGameObjectsWithTag("botA");
		
		baseA.GetComponent<Base>().enabled = true;
		baseB.GetComponent<Base>().enabled = true;
		
		foreach (GameObject go in ennemi1) {
			go.GetComponent<Ia_bot>().enabled = true;
		}
		
		foreach (GameObject go in ennemi2) {
			go.GetComponent<Ia_bot>().enabled = true;
		}
	}
}
