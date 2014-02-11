using UnityEngine;
using System.Collections;

public class Clavier : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion qt = new Quaternion(0,0,0,0);

	//	transform.rotation.Set(0,0.5f,0,0);

		qt = transform.rotation;
	
		qt.y += 5;

		transform.rotation = qt;

	}
}
