using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

namespace src.Util
{	
	public class TimeManager : MonoBehaviour
	{

		public static TimeManager instance;
		
		private System.Timers.Timer mTimer = new System.Timers.Timer();
		private List<ITimeListener> mTimeListeners = new List<ITimeListener>();
	
		public static int currentTimeHours;
		public static int currentTimeMinutes;
	
		private void Awake()
		{
			if (instance == null)
				instance = this;

			else if (instance != this)
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(gameObject);
			
			mTimer.Elapsed += new ElapsedEventHandler(onTimeUpdate);
			mTimer.Interval = 1000;
			mTimer.Enabled = true;
		}	
		
		private void onTimeUpdate(object source, ElapsedEventArgs e)
		{
			incrementTime();
		}
		
		private void incrementTime()
		{
			if (currentTimeMinutes < 59)
			{
				currentTimeMinutes++;
			} else
			{
				currentTimeHours++;
				currentTimeMinutes = 0;
			}
			
			mTimeListeners.ForEach(listener => listener.onTimeUpdate(currentTimeHours, currentTimeMinutes));
		}
		
		public void registerTimeListener(ITimeListener listener) {
			mTimeListeners.Add(listener);
		}

		public void deregisterTimeListener(ITimeListener listener)
		{
			mTimeListeners.Remove(listener);
		}

		public void stopTime()
		{
			mTimer.Enabled = false;
		}

		public void startTime()
		{
			mTimer.Enabled = true;
		}

		private void OnDestroy()
		{
			instance = null;
		}
	}

	public interface ITimeListener
	{
		void onTimeUpdate(int hours, int minutes);
	}
}