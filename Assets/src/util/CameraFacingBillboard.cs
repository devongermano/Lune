using UnityEngine;
using System.Collections;
 
 
public class CameraFacingBillboard : MonoBehaviour {
 
	public Camera mCamera;
	
	public bool mActive;
	public bool mAutoStart;
	
	private GameObject go;

	
	private void Awake(){
		
		if (mAutoStart) {
			mCamera = Camera.main;
			mActive = true;
		}
 
		//go = new GameObject();
		
		//go.name = transform.gameObject.name;
		//go.transform.position = transform.position;
		//transform.parent = go.transform;
	}

	private void Update() {
		if (mActive) {
			transform.LookAt(transform.position + mCamera.transform.rotation * Vector3.back, 
				mCamera.transform.rotation * Vector3.up);
		}
	}
}