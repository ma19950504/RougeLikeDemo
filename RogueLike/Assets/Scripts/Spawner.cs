using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float timer;
    public float spawnTime;
    public int enemyType;

    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();  //当前对象及其子对象   在地图选取10个点用于充当生成点
    }
    void Start()
    {
        GetEnemyType();
    }
    void Update()
    {

        spawnTime = GameManager.instance.enemyPoolManager.prefabs[enemyType].GetComponent<Enemy>().spawnTime;
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn()
    {
        GameObject enemy = GameManager.instance.enemyPoolManager.Get(enemyType);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        GetEnemyType();
    }
    public int GetEnemyType()
    {
        int enemyTypeLength = GameManager.instance.enemyPoolManager.prefabs.Length;
        Debug.Log("enemyTypeLength:" + enemyTypeLength);
        enemyType = Random.Range(0, enemyTypeLength);
        return enemyType;
    }
}
