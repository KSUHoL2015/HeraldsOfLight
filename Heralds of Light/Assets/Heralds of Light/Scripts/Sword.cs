using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag.Equals ("enemy")) {
			c.gameObject.GetComponent<Enemy>().anim.Play ("death");
			c.gameObject.GetComponent<Rigidbody2D>().isKinematic =true;
			c.gameObject.GetComponent<BoxCollider2D>().enabled =false;
		}
	}
}
