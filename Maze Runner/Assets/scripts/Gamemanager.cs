using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour {
	public int currentscore;
	public int highscore;
	public static int currentlevel;
	public int unlockedlevel;
	private float startTime = 25;
	private string currentTime;
	public GUISkin skin;
	private int counttokens;
	public Rect timer;
	public Color ans;
	public Color ans1;
	public GameObject tokenparent;
	private int totaltokens = 9;
	private bool showwinscreen = false;
	private bool completed = false;
	public bool manageruse = true;
	void start()
	{
		totaltokens = tokenparent.transform.childCount;
		if (PlayerPrefs.GetInt ("Level Complete") > 0) {
			currentlevel = PlayerPrefs.GetInt ("Level Complete");
		} else
		{
			currentlevel = 0;
		}
	}
	void Update()
	{
		if (!completed)
		{
			startTime -= Time.deltaTime;
			currentTime = string.Format ("{0:0.0}", startTime);
			if (startTime <= 0) 
			{
				SceneManager.LoadScene ("main_menu");
			}
		}
	}
	public void addtoken()
	{
		counttokens += 1;
	}
	public void CompleteLevel()
	{
		showwinscreen = true;
		completed = true;
		//Loadnextlevel ();
	}
	void Loadnextlevel()
	{
		Time.timeScale = 1f;
		if (currentlevel < 3) {
			currentlevel =currentlevel+1;
			savegame ();
			SceneManager.LoadScene (currentlevel);
		}
		else
		{
			SceneManager.LoadScene (3);
		}
	}
	void savegame()
	{
		PlayerPrefs.SetInt ("Level Complete", currentlevel);
		PlayerPrefs.SetInt ("Level " + currentlevel.ToString () + " Score ", currentscore);
	}
	void OnGUI()
	{
		GUI.skin = skin;
		if (startTime <= 5f) {
			skin.GetStyle ("TIMER").normal.textColor = ans;
		}
		else 
		{
			skin.GetStyle ("TIMER").normal.textColor = ans1;
		}
		if(manageruse)
		{
			GUI.Label (timer, currentTime, skin.GetStyle ("TIMER"));
			GUI.Label (new Rect (10, 50, 100, 100), "TOKENS : " + counttokens.ToString () + "/" + totaltokens.ToString(), skin.GetStyle ("TIMER"));
		}
		if (showwinscreen == true) 
		{
			Rect winScreenRect = new Rect (Screen.width / 2 - (Screen.width * 0.5f / 2), Screen.height / 2 - (Screen.height * 0.5f / 2), Screen.width / 2, Screen.height / 2);
			GUI.Box (winScreenRect, "HEY");
			if (GUI.Button (new Rect (winScreenRect.x + winScreenRect.width - 170, winScreenRect.y + winScreenRect.height - 60, 150, 40), "Continue")) 
			{
				Loadnextlevel ();
			}
			if (GUI.Button (new Rect (winScreenRect.x + 20, winScreenRect.y + winScreenRect.height - 60, 150, 40), "Exit")) 
			{
				SceneManager.LoadScene ("main_menu");
				Time.timeScale = 1f;
			}
			int gametime = (int)startTime;
			currentscore = gametime * counttokens;
			GUI.Label (new Rect (winScreenRect.x + 20, winScreenRect.y + 40, 150, 40), "Score - " + currentscore.ToString (),skin.GetStyle("TIMER"));
			GUI.Label (new Rect (winScreenRect.x + 20, winScreenRect.y + 120, 150, 40), "Current Level - " + (currentlevel+1).ToString (),skin.GetStyle("TIMER"));
		}
	}
}