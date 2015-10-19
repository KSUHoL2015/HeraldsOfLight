using UnityEngine;
using System.Collections;

public class LoadSceneButton : MonoBehaviour {

	public string sceneName;

	void OnClick(){
		Application.LoadLevel(sceneName);
	}

}
