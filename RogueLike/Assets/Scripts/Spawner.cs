using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // public Transform[] spawnPoints;
    // public float timer;
    // public float spawnTime;
    // public int enemyType;
    // Player player;

    // void Awake()
    // {
    //     player = GameManager.instance.player;
    //     spawnPoints = GetComponentsInChildren<Transform>();  //当前对象及其子对象   在地图选取10个点用于充当生成点
    // }
    // void Start()
    // {
    //     GetEnemyType();
    // }
    // void Update()
    // {

    //     spawnTime = GameManager.instance.enemyPoolManager.prefabs[enemyType].GetComponent<Enemy>().spawnTime;
    //     timer += Time.deltaTime;
    //     if (timer > spawnTime)
    //     {   
    //         Vector3 nextPoint = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
    //         float distance = Vector3.Distance(nextPoint, player.transform.position);
    //         if (distance <= 2f)
    //             return;
    //         Spawn(nextPoint);
    //         timer = 0;
    //     }
    // }
    // void OnDrawGizmos()
    // {
    //     if (!Application.isPlaying) return; 
    //     Gizmos.color = Color.green; // 设置Gizmo颜色
    //     Gizmos.DrawWireSphere(player.transform.position, 2f); // 绘制scanRange的圆
    // }

    // public void Spawn(Vector3 nextPoint)
    // {
    //     GameObject enemy = GameManager.instance.enemyPoolManager.Get(enemyType);
    //     enemy.transform.position = nextPoint;
    //     GetEnemyType();
    // }
    // public int GetEnemyType()
    // {
    //     int enemyTypeLength = GameManager.instance.enemyPoolManager.prefabs.Length;
    //     enemyType = Random.Range(0, enemyTypeLength);
    //     return enemyType;
    // }
}
