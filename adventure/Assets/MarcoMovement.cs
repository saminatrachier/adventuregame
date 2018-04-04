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


	public Animator anim;

	SpriteRenderer mySpriteRenderer;
	Rigidbody2D myRigidbody; 


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();

		anim = this.GetComponent<Animator> ();



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

			anim.SetInteger ("MWalking", 1);

			myRigidbody.velocity = new Vector2 (-xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer.flipX = true;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += xSpeedTime.deltaTimeVector3.right;


			anim.SetInteger ("MWalking", 1);
			mySpriteRenderer.flipX = false;


			myRigidbody.velocity = new Vector2 (xSpeed, myRigidbody.velocity.y);
		} else {

			anim.SetInteger ("MWalking", 0);

			myRigidbody.velocity = new Vector2 (0, myRigidbody.velocity.y);
		}

	
			if (Input.GetKeyDown (KeyCode.Space) && grounded) {

			anim.SetInteger ("MWalking", 2);
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) {

			anim.SetInteger ("MWalking", 2);

			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			doubleJump = true;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}
}


