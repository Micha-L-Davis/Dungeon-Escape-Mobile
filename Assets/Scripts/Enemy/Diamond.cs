using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int Value { get; set; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (Value == 0)
                {
                    Value = 1;
                }
                GameManager.Instance.LootGain(Value);
                Destroy(gameObject);
            }

        }
    }
}
