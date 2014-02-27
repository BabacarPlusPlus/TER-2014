using UnityEngine;
using System.Collections;

public class OK : MonoBehaviour {

	public GameObject goDisable;
	public GameObject[] occulus;

	void OnMouseDown(){
		if(this.name == "OK"){
			Debug.Log("OK");
			foreach(GameObject g in occulus){
				g.SetActive(true);
			}
			this.transform.parent.gameObject.SetActive(false);
		}

	}

}
