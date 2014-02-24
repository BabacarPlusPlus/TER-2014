using UnityEngine;
using System.Collections;

public class ClavierControle : MonoBehaviour {



	private float speed;		  //vitesse du vaisseau
	private bool fast;			  //vrai quand le vaisseau est en mode accélérer, faux sinon
	public Transform missile;	  //le missile	
	public Transform canonDroite; //l'endroit d'ou le missile droite part
	public Transform canonGauche; //l'endroit d'ou le missile gauche part
	private int j;

	//public AudioClip Accélération;
	//public AudioClip Ralentissement;
	AudioSource Accélération;
	AudioSource Ralentissement;



	void Start() {
		AudioSource[] audios = GetComponents<AudioSource>();
		Accélération = audios[0];
		Ralentissement = audios[1];
	}

	void Awake() 
	{
		j = 0;
		speed = Vaisseau.speedVaisseau;
		fast = false;
	}
	
	// Update is called once per frame
	void Update () {

		j++;
		this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

		//rotation droite
		if( Input.GetAxis("Horizontal") > 0.1){
			Debug.Log("rotation droite");
			this.gameObject.transform.Rotate(Vector3.up * 1.5f, Space.World);
		}//*/

		//rotation gauche
		if(Input.GetAxis("Horizontal") < -0.1){
			Debug.Log("rotation gauche");
			this.gameObject.transform.Rotate(Vector3.down * 1.5f, Space.World);
		}
	
		//accélération
		if( Input.GetAxis("Vertical") > 0.1){
			if( !fast ){
				Debug.Log("accélération");
				fast = true;
				speed *= 5;
				Accélération.Play();
			}
		}
		
		//ralentissement
		if( Input.GetAxis("Vertical") < -0.1){	
			if( fast ){
				Debug.Log("ralentissement");
				fast = false;
				speed /= 3;
				Ralentissement.Play();
			}
		}


		//tir droite

		//Avec le clique
		if(Input.GetButton("Fire2")){
			if((j % 10) == 0){
				Debug.Log("tir droite");
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
			}
		}

		// Avec le clavier
		if(Input.GetKey("d")){
			if((j % 10) == 0){
				Debug.Log("tir droite");
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
			}
		}



		//tir gauche

		//Avec le clique
		if(Input.GetButton("Fire1")){
			if((j % 10) == 0){
				Debug.Log("tir gauche");
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}

		//Avec le clavier
		if(Input.GetKey("g")){
			if((j % 10) == 0){
				Debug.Log("tir gauche");
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}


	}
}
