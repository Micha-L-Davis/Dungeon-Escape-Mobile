using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new UnityException("Game Manager is NULL");
            }
            return _instance;
        }
    }

 
    public Player Player { get; private set; }
    [SerializeField]
    bool _hasKeyToCastle;
    Vector3 _respawnPosition;
    public bool HasKeyToCastle { get => _hasKeyToCastle; set { _hasKeyToCastle = value; } }
    
    public void PlayerDeath()
    {
        Player.transform.position = _respawnPosition;
    }

    public void LootGain(int value)
    {
        Player.loot += value;
        UIManager.Instance.UpdateLootCount(Player.loot);
    }

    public void LootLose(int value)
    {
        Player.loot -= value;
        UIManager.Instance.UpdateLootCount(Player.loot);
    }

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (Player == null)
            throw new UnityException("Player is NULL");
    }
}
