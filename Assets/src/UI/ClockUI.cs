using System.Collections;
using System.Collections.Generic;
using src.Util;
using UnityEngine;
using UnityEngine.Networking;

public class ClockUI : MonoBehaviour, ITimeListener
{
	private int mHours;
	private int mMinutes;


	private void Start()
	{
		TimeManager.instance.registerTimeListener(this);
	}

	public void onTimeUpdate(int hours, int minutes)
	{
		mHours = hours;
		mMinutes = minutes;
		
		Debug.Log("Hours: " + mHours);
		Debug.Log("Minutes: " + mMinutes);
	}
}
