using UnityEngine;
using System.Collections;

[System.Serializable]

public class DPC2 : MonoBehaviour
{
	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn2;
	public float fireRate;
	
	private float nextFire;

	
	void Update ()
	{

		if (Input.GetButton("Fire2") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
			audio.Play ();
		}
	}

}

