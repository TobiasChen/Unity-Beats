using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextConsoleLog : MonoBehaviour
{
	private string myLog;
	private Queue myLogQueue = new Queue();
	// Use this for initialization
	void Start () {
		Debug.Log("Log1");
		Debug.Log("Log2");
		Debug.Log("Log3");
		Debug.Log("Log4");
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnEnable()
	{
		Application.logMessageReceived += HandleLog;
	}
	void OnDisable () {
		Application.logMessageReceived -= HandleLog;
	}
	void HandleLog(string logString, string stackTrace, LogType type){
		myLog = logString;
		string newString = "\n [" + type + "] : " + myLog;
		if (myLogQueue.Count >= 25)
		{
			myLogQueue.Dequeue();	
		}
		myLogQueue.Enqueue(newString);
		if (type == LogType.Exception)
		{
			newString = "\n" + stackTrace;
			myLogQueue.Enqueue(newString);
		}
		myLog = string.Empty;
		foreach(string mylog in myLogQueue){
			myLog += mylog;
		}
	}

	void OnGUI()
	{
		GUI.Label(new Rect(300,10, 450, 1000), myLog);
	}
}
