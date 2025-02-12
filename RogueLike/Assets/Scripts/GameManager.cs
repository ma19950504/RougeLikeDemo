using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  
    
    public PoolManager poolManager;
    public Player player;

    void Awake()
    {
        instance = this;
        Debug.Log("GameManager Awake");
    }
    void Start()
    {
        Debug.Log(GameManager.instance.player==null);
    }
}
