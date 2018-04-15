using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour {

	public GameObject avatar1, avatar2;
	public bool dogSwitch;
	int whichAvatarIsOn = 1;
	public Vector3 dogPosition;

	// Use this for initialization
	void Start () {
		//start as 'Marco'
		avatar1.gameObject.SetActive (true);
		avatar2.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	public void SwitchAvatar () {
		

		switch (whichAvatarIsOn) {
		case 1:
			whichAvatarIsOn = 2;
			//disable player1 and enable player2
			avatar1.gameObject.SetActive (false);
		
			avatar2.gameObject.SetActive (true);

			break;

		case 2:

			whichAvatarIsOn = 1;
			//disable player2 and enable player1
			avatar1.gameObject.SetActive (true);
		

			avatar2.gameObject.SetActive (false);
		
			break;
		}
	}

	void Update (){
		if (Input.GetKeyDown(KeyCode.LeftShift)) {

			switch (whichAvatarIsOn) {

			//If the first avatar is on
			case 1:
				//then the 2nd avatar is on
				whichAvatarIsOn = 2;
				//disable player1 and enable player2
				avatar1.gameObject.SetActive (false);
				avatar2.gameObject.SetActive (true);
				dogPosition = avatar1.gameObject.GetComponent<Transform> ().position;
				avatar2.gameObject.GetComponent<Transform> ().position = dogPosition;



				break;

			case 2:

				whichAvatarIsOn = 1;
				//disable player2 and enable player1
				avatar1.gameObject.SetActive (true);
				avatar2.gameObject.SetActive (false);
				dogPosition = avatar2.gameObject.GetComponent<Transform> ().position;
				avatar1.gameObject.GetComponent<Transform> ().position = dogPosition;


				break;
			}

		}
}
}
