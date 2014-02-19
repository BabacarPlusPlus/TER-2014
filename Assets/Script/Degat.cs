using UnityEngine;
using System.Collections;

public class Degat : MonoBehaviour {

	private int vie;
	public Transform explosion;
	private bool WAIT;
	private float start;
	private bool fin;
	private int j;
	private int k;

	void Awake () {
		j = 0;
		WAIT = false;
		vie = Vaisseau.vie;
		start = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		j++;
		if(vie <= 0){
			Debug.Log("Perdu");
			this.transform.FindChild("Main Camera").transform.parent = null;
			Destroy(this.gameObject);
			Instantiate(explosion,this.transform.position, this.transform.rotation);
			WAIT = true;
			if(WAIT){
				k = j;
				WAIT = false;//*/
			}
			if( (j - k) > 30){
				Application.LoadLevel("Jeu");
			}
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
		yield return new WaitForSeconds(1f);
		Debug.Log("fin");
		fin = true;
	}

}
