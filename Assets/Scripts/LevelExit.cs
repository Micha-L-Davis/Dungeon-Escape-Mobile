using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.Instance.HasKeyToCastle)
        {
            //level complete ui
        }
    }
}
