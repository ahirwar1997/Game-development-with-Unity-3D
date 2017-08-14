using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour 
{
	public Rigidbody moveer;
	public float speed;
	void Start()
	{
		moveer = GetComponent<Rigidbody> ();
		moveer.velocity = transform.forward * speed;
	}
}
