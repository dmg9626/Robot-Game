using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public bool logPhysics;

	void Start()
	{
		LogPhysics = new LogHelper();
		InitializeLoggers();
	}

	private void InitializeLoggers()
	{
		LogPhysics.SetLogging(logPhysics);
	}
	/// <summary>
	/// Physics logger
	/// </summary>
	public static LogHelper LogPhysics;
}	
