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

    [SerializeField]
    bool _hasKeyToCastle;
    public bool HasKeyToCastle { get => _hasKeyToCastle; set { _hasKeyToCastle = value; } }


    private void Awake()
    {
        _instance = this;
    }
}
