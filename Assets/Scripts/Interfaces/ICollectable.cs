using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    int Value { get; set; }

    void OnTriggerEnter2D(Collider2D other);


}
