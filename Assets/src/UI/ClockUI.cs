﻿using System.Collections;
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
	}

	public void onTimeUpdate(int hours, int minutes)
	{
		mHours = hours;
		mMinutes = minutes;
	}
}