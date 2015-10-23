using UnityEngine;
using System.Collections;

public class EnemyUI : MonoBehaviour {

	public Stats enemyStats;



	// Update is called once per frame
	void Update () {
		float temp = (enemyStats.GetHP () / enemyStats.GetMaxHP ());
		if (temp < 0)
			temp = 0f;
		transform.localScale = new Vector3(temp,transform.localScale.y,transform.localScale.z);
	}
}
