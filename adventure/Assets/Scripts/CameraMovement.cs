using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject target1, target2;



	private Vector3 offset1, offset2;

	void Start (){
		//camera offset so it follows both the dogs
		offset1 = transform.position - target1.transform.position;
		offset2 = transform.position - target2.transform.position;

	}

	void Update (){
		if (target1.activeSelf) {
			transform.position = target1.transform.position + offset1;

		}
		else if (target2.activeSelf) {
			transform.position = target2.transform.position + offset2;
		}
	}
}