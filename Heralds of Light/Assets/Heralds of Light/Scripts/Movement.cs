using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public Animator anim;
	public float speed;
	public float horizontal;
	public float jumpForce;
	public Rigidbody2D rb;
	public float gravityFall;
	public float airSpeed;
	public bool isGrounded;
	public int direction;

	private Vector2 velocity = Vector3.zero;

	void Start(){
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update() {			
		//velocity = Vector2.zero;
		horizontal = Input.GetAxis ("Horizontal");
		if (horizontal != 0) {
			anim.SetBool ("walk", true);
			if(horizontal > 0)
				transform.eulerAngles = new Vector3(0,180,0);
			else
				transform.eulerAngles = new Vector3(0,0,0);
		}else
			anim.SetBool ("walk", false);
		
		transform.position += new Vector3(horizontal*speed*airSpeed,0,0);


		//attack grounded
		if(isGrounded && Input.GetButton ("Fire2")){
			
		}
		//attack air
		if(!isGrounded && Input.GetButton ("Fire2")){												

		}
		//Falling
		if (!isGrounded)								
			airSpeed = .75f;
		else
			airSpeed = 1;
		//Jump
		if (isGrounded && Input.GetButtonDown("Jump")){									
			velocity.y = jumpForce;
			rb.AddForce (velocity);
		}

		
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag.Equals("ground"))
			isGrounded = true;
	}

	void OnCollisionExit2D(Collision2D c){
		if (c.gameObject.tag.Equals("ground"))
			isGrounded = false;
	}




}
