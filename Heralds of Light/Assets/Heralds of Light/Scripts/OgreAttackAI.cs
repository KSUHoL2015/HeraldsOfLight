using UnityEngine;
using System.Collections;

public class OgreAttackAI : MonoBehaviour {


    public Transform weapon;
    //public PolygonCollider2D weaponCollider;
    public Stats stats;
    public Animator anim;
    public OgreAI MovementAI;

    public float AttackDelay;
    public float NextAttackTime;


    // Use this for initialization
    void Start ()
    {
        //weaponCollider = transform.Find("Hip/Body/Hand_R").GetComponentInChildren<PolygonCollider2D>();
        foreach(Transform child in transform.Find("Hip/Body/Hand_R"))
        {
            weapon = child;
        }

        stats = GetComponent<Stats>();
        anim = GetComponent<Animator>();
        MovementAI = GetComponent<OgreAI>();

        AttackDelay = 3f;
        NextAttackTime = -1f;

    }

    // Update is called once per frame
    void Update ()
    {
        if (!MovementAI.IsDead)
        {
			if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
				weapon.GetComponent<PolygonCollider2D>().enabled = false;

            if (NextAttackTime >= 0f)
                NextAttackTime -= Time.deltaTime;

            if (NextAttackTime < 0f)
            {
                if (MovementAI.IsWithinMeleeRange)
                    MeleeAttack();
                //else if(MovementAI.IsWithinThrowRange)
                //    ThrowAttack();
            }
        }

    }

    public void MeleeAttack()
    {
        weapon.GetComponent<PolygonCollider2D>().enabled = true;
        anim.Play("attack");

        NextAttackTime = AttackDelay;
    }

    public void ThrowAttack()
    {
        weapon.GetComponent<PolygonCollider2D>().enabled = true;
        anim.Play("attack");

        NextAttackTime = AttackDelay;
    }
}
