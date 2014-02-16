using UnityEngine;
using System.Collections;

public class ClavierControle : MonoBehaviour {



	private float speed;		  //vitesse du vaisseau
	private bool fast;			  //vrai quand le vaisseau est en mode accélérer, faux sinon
	public Transform missile;	  //le missile	
	public Transform canonDroite; //l'endroit d'ou le missile droite part
	public Transform canonGauche; //l'endroit d'ou le missile gauche part
	private int j;
	
	void Awake() 
	{
		j = 0;
		speed = Vaisseau.speedVaisseau;
		fast = false;
	}
	
	// Update is called once per frame
	void Update () {

		this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

		//rotation droite
		if( Input.GetAxis("Horizontal") > 0.1){
			this.gameObject.transform.Rotate(Vector3.up * 1.5f, Space.World);
		}//*/

		//rotation gauche
		if(Input.GetAxis("Horizontal") < -0.1){
			this.gameObject.transform.Rotate(Vector3.down * 1.5f, Space.World);
		}
	
		//accélération
		if( Input.GetAxis("Vertical") > 0.1){
			if( !fast ){
				fast = true;
				speed *= 3;
			}
		}
		
		//ralentissement
		if( Input.GetAxis("Vertical") < -0.1){	
			if( fast ){
				fast = false;
				speed /= 3;
			}
		}

		//tir gauche
		if(Input.GetKey("g")){
			if((j % 20) == 0){
				Debug.Log("tir droite");
				canonDroite.GetComponent<CanonJoueur>().shoot=true;
			}
		}

		//tir droite
		if(Input.GetKey("d")){
			if((j % 20) == 0){
				Debug.Log("tir gauche");
				canonGauche.GetComponent<CanonJoueur>().shoot=true;
			}
		}


	}
}
