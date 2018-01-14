using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHelper {

	/// <summary>
	/// True if logging is enabled
	/// </summary>
	private bool enabled;

	public void Log(string log)
	{
		if(enabled) {
			Debug.Log(log);
		}
	}

	public void LogWarning(string log)
	{
		if(enabled) {
			Debug.LogWarning(log);
		}
	}
	
	/// <summary>
	/// Enable/disable logging
	/// </summary>
	/// <param name="enabled">If true, logging is enabled</param>
	public void SetLogging(bool enabled)
	{
		this.enabled = enabled;
	}
}
