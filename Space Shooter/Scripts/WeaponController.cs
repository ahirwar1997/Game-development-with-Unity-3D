using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotspawn;
	public AudioClip music1;
	public  float firerate;
	public float delay;
	public AudioSource audio1;
	void Start()
	{
		audio1 = GetComponent<AudioSource> ();
		audio1.clip = music1;
		InvokeRepeating ("Fire", delay, firerate);
	}
	void Fire()
	{
		Instantiate (shot, shotspawn.position, shotspawn.rotation);
		audio1.Play ();
	}
}
