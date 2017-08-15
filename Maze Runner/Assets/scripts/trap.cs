using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {
	public float delaytime;
	private Animation b;
	void Start () 
	{
		b = GetComponent<Animation> ();
		StartCoroutine (Go ());
	}
	
	// Update is called once per frame

		IEnumerator Go()
		{
			while(true)
			{
				b.Play ();
				yield return new WaitForSeconds(3f);
			}
		}
}
