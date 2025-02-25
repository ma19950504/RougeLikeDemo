using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    Camera mainCamera;
    Player player;
    Vector3 playerPos;
    public float spawnRange = 5f; // 玩家周围的范围，敌人不会在这个范围内生成
    public float spawnOffset = 2f;
    public float spawnTime;
    public float spawnCount; // 每次刷怪的数量
    float timer;
    int maxEnemies = 100;

    void Awake()
    {
        mainCamera = Camera.main;
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    void Start()
    {
        player = GameManager.instance.player;
        StartCoroutine(SpawnEnemiesRoutine());
    }

    void Update()
    {
        // 可以在这里添加其他更新逻辑
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while (true) // 无限循环，不断刷怪
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector2 spawnPos = GetSpawnPosition();
                Init(Random.Range(0, prefabs.Length), spawnPos);
            }

            yield return new WaitForSeconds(spawnTime); // 等待 spawnTime 秒后再次刷怪
        }
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 spawnPos = Vector2.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            // 获取摄像机视口边界
            float height = mainCamera.orthographicSize * 2;
            float width = height * mainCamera.aspect;

            float minX = -width / 2;
            float maxX = width / 2;
            float minY = -height / 2;
            float maxY = height / 2;

            // 计算屏幕边界（世界坐标）
            Vector2 camPosition = mainCamera.transform.position;
            float left = camPosition.x + minX;
            float right = camPosition.x + maxX;
            float bottom = camPosition.y + minY;
            float top = camPosition.y + maxY;

            // 选择一个随机边界（上、下、左、右）
            int edge = Random.Range(0, 4);

            switch (edge)
            {
                case 0: // 上边界外
                    spawnPos = new Vector2(Random.Range(left, right), top + spawnOffset);
                    break;
                case 1: // 下边界外
                    spawnPos = new Vector2(Random.Range(left, right), bottom - spawnOffset);
                    break;
                case 2: // 左边界外
                    spawnPos = new Vector2(left - spawnOffset, Random.Range(bottom, top));
                    break;
                case 3: // 右边界外
                    spawnPos = new Vector2(right + spawnOffset, Random.Range(bottom, top));
                    break;
            }

            // 检查生成位置与玩家的距离
            if (player != null)
            {
                if (Vector2.Distance(spawnPos, player.transform.position) > spawnRange)
                {
                    validPosition = true;
                }
            }


        }

        return spawnPos;
    }

    void FixedUpdate()
    {
        playerPos = player.transform.position;
    }

    public GameObject Init(int index, Vector2 spawnPos)
    {
        Debug.Log($"Spawn Position: {spawnPos}");
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                select.transform.position = spawnPos; // 确保位置正确设置
                break;
            }
        }
        if (!select) // 如果select不存在，则实例化
        {
            select = Instantiate(prefabs[index], spawnPos, Quaternion.identity, transform);
            pools[index].Add(select);
        }
        return select;
    }

    void OnDrawGizmos()
    {
        if(Application.isPlaying) {
            if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        Gizmos.color = Color.red;

        // 获取摄像机视口边界
        float height = mainCamera.orthographicSize * 2;
        float width = height * mainCamera.aspect;

        float minX = -width / 2;
        float maxX = width / 2;
        float minY = -height / 2;
        float maxY = height / 2;

        // 计算屏幕边界（世界坐标）
        Vector2 camPosition = mainCamera.transform.position;
        float left = camPosition.x + minX;
        float right = camPosition.x + maxX;
        float bottom = camPosition.y + minY;
        float top = camPosition.y + maxY;

        // 画屏幕边界
        Vector3 topLeft = new Vector3(left, top, 0);
        Vector3 topRight = new Vector3(right, top, 0);
        Vector3 bottomLeft = new Vector3(left, bottom, 0);
        Vector3 bottomRight = new Vector3(right, bottom, 0);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);

        // 画生成位置
        Vector2 spawnPos = GetSpawnPosition();
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(spawnPos, 0.5f);

        // 画玩家周围的范围
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.transform.position, spawnRange);
        }
        
    }
}