using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

	public ParticleSystem shiny;

	public AudioClip SoundEffect;
	public AudioSource MusicSource;

	void Start() {
		MusicSource.clip = SoundEffect;
	}

	//bones are collected and displayed no matter what dog picks them up
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player1") {
			ScoreTextScript.boneAmount += 1;
			shiny.Play ();
			Destroy (gameObject);

			MusicSource.Play ();
		}
		if (other.tag == "Player2") {
			ScoreTextScript.boneAmount += 1;
			shiny.Play ();
			Destroy (gameObject);

			MusicSource.Play ();
		}
	}
		
}
