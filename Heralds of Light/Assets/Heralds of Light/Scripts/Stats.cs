using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
	
	public bool hit = false;
	private float hitTimer;
	private float health;
	public float maxHealth = 100;
	private float mana;
	public float maxMana = 100;
	private float movementSpeed = 0.075f;
	public int physicalDamage = 5;
	public int level = 1;
	public bool IsPlayer;
	public GameObject hpBar;
	//player only
	public int xp;
	public int maxXp;
	private int monstersToKill = 5;
	public int monsterXP = 3;
	public float mult1 = 1.05f;
	public float mult2 = 1.1f;

	public AudioSource as1;
	public AudioClip ac;

	
	
	
	// Use this for initialization
	void Start()
	{
		IsPlayer = false;
		if (gameObject.tag.Equals("Player"))
			IsPlayer = true;
		maxHealth = 100 + 10 * level;
		if(!IsPlayer)
			physicalDamage = 5 + level;
		else
			physicalDamage = 35 + (2*level);
		health = maxHealth;
		mana = maxMana;
		maxXp = (int)(level * monstersToKill * mult1 * level * monsterXP * mult2);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (hit)
		{
			hitTimer += Time.deltaTime;
		}
		if (hitTimer > .3f)
		{
			hit = false;
			hitTimer = 0;
		}
	}
	
	public int GetDamage()
	{
		return physicalDamage;
	}

	public float GetMovementSpeed()
	{
		return movementSpeed;
	}

	public float GetHP(){
		return health;
	}

	public float GetMaxHP(){
		return maxHealth;
	}
	
	public void AddXp(int x)
	{
		xp += x;
		if (xp > maxXp)
			AddLevel ();
	}
	
	public void AddHealth(float x)
	{
		if (health + x <= maxHealth)
			health += x;
		else
			health = maxHealth;
	}
	
	public void AddMana(float x)
	{
		if (mana + x <= maxMana)
			mana += x;
		else
			mana = maxMana;
	}
	
	public void SubtractHealth(float x)
	{
		if (!hit)
		{
			as1.PlayOneShot (ac);
			health -= x;
			if (health <= 0)
				Die();
			hit = true;
		}
	}
	
	public void SubtractMana(float x)
	{
		if (mana - x > 0)
			mana -= x;
		else
			mana = 0;
	}
	
	public void AddMaxHealth(float x)
	{
		maxHealth += x;
	}
	
	public void AddMaxMana(float x)
	{
		maxMana += x;
	}
	
	public void AddDamage(int x)
	{
		physicalDamage += x;
	}
	
	public void AddLevel()
	{
		xp = xp - maxXp;
		maxXp = (int)(level * monstersToKill * mult1 * level * monsterXP * mult2);
		health = maxHealth;
		mana = maxMana;
		level ++;

	}
	
	public void Die()
	{
		
		if(!IsPlayer)
		{
			var c = GetComponent<OgreAI>();
			c.Die();
			hpBar.SetActive(false);
		}
		else
		{	GetComponent<PlayerAttack>().enabled =false;
			GetComponent<Movement>().enabled =false;
			GetComponent<Animator>().Play("death");
		}
	}
}