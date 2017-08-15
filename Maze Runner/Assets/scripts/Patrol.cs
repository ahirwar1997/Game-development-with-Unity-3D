using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public Transform[] patrolpoints;
	public float movespeed;
	private int currentposition;
	void Start ()
	{
		transform.position = patrolpoints [0].position;
		currentposition = 0;
	}
	// Update is called once per frame
	void Update () 
	{
		if (transform.position == patrolpoints [currentposition].position)
		{
			currentposition++;
		}
		if (currentposition >= patrolpoints.Length) 
		{
			currentposition = 0;
		}
		transform.position = Vector3.MoveTowards (transform.position, patrolpoints [currentposition].position, movespeed * Time.deltaTime);
	}
}
