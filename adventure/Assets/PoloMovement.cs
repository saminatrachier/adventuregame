using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloMovement : MonoBehaviour {

	public float xSpeed = 1f;
	public float ySpeed = 10f;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	public AudioClip bark;
	AudioSource audio;

	public Animator anim;

	Rigidbody2D myRigidbody; 
	SpriteRenderer mySpriteRenderer;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();

		anim = this.GetComponent<Animator> ();

		audio = GetComponent<AudioSource> ();

	}

	void FixedUpdate (){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.position -= xSpeedTime.deltaTimeVector3.right;
			// transform.position -= new Vector3(0.5f, 0, 0);
			// transform.position = new Vector3(transform.position.x-0.5f, transform.position.y, transform.position.z);


			//cameraObj.transform.position -= 5Time.deltaTimeVector3.up;

			anim.SetInteger ("PoloWalk", 1);


			myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer.flipX = true;


		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			//transform.position += xSpeedTime.deltaTimeVector3.right;

			anim.SetInteger ("PoloWalk", 1);

			myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer.flipX = false;

		}
		else {
			myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);

			anim.SetInteger ("PoloWalk", 0);

		}



		if (Input.GetKeyDown(KeyCode.Space)) {
			anim.SetInteger ("PoloWalk", 2);

			if (grounded) {

				audio.PlayOneShot (bark, .5f);

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			}

		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

}
