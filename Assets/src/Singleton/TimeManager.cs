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
		private List<ITimeListener> _mTimeListeners = new List<ITimeListener>();
	
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
			Debug.Log("ON TIME UPDATE");
		}
		
		private void incrementTime()
		{
			if (currentTimeMinutes < 60)
			{
				currentTimeMinutes++;
			} else
			{
				currentTimeHours++;
				currentTimeMinutes = 0;
			}
			
			_mTimeListeners.ForEach(listener => listener.onTimeUpdate(currentTimeHours, currentTimeMinutes));
		}
		
		public void registerTimeListener(ITimeListener listener) {
			_mTimeListeners.Add(listener);
		}

		public void deregisterTimeListener(ITimeListener listener)
		{
			_mTimeListeners.Remove(listener);
		}
	}

	public interface ITimeListener
	{
		void onTimeUpdate(int hours, int minutes);
	}
}