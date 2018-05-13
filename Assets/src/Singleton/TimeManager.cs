using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

namespace src.Util
{
	public class TimeManager : MonoBehaviour
	{
		
		public static TimeManager instance = null;
		
		private System.Timers.Timer mTimer = new System.Timers.Timer();
		private ITimeListener _mTimeListener;
	
		public static int currentTimeHours;
		public static int currentTimeMinutes;
	
	//	public TimeManager(ITimeListener timeListener)
	//	{
		//	_mTimeListener = timeListener;
			
			/* Setup the timer listener */
		//	mTimer.Elapsed += new ElapsedEventHandler(onTimeUpdate);
		//}

		private void Awake()
		{
			if (instance == null)
				instance = this;

			else if (instance != this)
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
		}	
		
		private void onTimeUpdate(object source, ElapsedEventArgs e)
		{
			incrementTime();
		}
		
		private void incrementTime()
		{
			if (currentTimeMinutes < 60)
			{
				currentTimeMinutes++;
				return;
			}
			currentTimeHours++;
			currentTimeMinutes = 0;	
		}
	}

	public interface ITimeListener
	{
		void onTimeUpdate(int hours, int minutes);
	}
}