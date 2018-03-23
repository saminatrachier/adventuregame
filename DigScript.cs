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

	void OnTriggerEnter2D(Collider other){

		if (other.gameObject.tag == "Polo") {
			Destroy (this.gameObject);
		}
	}

}


