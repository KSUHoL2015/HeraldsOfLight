using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour
{
    public Stats enemyStats;

    void Start()
    {
        //if (playerStats == null)
        //    playerStats = GameObject.Find("Knight").GetComponent<Stats>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Player"))
        {
            c.gameObject.GetComponent<Stats>().SubtractHealth(enemyStats.GetDamage());
        }
    }
}