using UnityEngine;
using System.Collections;

public class Canon : MonoBehaviour {
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
		Instantiate(rocket,this.transform.position, this.transform.rotation);
		shoot = false;
	}
}
