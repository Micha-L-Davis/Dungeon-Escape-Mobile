using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    [SerializeField]
    float _projectileXVelocity = 9;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null)
        {
            Debug.LogError("Acid Rigidbody is NULL");
        }
        Destroy(gameObject, 4.75f);
    }
    private void Update()
    {
        _rigidbody.velocity = new Vector2(_projectileXVelocity, _rigidbody.velocity.y);
    }
}
