using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Gamemanager manager;
	public float Movespeed;
	private Vector3 input;
	private Rigidbody ans;
	public float maxspeed;
	private Vector3 spawn;
	public GameObject deathparticle;
	public AudioClip[] audioclip;
	public bool usesmanager = true;
	// Use this for initialization
	void Start () 
	{
		if (usesmanager)
		{
			manager = manager.GetComponent<Gamemanager> ();
		}
		spawn = transform.position;
		ans = GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		input = new Vector3 (Input.GetAxisRaw("Horizontal"),0.0f,Input.GetAxisRaw("Vertical"));
		if (ans.velocity.magnitude < maxspeed)
		{
			ans.AddRelativeForce(input * Movespeed);
		}
		if (transform.position.y < 0.4) 
		{
			die ();
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "enemy") 
		{
			die ();
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "token") 
		{
			if (usesmanager) 
			{
				manager.addtoken ();
			}
			PlaySound (0);
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "enemy") 
		{
			die ();
		}
		if (other.transform.tag == "goal") 
		{
			Time.timeScale = 0f;
			if (usesmanager) 
			{
				manager.CompleteLevel ();
			}
		}
	}
	void PlaySound(int clip)
	{
		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioclip [clip];
		audio.Play ();
	}
	void die()
	{
		Instantiate (deathparticle, transform.position, Quaternion.Euler(270,0,0));
		transform.position = spawn;
	}
}