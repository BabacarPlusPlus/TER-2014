using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	// Use this for initialization
	public GUIText GameOverText ;
	public GUIText Victoire ;
	public GUIText DistanceText ;

	void Start () {
		GameOverText.enabled = false;
		Victoire.enabled = false;
		DistanceText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enDOfbaseAllie())
			GameOverText.enabled = true;

		if(enDOfbaseEnnemie())
			Victoire.enabled =  true;

		if((Distance () > 1000 ) && (Distance () < 1300) )
		{
			DistanceText.enabled = true	;
		}

		if(Distance () < 1000 ) 
		{
			DistanceText.enabled = false	;
		}

		if(Distance () > 1300 ) 
			Application.LoadLevel("Intro 4");

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
}
