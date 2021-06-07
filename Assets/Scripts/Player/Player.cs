using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour, Input_Actions.IPlayerActions, IDamageable
{
    [SerializeField]
    public int loot;
    [SerializeField]
    float _jumpForce = 5f;
    [SerializeField]
    float _speed = 4f;
    Rigidbody2D _rigidbody;
    PlayerAnimation _playerAnimation;
    SpriteRenderer[] _spriteRenderer;
    bool _grounded = false;
    bool _jumpWait = false;
    [SerializeField]
    float _attackRate = 0.5f;
    float _canAttack = -1f;
    [SerializeField]
    Transform _swordTransform;

    float _damageCooldown = 0.5f;
    float _canTakeDamage = -1;
    public int Health { get; set; }

    void Start()
    {
        Health = 3;
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody2D is NULL");
        }
        _playerAnimation = GetComponent<PlayerAnimation>();
        if (_playerAnimation == null)
        {
            Debug.LogError("PlayerAnimation script is NULL");
        }
        _spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        if (_spriteRenderer[0] == null)
        {
            Debug.LogError("Player Sprite Renderer is NULL");
        }
        if (_spriteRenderer[1] == null)
        {
            Debug.LogError("Sword Sprite Renderer is NULL");
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && Grounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _playerAnimation.Jump(true);
            _grounded = false;
            StartCoroutine(JumpFrameSkipRoutine());
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 axisInput = context.ReadValue<Vector2>();
        _playerAnimation.Move(axisInput);
        axisInput.Normalize();
        float horizontalInput = axisInput.x;
        if (horizontalInput < 0)
        {
            _spriteRenderer[0].flipX = true;
            _spriteRenderer[1].flipY = true;
            _swordTransform.localPosition = new Vector2(-_swordTransform.localPosition.x, _swordTransform.localPosition.y);
        }
        else if (horizontalInput > 0)
        {
            _spriteRenderer[0].flipX = false;
            _spriteRenderer[1].flipY = false;
            _swordTransform.localPosition = new Vector2(-_swordTransform.localPosition.x, _swordTransform.localPosition.y);
        }
        _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton() && Time.time > _canAttack && Grounded())
        {
            _canAttack = Time.time + _attackRate;
            _playerAnimation.Attack();
        }
    }

    private void Update()
    {
        if (_jumpWait)
        {
            _grounded = Grounded();
            _jumpWait = false;
        }
        //Debug.DrawRay(gameObject.transform.position, -Vector2.up * 0.8f, Color.green);
    }

    bool Grounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, -Vector2.up, 0.8f, 1 << 8);

        if (hit.collider != null)
        {
            _playerAnimation.Jump(false);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator JumpFrameSkipRoutine()
    {
        while (!_grounded)
        {
            yield return new WaitForSeconds(0.1f);
            _jumpWait = true;
        }
    }

    public void Damage()
    {
        if (Time.time > _canTakeDamage)
        {
            _canTakeDamage = Time.time + _damageCooldown;
            Health--;
        }

        if (Health < 1)
        {
            _playerAnimation.Death();
        }
    }

    public void LootGain(int value)
    {
        loot += value;
    }

    public void LootLose(int value)
    {
        loot -= value;
    }
}
