using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

	public Camera mCamera;
	public GameObject mInteractionVizualizer;

	private Boolean updateVizualizerRotation;
	private GameObject mInteractiveVizualizerInstance;
	
	
	void Start ()
	{
		mInteractiveVizualizerInstance = mInteractionVizualizer;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateVizualizerRotation)
		{
			mInteractiveVizualizerInstance.transform.LookAt(mInteractiveVizualizerInstance.transform.position + mCamera.transform.rotation * Vector3.forward,
				mCamera.transform.rotation * Vector3.up);	
		}
			
	}

	private void OnTriggerEnter(Collider other)
	{
		mInteractiveVizualizerInstance = Instantiate(mInteractionVizualizer, transform);
		
		//Vector3 p = this.gameObject.transform.position;

		//mInteractionVizualizer.transform.position = new Vector3(p.x, p.y + 1, p.z);
		
		updateVizualizerRotation = true;
		Debug.Log("Trigger Entered!");
		//mInteractionVizualizer.SetActive(true);

		// Show the interaction interstitial
	}

	private void OnTriggerExit(Collider other)
	{
		updateVizualizerRotation = false;
		Destroy(mInteractiveVizualizerInstance);
		Debug.Log("Trigger Exited!");
		//mInteractionVizualizer.SetActive(false);
		// Hide the interaction interstitial
	}
}
