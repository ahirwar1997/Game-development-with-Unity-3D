using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour 
{
	public GUISkin skin;
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label (new Rect (400, 60,1000, 190), "Watchout Boxes");
		if (PlayerPrefs.GetInt ("Level Complete") > 0 )
		{
			if (GUI.Button (new Rect (550, 300, 200, 50), "Continue")) 
			{
				SceneManager.LoadScene (PlayerPrefs.GetInt ("Level Complete"));	
			}
		}
		if(GUI.Button(new Rect(550,400,200,50),"New Game"))
		{
			SceneManager.LoadScene("World Map");
			PlayerPrefs.SetInt ("Level Complete", 0);
			SceneManager.LoadScene (0);	
		}
		if(GUI.Button(new Rect(550,500,200,50),"Exit"))
		{
			Application.Quit();	
		}
	}
}
