using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoloMovement : MonoBehaviour {

	public float xSpeed = 1f;
	public float ySpeed = 10f;
	//groundcheck 
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	//audio sources
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
		//groundcheck
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		//movement code
		if (Input.GetKey(KeyCode.LeftArrow)) {
			
			//cameraObj.transform.position -= 5Time.deltaTimeVector3.up;

			anim.SetInteger ("PoloWalk", 1);

			//sprite-flip for walk anim.
			myRigidbody.velocity = new Vector2(-xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer.flipX = true;


		}
		else if (Input.GetKey(KeyCode.RightArrow)) {

			anim.SetInteger ("PoloWalk", 1);

			myRigidbody.velocity = new Vector2(xSpeed, myRigidbody.velocity.y);
			mySpriteRenderer.flipX = false;

		}
		//idle animation 
		else {
			myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);

			anim.SetInteger ("PoloWalk", 0);

		}



		if (Input.GetKeyDown(KeyCode.Space)) {
			anim.SetInteger ("PoloWalk", 2);
			//no double-jump
			if (grounded) {

				audio.PlayOneShot (bark, .5f);

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			}

		}
		//kill-key
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

}
