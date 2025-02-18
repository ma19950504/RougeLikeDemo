using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    Player player;
    float timer;
    void Awake()
    {
        player = GameManager.instance.player;
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    void Update()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Count > 0)
            {
                timer += Time.deltaTime;
                if (timer > 2f)
                {
                    GameObject firstObject = pools[i][0];
                    Destroy(firstObject);
                    pools[i].RemoveAt(0);
                    timer = 0;
                }
            }
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if (!select) //如果select不存在，则实例化
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}
