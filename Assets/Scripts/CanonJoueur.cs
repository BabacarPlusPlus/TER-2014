using UnityEngine;
using System.Collections;

public class CanonJoueur : MonoBehaviour {
	public Transform rocket;
	// Use this for initialization
	public bool shoot = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(shoot)
			createMissile();
	}
	
	void createMissile(){
		//Rigidbody clone;
		//clone = Instantiate(rocket,this.transform.position, this.transform.rotation) as Rigidbody;
		//clone.velocity = transform.TransformDirection(Vector3.forward * 10);
		//tirer.Rotate(0, 0, 180);
		Transform clone = Instantiate(rocket,this.transform.position, this.transform.rotation) as Transform;
		clone.Rotate(90, 0, 0);
		shoot = false;
	}
}
