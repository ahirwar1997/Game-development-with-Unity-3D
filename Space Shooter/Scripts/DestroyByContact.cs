using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerexplosion;
	public GameController gamecontroller;
	public int gamescore;
	void Start()
	{
		GameObject gamecontrollerobject = GameObject.FindWithTag ("GameController");
		if (gamecontrollerobject != null) 
		{
			gamecontroller = gamecontrollerobject.GetComponent<GameController> ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Boundary") || other.CompareTag ("ENEMYBOTS"))
		{
			return;
		}
		if (gameObject.CompareTag ("Beam") && other.CompareTag ("Beam")) 
		{
			return;
		}
		if (explosion != null) 
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}
		if (other.tag == "Player") 
		{
			Instantiate (playerexplosion, other.transform.position, other.transform.rotation);
			gamecontroller.GameOver ();
		}
		if (other.tag == "Beam")
		{
			gamecontroller.AddScore (gamescore);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
