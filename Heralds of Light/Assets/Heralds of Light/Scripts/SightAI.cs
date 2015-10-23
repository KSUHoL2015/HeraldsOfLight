using UnityEngine;
using System.Collections;

public class SightAI : MonoBehaviour
{
    public float viewAngle;

    public bool PlayerInView;
    public bool HasThreat;
    public Collider2D Target;

    //private Animator anim;
    public CircleCollider2D col;
    public OgreAI ai;
    public float RotateDelay;
    public float NextRotateTime;

	// Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        col = GetComponent<CircleCollider2D>();
        ai = transform.parent.gameObject.GetComponent<OgreAI>();
    }

	void Start()
    {
        viewAngle = 45f;
        RotateDelay = 0.5f;
        NextRotateTime = -1f;
    }
	
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && !ai.IsDead)
        {
            PlayerInView = false;
			if(!ai.IsResetting){
				HasThreat = true;
				Target = other;
			}
            //Position + scale in y position so ray cast originates from enemy's head, and ends at player's head
            Vector2 directionToPlayer = (other.transform.position + (Vector3.Scale(other.transform.localScale, other.transform.up))) - (transform.position + Vector3.Scale(transform.parent.localScale, transform.parent.up));
            float angleToPlayer = Vector2.Angle(directionToPlayer, -transform.right); //negative transform.right because ogre facing wrong direction
            if (angleToPlayer < viewAngle * 0.5f)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.parent.up, directionToPlayer.normalized, col.radius);
                //Debug.DrawRay(transform.position + transform.parent.up, directionToPlayer.normalized * col.radius, Color.green, 1f);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag.Equals("Player"))
                    {
                        PlayerInView = true;
                        HasThreat = true;
                        Target = other;
                    }
                }
            }
            
            //If threat is had, enemy will always adjust to look in direction of player
            if (HasThreat && !PlayerInView)
            {
                if (transform.right.x * directionToPlayer.x > 0)
                    RotateDirection();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {	
		if (other.gameObject.tag.Equals ("Player") && !ai.IsDead) {
			PlayerInView = false;
			HasThreat = false;
			Target = null;
			//Return to doing normal patrol
		}
    }

    // Update is called once per frame
    void Update ()
    {
        if (!ai.IsDead)
        {
            if (NextRotateTime >= 0f)
                NextRotateTime -= Time.deltaTime;
        }
	}

    public void RotateDirection()
    {
        if (NextRotateTime < 0f)
        {
            if (transform.right.x < 0)
                transform.parent.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.parent.eulerAngles = new Vector3(0, 180, 0);

            NextRotateTime = RotateDelay;
        }
    }
}
