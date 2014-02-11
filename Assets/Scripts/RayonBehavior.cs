using UnityEngine;
using System.Collections;

public class RayonBehavior : MonoBehaviour {

	private float duree_de_vie = 1.0f;
	private float start_time;
	private float speed = 10.0f;
	//Vector3 endPosition = new Vector3(0.0f,0.0f,0.0f);
	float t =0.0f;
	GameObject Objet_pere;


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


		Objet_pere = transform.parent.gameObject;

		Debug.Log(Objet_pere.name);
		/*if(other.tag != "detectionCollision")
		{
			
			if((other.tag == "botA") || (other.name == "botB"))
			{
				//Debug.Log(other.name);
				other.GetComponent< Ia_bot>( ).pasDeMur=true;;
			}

			if((other.tag != "botA") && (other.name != "botB"))
			{
				//Debug.Log(other.name);
				other.GetComponent< Ia_bot>( ).pasDeMur=false;;
			}

			Destroy(gameObject);
		}*/
	}
}
