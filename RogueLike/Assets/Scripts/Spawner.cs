using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    PoolManager poolManager;
    public float timer;

    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();  //当前对象及其子对象   在地图选取10个点用于充当生成点

    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn()
    {
        GameObject enemy = GameManager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    }
}
