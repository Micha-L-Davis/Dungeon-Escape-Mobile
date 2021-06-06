using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    GameObject _acidBlob;
    public int Health { get { return health; } set { health = value; } }

    protected override void Move()
    {
        //no movement
    }

    public void Damage()
    {
        if (isDead) return;
        Health--;
        if (Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            DropLoot();
        }
    }

    public override void Attack()
    {
        //instantiate acid effect prefab
        Instantiate(_acidBlob, new Vector2(transform.position.x + -0.45f, transform.position.y + -0.03f), Quaternion.identity, this.transform);
    }
}
