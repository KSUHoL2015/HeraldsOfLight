using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	private bool hit=false;
	private float hitTimer;
	private float health;
	private float maxHealth=10;
	private float mana;
	private float maxMana=100;
	private float movementSpeed = 0.075f;
	private int physicalDamage =5;
	public int level=1;
	//player only
	private int xp;
	private int maxXp;
	private int monstersToKill = 5;
	private int monsterXP = 3;
	private float mult1 = 1.05f;
	private float mult2 = 1.1f;



	// Use this for initialization
	void Start () {
		health = maxHealth;
		mana = maxMana;
		maxXp = (int)(level * monstersToKill * mult1 * level * monsterXP * mult2);
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			hitTimer +=Time.deltaTime;
		}
		if(hitTimer> .3f){
			hit=false;
			hitTimer=0;
		}
	}

	public int GetDamage(){
		return physicalDamage;
	}
	public float GetMovementSpeed(){
		return movementSpeed;
	}

	public void AddXp(int x){
		xp += x;
	}

	public void AddHealth(float x){
		if (health + x <= maxHealth)
			health += x;
		else
			health = maxHealth;
	}

	public void AddMana(float x){
		if (mana + x <= maxMana)
			mana += x;
		else
			mana = maxMana;
	}

	public void SubtractHealth(float x){
			if (!hit) {
				health -= x;
				if (health <= 0)
					Die ();
				hit = true;
			}
	}
	
	public void SubtractMana(float x){
		if (mana - x > 0)
			mana -= x;
		else
			mana = 0;
	}

	public void AddMaxHealth(float x){
		maxHealth += x;
	}
	
	public void AddMaxMana(float x){
		maxMana+= x;
	}

	public void AddDamage(int x){
		physicalDamage += x;
	}

	public void AddLevel(int x){
		level += x;
	}

	public void Die(){
		GetComponent<Animator> ().Play ("death");
	}
}
