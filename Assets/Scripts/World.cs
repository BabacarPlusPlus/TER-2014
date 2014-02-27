using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	// Use this for initialization
	/*public GUIText GameOverText ;
	public GUIText Victoire ;*/
	public GUIText DistanceText ;

	public GUITexture image;
	public GUITexture Logo;
	public GUIText gameover; 
	public GUIText quitter;
	public GUIText win;
	public GUIText limites;
	public GUIText recommencer;
	public bool pause=false;


	public GUIText baseAvie;
	public GUIText baseBvie;
	public GUIText botAnb;
	public GUIText botBnb;

	//menu instruction
	public GUITexture imageInstruction;
	public GUITexture InstructionLogo;
	public GUIText instruction;
	public GUIText commencer; 
	public bool begin;
	public bool choixDispositif;

	public GameObject camera;
	public GameObject vaisseau;
	public GameObject ovr;

	void Awake(){


		if(ActiveDispositif.kinect){
			camera.GetComponent<KinectManager>().enabled = true;
			vaisseau.GetComponent<MouvementKinect>().enabled = true;
		}

		if(ActiveDispositif.manette){
			vaisseau.GetComponent<ManetteXbox360>().enabled = true;
		}

		if(ActiveDispositif.navigator || ActiveDispositif.clavier){
			vaisseau.GetComponent<ClavierControle>().enabled = true;
		}

		if(ActiveDispositif.occulus){
			ovr.SetActive(true);
			camera.GetComponent<Camera>().enabled = false;
		}
		else{
			Debug.Log("Pas Occulus");
		}
	}

	void Start () {
		gameover.enabled = false;
		quitter.enabled = false;
		win.enabled = false;
		limites.enabled = false;
		recommencer.enabled = false;

		baseAvie.text = "100 %";
		baseBvie.text = "100 %";

		//le menu instruction
		begin=true;
		choixDispositif=false;
		pauseBots();



	}
	
	// Update is called once per frame
	void Update () {

		//activation script et gameObject dispositif

	

		if(begin && !ActiveDispositif.occulus)
			printInstruction();
		else 
			endInstruction();

		/*if( choixDispositif )
			funcchoixDispositif();

		if( !choixDispositif && !begin )
			funcenDchoixDispositif();


		 */

		setBaseAvie();
		setBaseBvie();
		setBotAandBnb();

		if(enDOfbaseAllie())
			printGameOver();
		
		if(enDOfbaseEnnemie())
			printVictory();

		if(!getVaisseau())
			printGameOver();

		if((Distance () > 1000 ) && (Distance () < 1300) )
		{
			DistanceText.enabled = true	;
		}

		if(Distance () < 1000 ) 
		{
			DistanceText.enabled = false	;
		}

		if(Distance () > 1300 ) {
			Time.timeScale = 0.0f;
			printGameOver();
			limites.enabled = true;
			//Application.LoadLevel("Jeu");

		}


	}

	float Distance () 
	{
		GameObject vaisseau = GameObject.Find("Vaisseau");
		GameObject centre = GameObject.Find("World");
		float distance=0f;
		if( vaisseau )
			distance = Vector3.Distance(vaisseau.transform.position, centre.transform.position);
		return distance;
	}

	bool enDOfbaseAllie()
	{
		GameObject baseB = GameObject.FindWithTag("baseB");
		if((baseB)&&(baseB.GetComponent< Base >( ).vie <= 0))
			return true;
		else return false;
	}

	bool enDOfbaseEnnemie()
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		if((baseA)&&(baseA.GetComponent< Base >( ).vie <= 0))
			return true;
		else return false;
	}

	void printGameOver(){

		//yield return new WaitForSeconds(2.0f);
		//Time.timeScale = 0.0f;
		gameover.enabled = true;
		quitter.enabled = true;
		image.enabled = true;
		Logo.enabled = true;
		recommencer.enabled = true;
	}

	void printVictory(){
		//yield return new WaitForSeconds(2.0f);
		Time.timeScale = 0.0f;
		pauseBots() ;
		win.enabled = true;
		quitter.enabled = true;
		image.enabled = true;
		Logo.enabled = true;
		recommencer.enabled = true;
	}

	bool getVaisseau(){
		GameObject vaisseau = GameObject.Find("Vaisseau");
		if(vaisseau)return true;
		else return false;
	}

	void setBaseAvie()
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		int vie = (int)(baseA.GetComponent< Base >( ).vie/5);
		baseAvie.text = vie+" %";
	}

	void setBaseBvie()
	{
		GameObject baseB = GameObject.FindWithTag("baseA");
		int vie = (int)(baseB.GetComponent< Base >( ).vie/5);
		baseAvie.text = vie+" %";
	}

	void setBotAandBnb()
	{
		GameObject[] botA,botB;
		botA = GameObject.FindGameObjectsWithTag("botA");
		botB = GameObject.FindGameObjectsWithTag("botB");
		botAnb.text="x "+botA.Length;
		botBnb.text="x "+botB.Length;	
	}

	void pauseBots() 
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		GameObject baseB = GameObject.FindWithTag("baseB");
		GameObject[] ennemi1 = GameObject.FindGameObjectsWithTag("botB");
		GameObject[] ennemi2 = GameObject.FindGameObjectsWithTag("botA");
		
		baseA.GetComponent<Base>().enabled = false;
		baseB.GetComponent<Base>().enabled = false;
		
		foreach (GameObject go in ennemi1) {
			go.GetComponent<Ia_bot>().enabled = false;
		}
		
		foreach (GameObject go in ennemi2) {
			go.GetComponent<Ia_bot>().enabled = false;
		}
	}
	
	void enDpauseBots() 
	{
		GameObject baseA = GameObject.FindWithTag("baseA");
		GameObject baseB = GameObject.FindWithTag("baseB");
		GameObject[] ennemi1 = GameObject.FindGameObjectsWithTag("botB");
		GameObject[] ennemi2 = GameObject.FindGameObjectsWithTag("botA");
		
		baseA.GetComponent<Base>().enabled = true;
		baseB.GetComponent<Base>().enabled = true;
		
		foreach (GameObject go in ennemi1) {
			go.GetComponent<Ia_bot>().enabled = true;
		}
		
		foreach (GameObject go in ennemi2) {
			go.GetComponent<Ia_bot>().enabled = true;
		}
	}

	void printInstruction()
	{
		Time.timeScale = 0.0f;
		pauseBots() ;
		imageInstruction.enabled=true; 
		InstructionLogo.enabled=true; 
		commencer.enabled=true; 
		instruction.enabled = true;
	}

	void endInstruction()
	{

		imageInstruction.enabled=false; 
		InstructionLogo.enabled=false; 
		commencer.enabled=false;
		instruction.enabled = false;
		enDpauseBots();
		Time.timeScale = 1.0f;
		choixDispositif=true;

	}

	void funcchoixDispositif()
	{
		commencer.text="Choisissez un dispositif:";
		instruction.text="";
		//afficher les 3 images

	}

	void funcenDchoixDispositif()
	{
		commencer.text="Commencer";
		instruction.text="";
		choixDispositif=false;
		//enlever les 3 images
		//afficher texte tuto
	}
}
