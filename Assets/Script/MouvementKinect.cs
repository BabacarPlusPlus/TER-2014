using UnityEngine;
using System.Collections;

public class MouvementKinect : MonoBehaviour {
	

	private KinectManager manager;

	
	private Material[] objectMaterials;
	private GameObject selectedObject;
	
	private GameObject infoGUI;

	private float speed;		  //vitesse du vaisseau
	private bool fast;			  //vrai quand le vaisseau est en mode accélérer, faux sinon
	public Transform missile;	  //le missile	
	public Transform canonDroite; //l'endroit d'ou le missile droite part
	public Transform canonGauche; //l'endroit d'ou le missile gauche part
	private int j;

	void Awake() 
	{
		j = 0;
		speed = Vaisseau.speedVaisseau;
		fast = false;

		// get needed objects´ references
		manager = GameObject.Find("Vaisseau/Main Camera").GetComponent<KinectManager>();

		//infoGUI = GameObject.Find("HandGuiText");
		

	}



	void Update() 
	{
		//Vaisseau.avancer();

		this.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

		j++;
		
		if(manager != null && KinectManager.IsKinectInitialized() && manager.GetPlayer1ID() > 0)
		{
			uint userId = manager.GetPlayer1ID();
			Vector3 screenNormalPos = Vector3.zero;

	
			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TournerADroite	) >= 0.1f)
			{

				this.gameObject.transform.Rotate(Vector3.up * 1.5f, Space.World);

			}

			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TournerAGauche) >= 0.1f)
			{
				this.gameObject.transform.Rotate(Vector3.down * 1.5f, Space.World);

			}//*/

			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.Accelerer) >= 0.1f)
			{
			
				if( !fast ){
					fast = true;
					speed *= 3;
				}

			}//*/

			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.Ralentir) <= 0.1f)
			{

				if( fast ){
					fast = false;
					speed /= 3;
				}

			}//*/

			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TirDroite) >= 0.1f)
			{

				if((j % 20) == 0){
					Debug.Log("tir droite");
					canonDroite.GetComponent<CanonJoueur>().shoot=true;
				}

			}//*/
			

			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TirGauche) >= 0.1f)
			{

				if((j % 20) == 0){
					Debug.Log("tir gauche");
					canonGauche.GetComponent<CanonJoueur>().shoot=true;
				}					

			}//*/

		}
	} 
	

	void OnGUI()
	{
		if(infoGUI != null && manager != null && KinectManager.IsKinectInitialized())
		{
			string sInfo = string.Empty;
			
			uint userID = manager.GetPlayer1ID();
			if(userID != 0)
			{
			
				if(manager.GetGestureProgress(userID, KinectWrapper.Gestures.Accelerer) >= 0.1f){
					sInfo += "Geste : Accelerer\n";
				}

				if(manager.GetGestureProgress(userID, KinectWrapper.Gestures.Ralentir) >= 0.1f){
					sInfo = "Geste : Ralentir\n";
				}

				if( (manager.GetGestureProgress(userID, KinectWrapper.Gestures.TirDroite) >= 0.1f) &&
				    (manager.GetGestureProgress(userID, KinectWrapper.Gestures.TirGauche) >= 0.1f)	
				  ){
					sInfo = "Geste : Tir droite et gauche\n";
				}
				else if( manager.GetGestureProgress(userID, KinectWrapper.Gestures.TirDroite) >= 0.1f){
					sInfo = "Geste : Tir droite\n";
				}
				else if( manager.GetGestureProgress(userID, KinectWrapper.Gestures.TirGauche) >= 0.1f){
					sInfo = "Geste : Tir gauche\n";
				}

				if(manager.GetGestureProgress(userID, KinectWrapper.Gestures.TournerADroite) >= 0.1f){
					sInfo = "Geste : Rotation droite\n";
				}

				if(manager.GetGestureProgress(userID, KinectWrapper.Gestures.TournerAGauche) >= 0.1f){
					sInfo = "Geste : Rotation gauche\n";
				}
			}
			else
			{
				sInfo = "Waiting for Users...";
			}
			
			infoGUI.guiText.text = sInfo;
		}
	}

}
