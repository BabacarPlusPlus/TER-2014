using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	public GUITexture image;
	public GUITexture Logo;
	public GUIText reprendre; 
	public GUIText quitter;
	public bool pause=false;
	public GameObject obj; 

	// Use this for initialization
	void Start () {
		image.enabled = false;
		Logo.enabled = false;
		reprendre.enabled = false; 
		quitter.enabled = false;
		obj = GameObject.Find("Vaisseau");
	}
	
	// Update is called once per frame
	void Update () {
	

		if(Input.GetKeyUp(KeyCode.Escape)) 
		{
			if(pause==true){
				pause = false;
			}
			else {
				pause = true;
			} 

			if(pause)
			{
				obj.GetComponent<ClavierControle>().enabled = false;
				Time.timeScale = 0.0f;
				image.enabled = true;
				Logo.enabled = true;
				reprendre.enabled = true; 
				quitter.enabled = true;

			}else{
				Time.timeScale = 1.0f;
				image.enabled = false;
				Logo.enabled = false;
				reprendre.enabled = false; 
				quitter.enabled = false;
				obj.GetComponent<ClavierControle>().enabled = true;

			}
		}
	}

	void OnMouseDown() 
	{
		if(pause)
		{
		Debug.Log("ok");
		if( this.name == "quitter") 
		{
			Debug.Log(this.name);
			Application.LoadLevel("Menu");
		}

		if( this.name == "reprendre") 
		{
			Debug.Log("merde");
			pause = false;
			Time.timeScale = 1.0f;
			image.enabled = false;
			Logo.enabled = false;
			reprendre.enabled = false; 
			quitter.enabled = false;
			obj.GetComponent<ClavierControle>().enabled = true;
		}
		}
	}

	void onMouseDown() {        
		Debug.Log ("On Mouse Down Event!!!!!!!!!");
	}

}
