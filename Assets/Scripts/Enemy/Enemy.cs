using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    protected float damageCooldown = 0.5f;
    protected float canTakeDamage = -1;

    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 movementTarget;

    protected Animator anim;
    protected SpriteRenderer rend;

    protected bool isHit;

    [SerializeField]
    protected Transform player;

    protected void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && !anim.GetBool("InCombat"))
        {
            return;
        }

        Move();
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
        {
            Debug.LogError(transform.name + " Animator is NULL");
        }
        rend = GetComponentInChildren<SpriteRenderer>();
        if (rend == null)
        {
            Debug.LogError(transform.name + " Sprite Renderer is NULL");
        }
    }

    protected virtual void Move()
    {
        if (movementTarget == pointA.position)
        {
            rend.flipX = true;
        }
        else if (movementTarget == pointB.position)
        {
            rend.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            anim.SetTrigger("Idle");
            movementTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            anim.SetTrigger("Idle");
            movementTarget = pointA.position;

        }

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, movementTarget, speed * Time.deltaTime);
        }

        if (Vector2.Distance(player.position, transform.position) > 2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }
}
