using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	// Use this for initialization
	public int i =0;
	public Transform botA;
	public Transform botB;
	public float vie =100f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		i++;

		if(i % 250== 0)
			createBot();

	}

	void createBot()
	{
		if(this.name == "baseA")
			Instantiate(botA,this.transform.position, this.transform.rotation);
		if(this.name == "baseB")
			Instantiate(botB,this.transform.position, this.transform.rotation);
	}


}
