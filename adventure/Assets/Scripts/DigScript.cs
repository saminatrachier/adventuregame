using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour {

	public ParticleSystem dirt;

	public AudioClip diggie;
	public AudioSource soundeffect;

	public GameObject Barrier;

	// Use this for initialization
	void Start () {
		soundeffect.clip = diggie;
	}

	//Polo's Destory/Dig Script on collision
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player2") {

			dirt.Play ();
			soundeffect.Play ();
			Destroy (this.gameObject);
		}
	}
}