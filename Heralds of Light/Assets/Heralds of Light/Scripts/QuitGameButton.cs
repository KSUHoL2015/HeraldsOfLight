using UnityEngine;
using System.Collections;

public class QuitGameButton : MonoBehaviour {

	void OnClick(){
		System.Diagnostics.Process.GetCurrentProcess().Kill();
	}
}
