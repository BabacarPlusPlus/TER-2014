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

			ActiveDispositif.kinect = false;
			ActiveDispositif.manette = false;
			ActiveDispositif.occulus = false;
			ActiveDispositif.navigator = false;
			ActiveDispositif.clavier = false;
			Application.LoadLevel("Menu");

			/*if(pause==true){
				pause = false;
			}
			else {
				pause = true;
			} 

			if(pause)
			{


				Time.timeScale = 0.0f;
				pauseBots() ;
				Debug.Log("time:"+Time.timeScale);
				image.enabled = true;
				Logo.enabled = true;
				reprendre.enabled = true; 
				quitter.enabled = true;


			}else{

				Debug.Log("time:"+Time.timeScale);
				Time.timeScale = 1.0f;
				enDpauseBots() ;
				image.enabled = false;
				Logo.enabled = false;
				reprendre.enabled = false; 
				quitter.enabled = false;



			}*/


		}
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
