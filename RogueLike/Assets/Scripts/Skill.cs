using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//各技能共用属性
public class Skill : MonoBehaviour
{

    Player player;
    public int prefabsId; //预制件id
    public float damage;
    public int count;  //数量
    public float speed; //旋转速度，移动速度
    public float CD; //冷却

    public float timer; //计时器

    void Awake()
    {
        player = GameManager.instance.player;
    }
    
    
}
