using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	private float duree_de_vie = 2.0f;
	private float start_time;
	// Use this for initialization
	void Start () {
		start_time =  Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if( (Time.time - start_time) > duree_de_vie )
			Destroy(gameObject);
	}
}
