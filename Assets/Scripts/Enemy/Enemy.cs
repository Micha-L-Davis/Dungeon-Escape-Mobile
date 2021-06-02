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

    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 movementTarget;

    protected Animator anim;
    protected SpriteRenderer rend;


    protected void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim"))
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

    protected void Move()
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

        transform.position = Vector3.MoveTowards(transform.position, movementTarget, speed * Time.deltaTime);
    }
}
