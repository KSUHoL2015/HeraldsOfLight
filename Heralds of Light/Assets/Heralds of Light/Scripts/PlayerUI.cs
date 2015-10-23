using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public Stats playerStats;
	public UISprite hpbar;
	public UILabel hpLabel;
	public UISprite xpbar;
	public UILabel levelLabel;

	// Update is called once per frame
	void Update () {
		float temp = (playerStats.GetHP () / playerStats.GetMaxHP ());
		if (temp < 0)
			temp = 0f;
		hpbar.transform.localScale = new Vector3(temp,hpbar.transform.localScale.y,hpbar.transform.localScale.z);
		hpLabel.text = playerStats.GetHP () +"/"+ playerStats.GetMaxHP ();

		temp = (float)playerStats.xp / playerStats.maxXp;
		if (temp < 0)
			temp = 0f;
		xpbar.transform.localScale = new Vector3(temp,xpbar.transform.localScale.y,xpbar.transform.localScale.z);
		levelLabel.text = ""+playerStats.level;

	}
}
