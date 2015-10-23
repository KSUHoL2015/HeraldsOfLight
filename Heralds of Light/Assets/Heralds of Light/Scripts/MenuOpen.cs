using UnityEngine;
using System.Collections;

public class MenuOpen : MonoBehaviour {
		
	public GameObject menu;


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			menu.SetActive(!menu.activeSelf);
			if(menu.activeSelf)
				Time.timeScale=0f;
			else
				Time.timeScale =1f;
		}
	}
}
