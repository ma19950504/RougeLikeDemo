using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    Player player;
    float timer;
    Vector3 skillDir;
    float[] skillCDs;

    void Awake()
    {
        player = GameManager.instance.player;
        pools = new List<GameObject>[prefabs.Length];
        skillCDs = new float[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
            skillCDs[i] = 0;
        }

    }

    void Update()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].Count > 0)
            {
                timer += Time.deltaTime;
                if (timer > 10f)  //每10秒开始清理对象池
                {
                    GameObject firstObject = pools[i][0];
                    Destroy(firstObject);
                    pools[i].RemoveAt(0);
                    timer = 0;
                }
            }
            skillCDs[i] += Time.deltaTime;
        }
        CheckAndDeactivateOutOfDistanceSkills();
    }
    void FixedUpdate()
    {
       
        for (int i = 0; i < prefabs.Length; i++)
        {
            
            if (skillCDs[i]>prefabs[i].GetComponent<Skill>().CD)
            {
                skillCDs[i] = 0;
                Activate(i);
            }
        }

    }

    public GameObject Init(int index)
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

    public void Activate(int prefabsId)
    {
        GameObject skill = Init(prefabsId);
        skill.transform.position = player.transform.position;
        skill.GetComponent<Skill>().Activate(skillDir, player.transform);
    }

    public void GetEnemyPos(Vector3 enemyPos, Vector3 playerPos)
    {
        skillDir = (enemyPos - playerPos).normalized;
    }
    void CheckAndDeactivateOutOfDistanceSkills()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            for (int j = 0; j < pools[i].Count; j++)
            {
                GameObject skill = pools[i][j];
                if (skill.activeSelf)
                {
                    float distance = Vector3.Distance(skill.transform.position, player.transform.position);
                    if (distance > 20f)
                    {
                        skill.SetActive(false);
                    }
                }
            }
        }
    }
}
