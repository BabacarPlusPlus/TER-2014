using UnityEngine;
using System.Collections;

public class MouvementVaisseau : MonoBehaviour {

	public Transform direction;
	public GameObject[] selectableObjects;
	public Material selectedObjectMaterial;
	public float hitForce = 0.001f;
	
	private KinectManager manager;
	private GameObject handCursor;
	
	private Material[] objectMaterials;
	private GameObject selectedObject;
	
	private GameObject infoGUI;
	private string detectedGesture;
	
	private KinectWrapper kw;

	private bool fast;
	private int speed;

	void Awake() 
	{
		speed = 5;
		fast = false;
		// get needed objects´ references
		manager = GameObject.Find("Vaisseau/Main Camera").GetComponent<KinectManager>();
		//handCursor = GameObject.Find("HandCursor");
		handCursor = gameObject;
		infoGUI = GameObject.Find("HandGuiText");
		
		// save original materials
		objectMaterials = new Material[selectableObjects.Length];
		for(int i = 0; i < selectableObjects.Length; i++)
		{
			if(selectableObjects[i] && selectableObjects[i].renderer)
			{
				objectMaterials[i] = new Material(selectableObjects[i].renderer.material);
			}
		}
	}
	
	
	void Update() 
	{
		Vaisseau.avancer();

		handCursor.transform.Translate(Vector3.forward * speed * Time.deltaTime);

		if(manager != null && KinectManager.IsKinectInitialized() && manager.GetPlayer1ID() > 0)
		{
			uint userId = manager.GetPlayer1ID();
			Vector3 screenNormalPos = Vector3.zero;
			// cursor control
			//if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.RightHandCursor, true))
			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TournerADroite	) >= 0.1f)
			{
				if(handCursor)
				{
					//screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.RightHandCursor);
					//handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
					handCursor.transform.Rotate(Vector3.down * 1.5f, Space.World);
					/*direction.Rotate(Vector3.up * 1.5f, Space.World);
					Transform rotate = Quaternion.LookRotation(direction.position - transform.position);
					transform.rotation = Quaternion.Slerp(transform.position, rotate, Time.deltaTime * 1);//*/


				}
			}
			else if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.TournerAGauche) >= 0.1f)
			{
				if(handCursor)
				{
					//screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.LeftHandCursor);
					//handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
					//handCursor.rigidbody.AddForce(Vector3.zero);
					handCursor.transform.Rotate(Vector3.up * 1.5f, Space.World);


				}
			}//*/
			else if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.Accelerer) >= 0.1f)
			{
				if(handCursor)
				{
					//screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.LeftHandCursor);
					//handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
					//handCursor.rigidbody.AddForce(Vector3.left * 4f);
					//handCursor.rigidbody.AddForceAtPosition(Vector3.forward * 3f, transform.position);
					//handCursor.transform.Translate(Vector3.forward * Time.deltaTime * 3);
					if( !fast ){
						fast = true;
						speed *= 3;
					}



				}
			}//*/

			else if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.Ralentir) >= 0.1f)
			{
				if(handCursor)
				{
					//screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.LeftHandCursor);
					//handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
					//handCursor.rigidbody.AddForce(Vector3.left * 1f);
					//handCursor.rigidbody.AddForce(Vector3.back * 1f);
					if( fast ){
						fast = false;
						speed /= 3;
					}
					
				}
			}//*/
			
			// object-selection functionality
			float fClickProgress = manager.GetGestureProgress(userId, KinectWrapper.Gestures.Click);
			if(fClickProgress > 0.1f)
			{
				screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.Click);
				
				Vector3 hitPoint;
				GameObject selObject = GetSelectedObject(screenNormalPos, out hitPoint);
				
				// restore all original materials
				RestoreObjectMaterials();
				
				// set selection material
				if(selectedObject && selectedObject.renderer)
					selectedObject.renderer.material = selectedObjectMaterial;
				
				if(selObject && selObject.renderer)
				{
					Color colObject = Color.Lerp(selObject.renderer.material.color, selectedObjectMaterial.color, fClickProgress);
					selObject.renderer.material.color = colObject;
				}
			}
			
			if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.Click, true))
			{
				screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.Click);
				
				Vector3 hitPoint;
				GameObject selObject = GetSelectedObject(screenNormalPos, out hitPoint);
				
				if(selObject)
				{
					selectedObject = selObject;
					
					// restore all original materials
					RestoreObjectMaterials();
					
					// set selection material
					if(selectedObject.renderer)
						selectedObject.renderer.material = selectedObjectMaterial;
				}
			}
			
			
			// object-movement functionality
			if(selectedObject != null && selectedObject.rigidbody != null)
			{
				if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeLeft, true))
				{
					detectedGesture = "SwipeLeft";
					selectedObject.rigidbody.AddForce(Vector3.left * hitForce);
				}
				else if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeRight, true))
				{
					detectedGesture = "SwipeRight";
					selectedObject.rigidbody.AddForce(Vector3.right * hitForce);
				}
				else if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeUp, true))
				{
					detectedGesture = "SwipeUp";
					selectedObject.rigidbody.AddForce(Vector3.up * hitForce);
				}
				else if(manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeDown, true))
				{
					detectedGesture = "SwipeDown";
					selectedObject.rigidbody.AddForce(Vector3.down * hitForce);
				}
			}
			else
			{
				// ignore gestures in progress
				manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeLeft, true);
				manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeRight, true);
				manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeUp, true);
				manager.IsGestureComplete(userId, KinectWrapper.Gestures.SwipeDown, true);
			}
			
		}
	} 
	
	// returns the selected object or null
	private GameObject GetSelectedObject(Vector3 screenNormalPos, out Vector3 hitPoint)
	{
		// convert the normalized screen pos to pixel pos
		Vector3 screenPixelPos = Vector3.zero;
		screenPixelPos.x = (int)(screenNormalPos.x * Camera.mainCamera.pixelWidth);
		screenPixelPos.y = (int)(screenNormalPos.y * Camera.mainCamera.pixelHeight);
		Ray ray = Camera.mainCamera.ScreenPointToRay(screenPixelPos);
		
		// check for underlying objects
		RaycastHit hit;
		hitPoint = Vector3.zero;
		
		if(Physics.Raycast(ray, out hit))
		{
			
			foreach(GameObject obj in selectableObjects)
			{
				if(hit.collider.gameObject == obj)
				{
					hitPoint = hit.point;
					return obj;
				}
			}
		}
		
		return null;
	}
	
	// restores original object materials
	private void RestoreObjectMaterials()
	{
		for(int i = 0; i < selectableObjects.Length; i++)
		{
			if(selectableObjects[i] && selectableObjects[i].renderer)
			{
				selectableObjects[i].renderer.material = objectMaterials[i];
			}
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
				/*if(selectedObject != null && selectedObject.rigidbody != null && selectedObject.rigidbody.velocity != Vector3.zero)
					sInfo = detectedGesture + " detected.";
				else if(selectedObject != null)
					sInfo = "You selected " + selectedObject.name + ". Swipe to move it left or right.";
				else
					sInfo = "Hold the cursor over an object to select it.";//*/

				if(manager.GetGestureProgress(userID, KinectWrapper.Gestures.Push) >= 0.1f){
					sInfo = "Geste : Push";
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
