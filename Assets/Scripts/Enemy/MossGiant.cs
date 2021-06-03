using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
    }

    public void Damage()
    {
        anim.SetTrigger("Hit_anim");
    }
}
