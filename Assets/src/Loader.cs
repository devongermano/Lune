using UnityEngine;
using System.Collections;
using src.Util;


public class Loader : MonoBehaviour 
{
	
	/* Manager prefabs */
	public GameObject gameManager;
	public GameObject timeManager;
        
        
	void Awake ()
	{
		if (GameManager.instance == null) Instantiate(gameManager);
		if (TimeManager.instance == null) Instantiate(timeManager);
	}
}