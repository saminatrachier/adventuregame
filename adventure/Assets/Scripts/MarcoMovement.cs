using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoMovement : MonoBehaviour {
	public float xSpeed = 1f;
	public float ySpeed = 10f;
	//groundcheck
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	//doublejump
	private bool doubleJump;
	public AudioClip borf;
	public AudioClip doubleBorf;
	AudioSource audio;


	public Animator anim;

	SpriteRenderer mySpriteRenderer;
	Rigidbody2D myRigidbody; 


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer> ();

		anim = this.GetComponent<Animator> ();

		audio = GetComponent<AudioSource> ();



	}
		//groundcheck
	void FixedUpdate (){
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		//double-jump boolean
		if (grounded) {
			doubleJump = false;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			
			//animations and sprites
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

			audio.PlayOneShot (borf, .5f);

			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
		}

		//doublejump enable
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJump && !grounded) {

			anim.SetInteger ("MWalking", 2);

			audio.PlayOneShot (doubleBorf, .5f);

			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, ySpeed);
			doubleJump = true;
		}
		//kill-key
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

	}
}


