using src.Util;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour, ITimeListener
{
	private int mHours;
	private int mMinutes;

	private int renderedHours;
	private int renderedMinutes;

	private Text mText;
	
	private void Start()
	{
		TimeManager.instance.registerTimeListener(this);

		mText = gameObject.GetComponent<Text>();
	}

	public void onTimeUpdate(int hours, int minutes)
	{
		mHours = hours;
		mMinutes = minutes;
		
		ThreadManager.instance.Queue(() =>
		{
			mText.text = mHours + ":" + mMinutes;
		});
	}
}
