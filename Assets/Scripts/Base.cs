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

		Vector3 pos = new Vector3 (this.transform.position.x,this.transform.position.y-15,this.transform.position.z);
		if(this.name == "baseA")
			Instantiate(botA,pos, this.transform.rotation);
		if(this.name == "baseB")
			Instantiate(botB,pos, this.transform.rotation);
	}


}
