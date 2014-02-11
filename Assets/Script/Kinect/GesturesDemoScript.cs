using UnityEngine;
using System.Collections;

public class GesturesDemoScript : MonoBehaviour 
{
	public GameObject[] selectableObjects;
	public Material selectedObjectMaterial;
	public float hitForce = 300f;
	
	private KinectManager manager;
	private GameObject handCursor;
	
	private Material[] objectMaterials;
	private GameObject selectedObject;
	
	private GameObject infoGUI;
	private string detectedGesture;
	
	
	void Awake() 
	{
		// get needed objects´ references
		manager = Camera.mainCamera.GetComponent<KinectManager>();
		handCursor = GameObject.Find("HandCursor");
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
		if(manager != null && KinectManager.IsKinectInitialized() && manager.GetPlayer1ID() > 0)
		{
			uint userId = manager.GetPlayer1ID();
			Vector3 screenNormalPos = Vector3.zero;
			
			// cursor control
			if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.RightHandCursor) >= 0.1f)
			{

				if(handCursor)
				{
					screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.RightHandCursor);
					handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
					Debug.Log(KinectWrapper.Gestures.RightHandCursor);
				}
			}
			else if(manager.GetGestureProgress(userId, KinectWrapper.Gestures.LeftHandCursor) >= 0.1f)
			{
				if(handCursor)
				{
					screenNormalPos = manager.GetGestureScreenPos(userId, KinectWrapper.Gestures.LeftHandCursor);
					handCursor.transform.position = Vector3.Lerp(handCursor.transform.position, screenNormalPos, 3 * Time.deltaTime);
				}
			}
			
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
				if(selectedObject != null && selectedObject.rigidbody != null && selectedObject.rigidbody.velocity != Vector3.zero)
					sInfo = detectedGesture + " detected.";
				else if(selectedObject != null)
					sInfo = "You selected " + selectedObject.name + ". Swipe to move it left or right.";
				else
					sInfo = "Hold the cursor over an object to select it.";
			}
			else
			{
				sInfo = "Waiting for Users...";
			}
			
			infoGUI.guiText.text = sInfo;
		}
	}
	
}
