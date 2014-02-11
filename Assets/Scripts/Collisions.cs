/*
 * Script liée au 3 différents BoxCollider qui se place deja l'objet
 * Ce script se declanche dés qu'un objet entre en collisio du box, donc se rapproche du bot.
 * Il sert a dire d'ou vient la collision ( devant , gauche , droite)
 * Il envoie a son objet pere ( le GameObject du bot )l'endroit d'ou vient la collision.
 * 
 * */

using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

	// Use this for initialization 
	public bool avantCentre=false;
	public bool avantDroite=false;
	public bool avantGauche=false;
	
	GameObject Objet_pere;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {

		Objet_pere = transform.parent.gameObject;

		if(this.name=="colisionAvantCentre")
		{
			avantCentre=true;
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreCentre=true;
		}

		if(this.name=="colisionAvantDroite")
		{
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreGauche=true;
			//avantDroite=true;
			//Debug.Log("colisionAvantDroite");
		}
		if(this.name=="colisionAvantGauche")
		{
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreDroite=true;
			//avantGauche=true;
			//Debug.Log("colisionAvantGauche");
		}
	}

	void OnTriggerExit(Collider other) {

		Objet_pere = transform.parent.gameObject;

		if(this.name=="colisionAvantCentre")
		{
			avantCentre=false;
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreCentre=false;
			//Debug.Log("Out Avant centre");
		}
		
		if(this.name=="colisionAvantDroite")
		{
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreGauche=false;
			avantDroite=false;
			//Debug.Log("Out Avant droite");
		}
		if(this.name=="colisionAvantGauche")
		{
			Objet_pere.GetComponent< Ia_bot>( ).ManoeuvreDroite=false;
			avantGauche=false;
			//Debug.Log("Out Avant gauche");
		}

	}



	/*public bool getAvantCentre()
	{
		return avantCentre;
	}

	public bool getAvantDroite()
	{
		return avantDroite;
	}

	public bool getAvantGauche()
	{
		return avantGauche;
	}*/
}
