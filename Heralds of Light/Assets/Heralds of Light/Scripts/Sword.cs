﻿using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	public Stats playerStats;

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag.Equals ("enemy")) {
			c.gameObject.GetComponent<Stats>().SubtractHealth(playerStats.GetDamage());
		}
	}
}
