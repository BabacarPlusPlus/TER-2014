using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	//public Transform _rocket;
	//private Vector3 start_position;
	//private Vector3 cible_position;
	//private Transform transform;
	private float duree_de_vie = 4.0f;
	private float start_time;
	private float speed = 100.0f;
	public Transform explosionRocket;


	float t =0.0f;

	void Start () {

		/*GameObject player = GameObject.Find ("player");

		start_position = this.transform.position;
		cible_position = player.transform.position;*/

		start_time =  Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.forward * (speed * Time.deltaTime));
		/*if(t < 1.0f)
		{
			t+= Time.deltaTime * 1.0f;
			//transform.LookAt(cible_position);
			this.transform.position = Vector3.Lerp(start_position, cible_position, t);
			// yield;
		}*/
		//stransform.Translate(0.1f,0f,0f);
		//transform.Translate ( Vector3.forward * (speed * Time.deltaTime));
		//this.transform.position += transform.forward * speed * Time.deltaTime;

		if( (Time.time - start_time) > duree_de_vie )
			Destroy(gameObject);
	}


	void OnTriggerEnter(Collider other) {



		if(other.tag != "detectionCollision")
		{

			if((other.tag == "botA") || (other.name == "botB"))
			{
				Instantiate(explosionRocket,this.transform.position, this.transform.rotation);
			}
			Destroy(gameObject);
		}

		if((other.tag == "baseA") ||(other.tag == "baseB"))
		{
			Instantiate(explosionRocket,this.transform.position, this.transform.rotation);
			Destroy(gameObject);
		}
	}


}
