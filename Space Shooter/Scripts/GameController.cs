using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour 
{
	public float value;
	public GameObject[] hazards;
	public Vector3 spawnvalues;
	public float startwait;
	public float spawnwait;
	public int hazardcount;
	public int wavewait;
	public GUIText scoretext;
	public int score;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restart;
	private Vector3 spawnpostion;
	private Quaternion spawnrotation;
	private Vector3 enemyspawn;
	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0; 
		UpdateScore ();
		StartCoroutine (Spawnwaves ());
	}
	void Update()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene (0);
			}
		}
	}
	IEnumerator Spawnwaves()
	{
		yield return new WaitForSeconds (startwait);
		while (true)
		{
			for (int i = 0; i < hazardcount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				if (hazard != hazards [4] && hazard != hazards [5]) {
					spawnpostion = new Vector3 (Random.Range (-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
					spawnrotation = Quaternion.identity;
					Instantiate (hazard, spawnpostion, spawnrotation);
				} 
				else if (score > 600 && hazard == hazards [5]) 
				{
					spawnpostion = new Vector3 (Random.Range (-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
					spawnrotation = Quaternion.identity;
					Instantiate (hazard, spawnpostion, spawnrotation);
				}
				else if (score > 1400 && hazard == hazards [4])
				{
					value = Random.Range (-6,3);
					for(int j=0;j<4;j++)
					{
						enemyspawn = new Vector3 (value, 0.0f, spawnvalues.z);
						Instantiate(hazards[4],enemyspawn,spawnrotation);
						value = value + 1.5f;
					}
					yield return new WaitForSeconds(0.5f);
				}
				if (gameOver)
				{
					restartText.text="Press 'R' To Restart";
					restart = true;
					break;
				}
				yield return new WaitForSeconds (spawnwait);
			}	
			yield return new WaitForSeconds (wavewait);
		}
	}
	public void AddScore(int newscorevalue)
	{
		score += newscorevalue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoretext.text = "Score:" + score;
	}
	public void GameOver()
	{
		gameOverText.text="Game Over!";
		gameOver = true;
	}
}
