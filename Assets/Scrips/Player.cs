using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour {

	[SerializeField] private float jumpForce = 100.0f;
	[SerializeField]  private AudioClip sfxJump;
	[SerializeField]  private AudioClip sfxDeath;

	private Rigidbody rigidBody;
	private Animator anim;
	private bool jump = false;
	private AudioSource audioSource;


	void Awake(){
		Assert.IsNotNull (sfxJump);
		Assert.IsNotNull (sfxDeath);
	}
	// Use this for initialization
	void Start () {


		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (!GameManager.instance.gameOver && GameManager.instance.gameStarted){
			if (Input.GetMouseButtonDown (0)){

				GameManager.instance.PlayerStartedGame ();
				anim.Play ("jump");
				audioSource.PlayOneShot (sfxJump);  
				rigidBody.useGravity = true;

				jump = true;

			}
		}

	}


	void FixedUpdate(){

		if (jump == true){

			jump = false;
			rigidBody.velocity = new Vector2 (0, 0);
			rigidBody.AddForce (new Vector2 (0, jumpForce), ForceMode.Impulse);

		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Obstacle"){

			rigidBody.AddForce (new Vector2 (50, -20), ForceMode.Impulse);
			audioSource.PlayOneShot (sfxDeath);
			rigidBody.detectCollisions = false;

			GameManager.instance.PlayerCollided ();
		}
	}
}
