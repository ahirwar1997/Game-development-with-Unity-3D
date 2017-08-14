using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManuever : MonoBehaviour 
{
	public float dodge;
	public float smoothing;
	public Vector2 startwait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Boundary boundary;
	private float currentspeed;
	private float TargetManeuver;
	private Rigidbody rb;
	public float tilt;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		currentspeed = rb.velocity.z;
		StartCoroutine (Evade ());
	}
	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range (startwait.x, startwait.y));
		while (true)
		{
			TargetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			TargetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}
	void FixedUpdate()
	{
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, TargetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentspeed);
		rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, rb.position.z);
 		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
