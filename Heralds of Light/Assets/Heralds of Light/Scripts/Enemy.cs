using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float bodyForce;
	public Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
	}


	void OnCollisionStay2D(Collision2D c){
		if (c.gameObject.tag.Equals ("Player")) {
		//
		}
	}

}
