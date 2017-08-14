using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	public Rigidbody rb;
	public GameObject postion;
	public float movementspeed;
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}
	void Update () 
	{
		transform.Rotate (new Vector3 (0.0f, 0.0f, 45)*Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, postion.transform.position, movementspeed * Time.deltaTime);
	}
}
