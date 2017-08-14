using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroll : MonoBehaviour
{
	private Vector3 startposition;
	public float scrollspeed;
	public float TileSizeZ;
	void Start()
	{
		startposition = transform.position;
	}
	void Update()
	{
		float newposition = Mathf.Repeat (Time.time * scrollspeed, TileSizeZ);
		transform.position = startposition + Vector3.forward * newposition;
	}
}
