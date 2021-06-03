using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get { return health; } set { health = value; } }

    protected override void Init()
    {
        base.Init();
    }

    public void Damage()
    {
        anim.SetTrigger("Hit_anim");
        Health--;
        if (Health < -1)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
