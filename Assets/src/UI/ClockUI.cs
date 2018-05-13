using src.Util;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour, ITimeListener
{
	private int mHours;
	private int mMinutes;

	private Text mText;
	
	private void Start()
	{
		TimeManager.instance.registerTimeListener(this);

		mText = gameObject.GetComponent<Text>();
	}

	private void Update()
	{
		mText.text = mHours + ":" + mMinutes;
	}

	public void onTimeUpdate(int hours, int minutes)
	{
		mHours = hours;
		mMinutes = minutes;
	}
}
