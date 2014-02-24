using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	// Use this for initialization
	public int i =0;
	public Transform botA;
	public Transform botB;
	public float vie =500f;
	public Transform explosionBase;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		i++;

		if((i % 250== 0) &&(numberBot() < 30))
		{
			createBot();
			//Debug.Log (this.name+" : "+numberBot());
		}

		if(this.vie <= 0) 
		{

			Instantiate(explosionBase,this.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}



	}

	void createBot()
	{
		float RanD = Random.Range(-10,10);
		if(RanD > 0 ) RanD =35;
		else RanD =-35;

		Vector3 pos = new Vector3 (this.transform.position.x+RanD,this.transform.position.y,this.transform.position.z);
		if(this.name == "baseA")
			Instantiate(botA,pos, this.transform.rotation);
		if(this.name == "baseB")
			Instantiate(botB,pos, this.transform.rotation);
	}

	int numberBot()
	{
		
		GameObject[] Bot;

		if( this.tag == "baseA") Bot = GameObject.FindGameObjectsWithTag("botA");
		else if( this.tag == "baseB") Bot = GameObject.FindGameObjectsWithTag("botB");
		else Bot = GameObject.FindGameObjectsWithTag("");

		return Bot.Length;
	}

	void OnTriggerEnter(Collider other) {
		
		
		if(other.name == "rocket(Clone)")
		{
			Debug.Log(other.name);
			//
			this.vie=this.vie - 0.2f;
		}

		if(other.name == "rocketJoueur(Clone)")
		{
			//Debug.Log(other.name);
			//
			this.vie=this.vie - 0.2f;
		}
	}


}
