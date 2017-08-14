using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroywithtime : MonoBehaviour 
{
	public float lifetime;
	void start()
	{
		Destroy (gameObject, lifetime);
	}
}
