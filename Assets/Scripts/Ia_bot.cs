using UnityEngine;
using System.Collections;

public class Ia_bot : MonoBehaviour {

	public float speed = 0.3f;
	public string direction;
	public float temps = 0f;
	public float duree_manoeuvre = 0f;
	public float start_temps_manoeuvre=0f;
	public bool changement_manoeuvre = true;
	public float portee_tir = 10f;
	public float degree_rotation = 2.5f;
	public float vie = 2f;
	public string equipe ;
	public GameObject cible ;
	public float nextFire;
	// Use this for initialization

	//Movement Actions
	public Transform rocket;
	public Transform explosion;
	public bool ManoeuvreGauche  = false;
	public bool ManoeuvreDroite  = false;
	public bool ManoeuvreCentre  = false;
	public bool pasDeMur = true;

	Vector3 startPosition;

	public int i = 0;

	void Start () {
		startPosition = this.transform.position;
		if((this.name=="botA")|| (this.name=="botA(Clone)"))
			renderer.material.color = Color.red;
		else renderer.material.color = Color.blue;

		transform.localEulerAngles = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	if(this.tag == "botA")
			if(detectionJoueur())
				attaqueEnnemis();;
		
	if(!detectionEnnemie() && !detectionBase())
	{
		
		
			if((!ManoeuvreGauche)&&(!ManoeuvreDroite)&(!ManoeuvreCentre))
			{
				deplacement_alea();
			//Debug.Log("alea");
			}

		EvitementObstacles();
		
	}

	else {	

		//améliorer
		//detectionEnnemi
				if((cible.tag == "baseA") || (cible.tag == "baseB") )
					attaqueBase();
				else
					attaqueEnnemis();


	}


		if( vie <= 0f ){
			Destroy(gameObject);
			Instantiate(explosion,this.transform.position, this.transform.rotation);

		}

		i++;
		//manoeuvre ();*/
	}


	void deplacement_alea()
	{
		float Angle_rotation = Random.Range(-4.0F, 4.0F);		
		this.transform.Translate(0f,0f,speed);
		this.transform.Rotate(0f,Angle_rotation,0f);
	}

	void manoeuvre ()
	{



		//si on a aucune manoeuvre, on en commence une
		if((duree_manoeuvre == 0f)&& (changement_manoeuvre)){

			start_temps_manoeuvre=Time.time;
			//choix du coté de la manoeuvre
			float cote = Random.Range(-1.0F, 1.0F);
			if( cote > 0 )direction = "gauche";
			else direction = "droite";

			//on vient de changer de manoeuvre
			changement_manoeuvre = false;
		}


		//si la manoeuvre est finie on l'initilalise
		if (duree_manoeuvre > 5f)
		{
			duree_manoeuvre=0f;
			changement_manoeuvre = true;
		}

		//initialise le debut de la manoeuvre
		duree_manoeuvre=getTime();

		//on incremente la durée si on vient juste de changement de manoeuvre
		if(changement_manoeuvre)
			duree_manoeuvre = 0.001f;


	

		//Debug.Log (duree_manoeuvre);

		if(changement_manoeuvre)
			Debug.Log ("changement:"+Time.time);
		//else Debug.Log ("merde :"+Time.time);
	}

	float getTime()
	{
		//Debug.Log ("entré dans getime()"+Time.time);

		return Time.time - start_temps_manoeuvre;

	}


	GameObject detectionEnnemie()// objet doit elre player
	{
		float distance = 30.0f;
		float min = 500f ;
		GameObject[] ennemies;

		if( this.tag == "botA") ennemies = GameObject.FindGameObjectsWithTag("botB");
		else if( this.tag == "botB")  ennemies = GameObject.FindGameObjectsWithTag("botA");
		else ennemies = GameObject.FindGameObjectsWithTag("");


		foreach (GameObject go in ennemies) {

			float x = this.transform.position.x - go.transform.position.x;
			float z = this.transform.position.z - go.transform.position.z;

			if((( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) <  distance ) && (( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) != 0) )
			{
				if( distance < min ){
					min = Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z));
					cible = go;
				}
			}
		}

			//this.transform.LookAt(cible);
		return cible;
	}


	GameObject detectionBase()// objet doit elre player
	{
		float distance = 100.0f;
		float min = 500f ;
		GameObject[] Base;

		if( this.tag == "botA") Base = GameObject.FindGameObjectsWithTag("baseB");
		else if( this.tag == "botB")  Base = GameObject.FindGameObjectsWithTag("baseA");
		else Base = GameObject.FindGameObjectsWithTag("");



		foreach (GameObject go in Base) {
			float x = this.transform.position.x - go.transform.position.x;
			float z = this.transform.position.z - go.transform.position.z;

			if((( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) <  distance ) && (( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) != 0) )
			{
				if( distance < min ){
					min = Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z));
					cible = go;
				}
			}
		}

		return cible;
	}


	GameObject detectionJoueur()// objet doit elre player
	{
		float distance = 30.0f;
		float min = 500f ;
		GameObject ennemies=null;
		
		if( this.tag == "botA") ennemies = GameObject.Find("Vaisseau");

		if(ennemies)
		{



			float x = this.transform.position.x - ennemies.transform.position.x;
			float z = this.transform.position.z - ennemies.transform.position.z;



				
				if((( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) <  distance ) && (( Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z))) != 0) )
				{
					if( distance < min ){
						min = Mathf.Sqrt( Mathf.Abs (x) * Mathf.Abs (x) + Mathf.Abs (z) * Mathf.Abs (z));
					cible = ennemies;
					}
				}
		}
		//this.transform.LookAt(cible);
		return cible;
	}

	void attaqueEnnemis()
	{
		float distance = 70.0f;
		if((cible != null)&&(Vector3.Distance(cible.transform.position, this.transform.position)< distance))
		{
			if((cible != null)&&(Vector3.Distance(cible.transform.position, this.transform.position) > 25f))
			{
				this.transform.LookAt(cible.transform.position);
				
				if (i % 10 == 0)
				{
					
					//Vector3 pos= new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
					//Instantiate(rocket,pos, this.transform.rotation);
					Transform viseur = transform.FindChild("viseur");
					viseur.GetComponent< Canon>( ).shoot=true;
					
				}
				//Instantiate(rocket,this.transform.position, this.transform.rotation);
				//Debug.Log("tir: "+cible.name);
			}
		}

	}

	void attaqueBase()
	{
		float distance = 150.0f;
		if((cible != null)&&(Vector3.Distance(cible.transform.position, this.transform.position)< distance))
		{
			if((cible != null)&&(Vector3.Distance(cible.transform.position, this.transform.position) > 50f))
			{
				this.transform.LookAt(cible.transform.position);
				
				if (i % 10 == 0)
				{
					
					//Vector3 pos= new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z);
					//Instantiate(rocket,pos, this.transform.rotation);
					Transform viseur = transform.FindChild("viseur");
					viseur.GetComponent< Canon>( ).shoot=true;
					
				}
				//Instantiate(rocket,this.transform.position, this.transform.rotation);
				//Debug.Log("tir: "+cible.name);
			}
		}
		
	}

	void EvitementObstacles()
	{
		if((ManoeuvreGauche)&&(!ManoeuvreCentre)&&(!ManoeuvreDroite))
		{
			this.transform.Translate(0f,0f,speed/1.5f);
			this.transform.Rotate(0f,-degree_rotation,0f);
			//Debug.Log("manip gauche");
			
		}
		
		if((ManoeuvreGauche)&&(ManoeuvreCentre)&&(!ManoeuvreDroite))
		{
			this.transform.Translate(0f,0f,speed/1.5f);
			this.transform.Rotate(0f,-degree_rotation,0f);
			//Debug.Log("manip gauche");
		}
		
		if((!ManoeuvreGauche)&&(!ManoeuvreCentre)&&(ManoeuvreDroite))
		{
			this.transform.Translate(0f,0f,speed/1.5f);
			this.transform.Rotate(0f,degree_rotation,0f);
			//Debug.Log("manip droite");
		}
		
		if((!ManoeuvreGauche)&&(ManoeuvreCentre)&&(ManoeuvreDroite))
		{
			this.transform.Translate(0f,0f,speed/1.5f);
			this.transform.Rotate(0f,degree_rotation,0f);
			//Debug.Log("manip droite");
			
		}
		
		if((ManoeuvreGauche)&&(!ManoeuvreCentre)&&(ManoeuvreDroite))
		{
			
			float Alea = Random.Range(-4.0F, 4.0F);
			if( Alea >= 0)
			{
				this.transform.Translate(0f,0f,speed/1.5f);
				this.transform.Rotate(0f,degree_rotation,0f);
			}
			else{
				this.transform.Translate(0f,0f,speed/1.5f);
				this.transform.Rotate(0f,-degree_rotation,0f);
			}
			//Debug.Log("manip aléa");
		}
		
		if((!ManoeuvreGauche)&&(ManoeuvreCentre)&&(!ManoeuvreDroite))
		{
			float Alea = Random.Range(-4.0F, 4.0F);
			if( Alea >= 0)
			{
				this.transform.Translate(0f,0f,speed/1.5f);
				this.transform.Rotate(0f,degree_rotation,0f);
			}
			else{
				this.transform.Translate(0f,0f,speed/1.5f);
				this.transform.Rotate(0f,-degree_rotation,0f);
			}
			//Debug.Log("manip aléa");
		}
		//
		if((ManoeuvreGauche)&&(ManoeuvreCentre)&&(ManoeuvreDroite))
		{
			this.transform.Translate(0f,0f,speed/1.5f);
			this.transform.Rotate(0f,180,0f);
			//Debug.Log("manip demi-tour");
		}
	}

	void OnTriggerEnter(Collider other) {


		if(other.name == "rocket(Clone)")
		{
			//Debug.Log(other.name);
			//
			this.vie=this.vie - 0.2f;
		}

		if(other.name == "rocketjoueur(Clone)")
		{
			//Debug.Log(other.name);
			//
			this.vie=this.vie - 4f;
		}
	}
}




