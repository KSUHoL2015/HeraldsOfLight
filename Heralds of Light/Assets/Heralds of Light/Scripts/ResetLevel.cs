using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour {

	public string scene;

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel(scene);
		}
	}

}
