using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
public class PlayerController : MonoBehaviour 
{
	public GameController gamecontroller;
	public Rigidbody rb;
	public AudioClip music;
	public Boundary boundary;
	public float tilt;
	private float movespeed = 12;
	public GameObject[] shots;
	public Transform[] Shotspawns;
	public float firerate;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}
	void Update()
	{
		if (Input.GetButtonDown ("Fire1") )//&& Time.time > firerate 
		{
			if (gamecontroller.score < 400) 
			{
				Instantiate (shots[0], Shotspawns[0].position, Shotspawns[0].rotation);
			}
			else if (gamecontroller.score >= 400 && gamecontroller.score < 1000)
			{
				Instantiate (shots[0], Shotspawns[1].position, Shotspawns[1].rotation);
				Instantiate (shots[0], Shotspawns[2].position, Shotspawns[2].rotation);
			}
			else if (gamecontroller.score >= 1000)
			{
				Instantiate (shots[0], Shotspawns [0].position, Shotspawns [0].rotation);
				Instantiate (shots[0], Shotspawns [3].position, Shotspawns [3].rotation);
				Instantiate (shots[0], Shotspawns [4].position, Shotspawns [4].rotation);
			}
			//firerate = Time.time + firerate;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = music;
			audio.Play ();
		}
		if (Input.GetButtonDown ("Fire2")) 
		{
			Instantiate (shots [1], Shotspawns [0].position, Shotspawns [0].rotation);
		}
	}
	void FixedUpdate()
	{
		float horizonal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Vector3 ans = new Vector3 (horizonal, 0.0f, vertical);
		/*
		Vector3 accleration = Input.acceleration;
		Vector3 ans = new Vector3 (accleration.x, 0.0f, accleration.z);
		*/
		rb.velocity = ans * movespeed;
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}