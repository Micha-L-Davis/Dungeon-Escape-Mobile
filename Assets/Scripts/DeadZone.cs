using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered deadzone");
            Player player = other.GetComponent<Player>();
            StartCoroutine(player.RespawnRoutine());           
        }
    }
}
