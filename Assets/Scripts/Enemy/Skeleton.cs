using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get { return health; } set { health = value; } }

    public void Damage()
    {
        if (isDead) return;
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
            anim.SetTrigger("Death");
            isDead = true;
            DropLoot();
        }
    }
}
