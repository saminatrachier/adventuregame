using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoMovement : MonoBehaviour {
	public float xSpeed = 1f;
	public float ySpeed = 10f;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJump;


	Rigidbody2D myRigidbody; 


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}
		
	void FixedUpdate (){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (grounded) {
			doubleJump = false;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position -= xSpeedTime.deltaTimeVector3.right;
			// transform.position -= new Vector3(0.5f, 0, 0);
			// transform.position = new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z);


			//cameraObj.transform.position -= 5Time.deltaTimeVector3.up;

			myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += xSpeedTime.deltaTimeVector3.right;


			myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
		} else {
			myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
		}

	
			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			doubleJump = true;
		}

	}
}


