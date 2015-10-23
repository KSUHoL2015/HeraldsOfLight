using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Animator anim;
	public PolygonCollider2D swordCollider;
	public AudioSource as1;
	public AudioClip ac;
	void Start(){
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack")) {
			swordCollider.enabled = false;
			if (Input.GetButton ("Fire1")) {
				MeleeAttack();
			}
		}
	}

	public void MeleeAttack(){
		swordCollider.enabled = true;
		anim.Play("attack");
		as1.PlayOneShot (ac);
	}


}
