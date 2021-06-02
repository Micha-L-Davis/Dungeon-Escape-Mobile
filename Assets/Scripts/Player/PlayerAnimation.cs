using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator[] _anim;


    void Start()
    {
        _anim = GetComponentsInChildren<Animator>();
        if (_anim[0] == null)
        {
            Debug.LogError("Player Animator is NULL");
        }
        if (_anim[1] == null)
        {
            Debug.LogError("Sword Animator is NULL");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 axisInput)
    {
        _anim[0].SetFloat("Move", Mathf.Abs(axisInput.x));
    }

    public void Jump(bool jumping)
    {
        _anim[0].SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _anim[0].SetTrigger("Attack");
        _anim[1].SetTrigger("SwordEffect");
    }
}
