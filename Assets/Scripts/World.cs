using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	// Use this for initialization
	/*public GUIText GameOverText ;
	public GUIText Victoire ;*/
	public GUIText DistanceText ;

	public GUITexture image;
	public GUITexture Logo;
	public GUIText gameover; 
	public GUIText quitter;
	public GUIText win;
	public GUIText limites;
	public GUIText recommencer;
	public bool pause=false;

	void Start () {
		gameover.enabled = false;
		quitter.enabled = false;
		win.enabled = false;
		limites.enabled = false;
		recommencer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enDOfbaseAllie())
			printGameOver();
		
		if(enDOfbaseEnnemie())
			printVictory();

		if(getVieVaisseau() <=0 )
			printGameOver();

		if((Distance () > 1000 ) && (Distance () < 1300) )
		{
			DistanceText.enabled = true	;
		}

		if(Distance () < 1000 ) 
		{
			DistanceText.enabled = false	;
		}

		if(Distance () > 1300 ) {
			Time.timeScale = 0.0f;
			printGameOver();
			limites.enabled = true;
			//Application.LoadLevel("Jeu");

		}


	}

	float Distance () 
	{
		GameObject vaisseau = GameObject.Find("Vaisseau");
		GameObject centre = GameObject.Find("World");
		float distance=0f;
		if( vaisseau )
			distance = Vector3.Distance(vaisseau.transform.position, centre.transform.position);
		return distance;
	}

	bool enDOfbaseAllie()
	{
		GameObject baseB = GameObject.FindWithTag("baseB");
		if(baseB.GetComponent< Base >( ).vie <= 0)
			return true;
		else return false;
	}

	bool enDOfbaseEnnemie()
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		if(baseA.GetComponent< Base >( ).vie <= 0)
			return true;
		else return false;
	}

	void printGameOver(){
		Time.timeScale = 0.0f;
		gameover.enabled = true;
		quitter.enabled = true;
		image.enabled = true;
		Logo.enabled = true;
		recommencer.enabled = true;
	}

	void printVictory(){
		Time.timeScale = 0.0f;
		win.enabled = true;
		quitter.enabled = true;
		image.enabled = true;
		Logo.enabled = true;
		recommencer.enabled = true;
	}

	int getVieVaisseau(){
		return Vaisseau.vie;
	}
}
