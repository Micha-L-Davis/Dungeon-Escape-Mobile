using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    public void Fire()
    {
        Spider parent = GetComponentInParent<Spider>();
        parent.Attack();
    }
}
