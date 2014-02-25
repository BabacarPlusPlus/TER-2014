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

	public GameObject part_jet_core ;
	public GameObject part_jet_flare ;

	public GameObject part_jet_core_2 ;
	public GameObject part_jet_flare_2 ;

	public GameObject part_jet_core_3 ;
	public GameObject part_jet_flare_3 ;


	void Start() {
		AudioSource[] audios = GetComponents<AudioSource>();
		Accélération = audios[0];
		Ralentissement = audios[1];

		part_jet_core.renderer.enabled = false ;
		part_jet_flare.renderer.enabled = false ;

		part_jet_core_2.renderer.enabled = true ;
		part_jet_flare_2.renderer.enabled = true ;

		part_jet_core_3.renderer.enabled = true ;
		part_jet_flare_3.renderer.enabled = true ;
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
				part_jet_core.renderer.enabled = true ;
				part_jet_flare.renderer.enabled = true ;

				part_jet_core_2.renderer.enabled = true ;
				part_jet_flare_2.renderer.enabled = true ;
				
				part_jet_core_3.renderer.enabled = true ;
				part_jet_flare_3.renderer.enabled = true ;
			}
		}
		
		//ralentissement
		if( Input.GetAxis("Vertical") < -0.1){	
			if( fast ){
				Debug.Log("ralentissement");
				fast = false;
				speed /= 5;
				Ralentissement.Play();

				part_jet_core.renderer.enabled = true ;
				part_jet_flare.renderer.enabled = true ;

				part_jet_core_2.renderer.enabled = false ;
				part_jet_flare_2.renderer.enabled = false ;

				part_jet_core_3.renderer.enabled = false ;
				part_jet_flare_3.renderer.enabled = false ;
			}
		}


		//tir droite

		//Avec le clique ou le clavier
		if((Input.GetButton("Fire2")) || (Input.GetKey("d"))){
			if((j % 10) == 0){
				Debug.Log("tir droite");
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
			}
		}



		//tir gauche

		//Avec le clique ou le clavier
		if((Input.GetButton("Fire1")) || (Input.GetKey("g"))){
			if((j % 10) == 0){
				Debug.Log("tir gauche");
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}


	}
}
