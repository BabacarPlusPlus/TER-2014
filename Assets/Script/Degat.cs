using UnityEngine;
using System.Collections;

public class Degat : MonoBehaviour {

	private int vie;
	public Transform explosion;
	private bool WAIT;

	void Awake () {
		WAIT = false;
		vie = Vaisseau.vie;
		if(WAIT){
			StartCoroutine(wait());	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(vie <= 0){
			Debug.Log("Perdu");
			this.transform.FindChild("ARC_170_LEE_RAY_polySurface1394").GetComponent<MeshRenderer>().enabled = false;
			Instantiate(explosion,this.transform.position, this.transform.rotation);
			Application.LoadLevel("Jeu");	
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("rocket")){
			vie--;	
			Debug.Log(vie);

		}
	}

	IEnumerator wait(){
		Debug.Log("attend");
		yield return new WaitForSeconds(1);
	}

}
