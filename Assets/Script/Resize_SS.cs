using UnityEngine;
using System.Collections;



public class Resize_SS : MonoBehaviour {

	private float speed;		  //vitesse du vaisseau
	private bool fast;			  //vrai quand le vaisseau est en mode accélérer, faux sinon
	private int j;

	public GameObject part_jet_core ;
	public GameObject part_jet_flare ;


	// Use this for initialization
	void Start () {
	
	}


	void Awake() 
	{
		speed = Vaisseau.speedVaisseau;
		fast = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		j++;

		if (Input.GetAxis ("Vertical") > 0.1) {

			if( !fast ){
				Debug.Log("accélération");
				fast = true;
				//transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
				part_jet_core.renderer.enabled = true ;
				part_jet_flare.renderer.enabled = true ;
			}
		}
			

		/*
		if( Input.GetAxis("Vertical") < -0.1){
			transform.localScale.x /= 2;
			transform.localScale.y /= 2;
			transform.localScale.z /= 2;
		}
		*/

	}
}
