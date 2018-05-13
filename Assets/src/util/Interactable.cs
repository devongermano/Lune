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
		updateVizualizerRotation = true;
	}

	private void OnTriggerExit(Collider other)
	{
		updateVizualizerRotation = false;
		Destroy(mInteractiveVizualizerInstance);
	}
}
