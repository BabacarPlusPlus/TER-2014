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
	private int i;


	public GameObject[] guiTextureVie;
	public GameObject vie0;
	public GUIText affichageVie;

	void Awake () {
		i = 1;
		j = 0;
		WAIT = false;
		vie = Vaisseau.vie;
		start = Time.time;

	}
	
	// Update is called once per frame
	void Update () {


		if(vie <= 0){
			guiTextureVie[6].SetActive(false);
			vie0.SetActive(true);
			Debug.Log("Perdu");
			this.transform.FindChild("Main Camera").transform.parent = null;
			Destroy(this.gameObject);
			Instantiate(explosion,this.transform.position, this.transform.rotation);
			WAIT = true;
			if(WAIT){
				k = j;
				WAIT = false;//*/
			}

			//Application.LoadLevel("Jeu");
		
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("rocket")){

			guiTextureVie[i % guiTextureVie.Length].SetActive(true);
			guiTextureVie[(i-1) % guiTextureVie.Length].SetActive(false);


			i++;
			if( (i % 7) == 0){
				vie--;
			}
			Debug.Log("*****************  i : " + i +"  *****************");

		}
	}

	void OnGUI()
	{
		affichageVie.text = "Vie : " + vie.ToString();
	}

	IEnumerator wait(){
		Debug.Log("attend");
		yield return new WaitForSeconds(1f);
		Debug.Log("fin");
		fin = true;
	}

}
