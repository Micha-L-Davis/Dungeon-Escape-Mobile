using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get { return health; } set { health = value; } }

    protected override void Init()
    {
        base.Init();
    }

    protected override void Move()
    {
        base.Move();

        float distance = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log("distance is " + distance);
    }

    public void Damage()
    {
        if (Time.time > canTakeDamage)
        {
            canTakeDamage = Time.time + damageCooldown;
            anim.SetTrigger("Hit");
            Health--;
            isHit = true;
            anim.SetBool("InCombat", true);
        }
        
        if (Health < 1)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
