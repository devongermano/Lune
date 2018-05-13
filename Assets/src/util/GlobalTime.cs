using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GlobalTime : MonoBehaviour {

	
	private System.Timers.Timer mTimer = new System.Timers.Timer();
	private float mInterval = 60000; // Minutes to Milliseconds
	
	void Start () {
		//mTimer.Elapsed  += new ElapsedEventHandler(onTimedEvent);
	}
	
	void Update () {
		
	}

	private static void onTimeUpdate(object source, ElapsedEventArgs e)
	{
		
	}
}
