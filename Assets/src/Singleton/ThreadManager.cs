using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ThreadManager : MonoBehaviour
{

	public static ThreadManager instance;
	
	private static readonly Queue<Action> _executionQueue = new Queue<Action>();

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
	
	public void Update()
	{
		lock (_executionQueue)
		{
			while (_executionQueue.Count > 0)
			{
				_executionQueue.Dequeue().Invoke();
			}
		}
	}

	public void Queue(IEnumerator action)
	{
		lock (_executionQueue)
		{
			_executionQueue.Enqueue(() =>
			{
				StartCoroutine(action);
			});
		}
	}

	public void Queue(Action action)
	{
		Queue(ActionWrapper(action));
	}

	IEnumerator ActionWrapper(Action action)
	{
		action();
		yield return null;
	}

	private void OnDestroy()
	{
		instance = null;
	}
}