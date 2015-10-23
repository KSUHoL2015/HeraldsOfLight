using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	public UISlider slid;
	// Update is called once per frame
	public void SliderChange () {
		AudioListener.volume = slid.value;
	}
}
