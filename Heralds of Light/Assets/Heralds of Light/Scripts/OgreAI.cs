using UnityEngine;
using System.Collections;

public class OgreAI : MonoBehaviour
{
    public SightAI sight;
    public Animator anim;
    public BoxCollider2D col;
    public Stats stats;
    public OgreAttackAI AttackAI;


    public float Speed;
    public bool IsDead = false;
    public bool IsGrounded = true;
    public Vector2 Origin;

    public bool IsResetting = false;
    public bool AtOrigin = true;


    public GameObject LastPlayerToStrike;
    public bool IsWithinMeleeRange = false;
    public bool IsWithinThrowRange = false;

    // Use this for initialization
    void Start ()
    {
        //This will search this gameObject for a child gameObject callde 'Sight'
        sight = transform.Find("Sight").gameObject.GetComponent<SightAI>();
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        stats = GetComponent<Stats>();
        AttackAI = GetComponent<OgreAttackAI>();

        Speed = 1.5f;
        Origin = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (sight.HasThreat && sight.Target != null)
        {
            AtOrigin = false;
            IsResetting = false;
            MoveTowardsPlayer();
        }
        else if(IsGrounded && IsResetting)
        {
            Reset();
        }
        else
        {
            anim.SetBool("walk", false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag.Equals("Edge") && !IsDead){
            IsResetting = true;
            //EdgeFound = true;
            sight.HasThreat = false;
            sight.PlayerInView = false;

            Vector2 directionToEdge = other.transform.position - transform.position;
            if (transform.right.x * directionToEdge.x < 0)
                sight.RotateDirection();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player") && !IsDead)
        {
            LastPlayerToStrike = other.gameObject;
            sight.HasThreat = true;
            sight.Target = other.collider;
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag.Equals("Edge"))
    //    {
    //        EdgeFound = false;
    //    }
    //}


    void Patrol()
    {

    }

    void MoveToLocation(Vector2 enemyPos, Vector2 dest)
    {

    }

    void MoveTowardsPlayer()
    {
        Vector2 enemyPos = transform.position;
        Vector2 playerPos = sight.Target.transform.position;
        float range = Vector2.Distance(enemyPos, playerPos);
        if (range > 5f)
        {
            anim.SetBool("walk", true);
            transform.position += -transform.right * Speed * Time.deltaTime;
            //transform.Translate(Vector2.MoveTowards(enemyPos, playerPos, range) * Speed * Time.deltaTime);
            //Debug.Log("New Pos: " + (-transform.right * Speed * Time.deltaTime));
            IsWithinMeleeRange = false;
            IsWithinThrowRange = false;
        }
        else if(range > 1f)
        {
            if (!anim.GetBool("attack"))
            {
                anim.SetBool("walk", true);
                transform.position += -transform.right * Speed * Time.deltaTime;
            }
            else { Debug.Log("Attacking"); }
            IsWithinThrowRange = true;
        }
        else
        {
            anim.SetBool("walk", false);
            IsWithinThrowRange = false;
            IsWithinMeleeRange = true;
        }
    }

    void Reset()
    {
        sight.NextRotateTime = -1;
        IsWithinMeleeRange = false;
        Vector2 enemyPos = transform.position;
        float range = Vector2.Distance(enemyPos, Origin);
        if (range > 1f)
        {
            anim.SetBool("walk", true);
            transform.position += -transform.right * Speed * Time.deltaTime;
            //transform.Translate(Vector2.MoveTowards(enemyPos, playerPos, range) * Speed * Time.deltaTime);
            //Debug.Log("New Pos: " + (-transform.right * Speed * Time.deltaTime));
        }
        else
        {
            AtOrigin = true;
            IsResetting = false;
            sight.RotateDirection();
            anim.SetBool("walk", false);
        }
    }



    /*Not movement related*/



    public void Die()
    {
        IsDead = true;
        sight.col.enabled = false;
        col.enabled = false;
        sight.HasThreat = false;
        sight.PlayerInView = false;

        if(LastPlayerToStrike != null)
            LastPlayerToStrike.GetComponent<Stats>().AddXp((int)((float)stats.level * stats.monsterXP * stats.mult2));

        anim.Play("death");
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

    }
}
