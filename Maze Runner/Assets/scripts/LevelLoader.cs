using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
	public int LevelToLoad;
	public GameObject padlock;
	private string loadprompt;
	private bool inRange;
	private bool canLoadLevel;
	private int completelevel;
	void Start()
	{
		completelevel = PlayerPrefs.GetInt ("Level Complete");
		canLoadLevel = LevelToLoad <= completelevel ? true : false;
		if (!canLoadLevel) 
		{
			Instantiate (padlock, new Vector3 (transform.position.x, 2.5f, -1f), Quaternion.Euler (-90, 0, 0));
		}
	}
	void Update()
	{
		if (Input.GetButtonDown ("Action") && canLoadLevel && inRange)
		{
			SceneManager.LoadScene ("Level" + LevelToLoad.ToString ());
		}
	}
	void OnTriggerStay(Collider other)
	{
		inRange = true;
		if (canLoadLevel) {
			loadprompt = "PRESS [E] TO GO TO LEVEL " + LevelToLoad.ToString ();
		} 
		else
		{
			loadprompt = "LEVEL " + LevelToLoad.ToString () + " is locked.";
		}
	}
	void OnTriggerExit()
	{
		inRange = false;
		loadprompt = "";
	}
	void OnGUI()
	{
		GUI.Label (new Rect (30, Screen.height * 0.9f, 200, 40), loadprompt);
	}
}