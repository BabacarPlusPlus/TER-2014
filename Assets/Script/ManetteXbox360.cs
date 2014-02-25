using UnityEngine;
using System.Collections;

public class ManetteXbox360 : MonoBehaviour {

	private float speed;		  //vitesse du vaisseau
	private bool fast;			  //vrai quand le vaisseau est en mode accélérer, faux sinon
	private GameObject canonDroite; //l'endroit d'ou le missile droite part
	private GameObject canonGauche; //l'endroit d'ou le missile gauche part
	private int j;
	private float previousTtigger;
	
	//public AudioClip Accélération;
	//public AudioClip Ralentissement;
	AudioSource Accélération;
	AudioSource Ralentissement;
	
	
	
	void Start() {
		AudioSource[] audios = GetComponents<AudioSource>();
		canonDroite = GameObject.Find("Vaisseau/canonDroite");
		canonGauche = GameObject.Find("Vaisseau/canonGauche");
		//Accélération = audios[0];
		//Ralentissement = audios[1];
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
		if(Input.GetAxis("L_XAxis_1") > 0){
			this.gameObject.transform.Rotate(Vector3.up * 1.5f, Space.World);
		}

		//rotation gauche
		if(Input.GetAxis("L_XAxis_1") < 0){
			this.gameObject.transform.Rotate(Vector3.down * 1.5f, Space.World);
		}

		Debug.Log(Input.GetAxis("R_YAxis_1"));

		if(Input.GetAxis("R_YAxis_1") < 0){
			if( !fast ){
				Debug.Log("accélération");
				fast = true;
				speed *= 5;
				//Accélération.Play();
			}
		}

		if(Input.GetAxis("R_YAxis_1") > 0){
			if( fast ){
				Debug.Log("ralentissement");
				fast = false;
				speed /= 5;
				//Ralentissement.Play();
			}
		}

		Debug.Log(Input.GetAxis("Triggers_1"));

		if( (previousTtigger = Input.GetAxis("Triggers_1")) < 0){
			if((j % 10) == 0){
				//Debug.Log("tir droite");
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
			}
		}

		if((previousTtigger = Input.GetAxis("Triggers_1")) > 0){
			if((j % 10) == 0){
				//Debug.Log("tir gauche");
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}

		/*if(previousTtigger == Input.GetAxis("Triggers_1")){
		 	if((j % 10) == 0){
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}//*/
	}
}


