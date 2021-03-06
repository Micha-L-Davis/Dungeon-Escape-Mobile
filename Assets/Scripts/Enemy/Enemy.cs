using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int diamonds;
    [SerializeField]
    protected GameObject diamondPrefab;
    protected float damageCooldown = 0.5f;
    protected float canTakeDamage = -1;

    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 movementTarget;

    protected Animator anim;
    protected SpriteRenderer rend;

    protected bool isHit;
    protected bool isDead;

    [SerializeField]
    protected Transform player;

    protected void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_anim") && !anim.GetBool("InCombat"))
            return;
        
        if (!isDead)
            Move();
    }

    public virtual void Attack() { }

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
            Debug.LogError(transform.name + " Animator is NULL");
        rend = GetComponentInChildren<SpriteRenderer>();
        if (rend == null)
            Debug.LogError(transform.name + " Sprite Renderer is NULL");
        movementTarget = pointA.position;
    }

    protected virtual void Move()
    {
        if (movementTarget == pointA.position)
            rend.flipX = true;
        else if (movementTarget == pointB.position)
            rend.flipX = false;

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
            transform.position = Vector3.MoveTowards(transform.position, movementTarget, speed * Time.deltaTime);
        else
        {
            FacePlayer();
        }

        if (Vector2.Distance(player.position, transform.position) > 3f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x < 0)
            rend.flipX = true;
        else
            rend.flipX = false;
    }

    protected virtual void DropLoot()
    {
        GameObject diamond = Instantiate
                              (
                                  diamondPrefab,
                                  transform.position,
                                  Quaternion.identity
                              );
        Diamond loot = diamond.GetComponent<Diamond>();
        loot.Value = diamonds;
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    var returnTarget = movementTarget;
    //    FacePlayer();
    //    if (Vector2.Distance(player.position, transform.position) > 3f)
    //        movementTarget = player.position;
    //    else
    //    {
    //        anim.SetBool("InCombat", true);
    //        movementTarget = returnTarget;
    //    }
    //    //chase player until distance < 3, then set anim incombat true
    //}
}
