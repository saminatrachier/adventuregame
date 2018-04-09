using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigScript : MonoBehaviour {

	public GameObject Barrier;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Polo's Destory/Dig Script on collision
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player2") {
			Destroy (this.gameObject);
		}
	}

}


