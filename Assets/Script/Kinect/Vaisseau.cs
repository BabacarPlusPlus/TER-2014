using UnityEngine;
using System.Collections;

public class Vaisseau : MonoBehaviour{
	
	private int speed;// la vitesse du vaisseau 
	private bool fast;//vrai quand le vaisseau est mode accélérer faux sinon

	void Awake(){
		speed = 5;
	}

	//permet d'avancer le vaisseau à la vitesse speed;
	//fonction appeler à chaque frame
	public void avancer(){
		this.transform.Translate(Vector3.forward * speed * Time.deltaTime);	
	}

	//rotation gauche
	public void tournerAGauche(){
				
	}

	//rotation droite
	public void tournerADroite(){
		
	}

	//acceleration
	public void accelerer(){
		if( !fast ){
			speed *= 3;
		}
	}

	//ralentissement : retour à la vitesse normale si elle est accelerer
	public void ralentir(){
		if( fast ){
			speed /= 3;
		}
	}
	
	//tir avec le canon gauche
	public void tirGauche(){

	}

	//tir avec le canon droite
	public void tirDroite(){
		
	}

}
