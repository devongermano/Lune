using UnityEngine;
using System.Collections;
using System.Threading;
using src.Util;


public class Loader : MonoBehaviour 
{
	
	/* Manager prefabs */
	public GameObject gameManager;
	public GameObject timeManager;
	public GameObject threadManager;
        
	void Awake ()
	{
		if (GameManager.instance == null) Instantiate(gameManager);
		if (TimeManager.instance == null) Instantiate(timeManager);
		if (ThreadManager.instance == null) Instantiate(threadManager);
	}
}