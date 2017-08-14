using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour 
{
	public float speed;
	public Rigidbody rs;
	void Start()
	{
		rs = GetComponent<Rigidbody> ();
		rs.angularVelocity = Random.insideUnitSphere * speed;
	}
}
