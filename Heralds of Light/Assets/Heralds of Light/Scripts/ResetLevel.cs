using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel("DevScene1");
		}
	}

}
