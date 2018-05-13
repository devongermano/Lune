using System.Collections.Generic;
using UnityEngine;

//Allows us to use Lists. 
    
public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	

	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
		{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
	}	
}
        
        
