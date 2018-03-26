using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player1") {
			ScoreTextScript.boneAmount += 1;
			Destroy (gameObject);
		}
		if (other.tag == "Player2") {
			ScoreTextScript.boneAmount += 1;
			Destroy (gameObject);
		}
	}
		
}
