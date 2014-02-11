using UnityEngine;
using System.Collections;

public class Rayon : MonoBehaviour {
	public Transform rayon;
	// Use this for initialization
	public bool shoot = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(shoot)
			createRayon();
	}
	
	void createRayon(){
		Instantiate(rayon,this.transform.position, this.transform.rotation);
		shoot = false;
	}
}
