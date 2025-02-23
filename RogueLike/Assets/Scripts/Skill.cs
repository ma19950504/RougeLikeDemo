using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//各技能共用属性
public abstract class Skill : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float damage;
    public int count;  //数量
    public float speed; //旋转速度，移动速度
    public float CD; //冷却
    public int per; //穿透次数，为0则无法穿透
    public int initPer; //初始化设定的per
    public int level;
    public bool canBeatBack;
    public float backForce;
    public Vector3 srInitDir;
    public float timer; //计时器

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        initPer = GetComponent<Skill>().per;
        timer = 0f;
    }
    public virtual void OnEnable()
    {
        per = initPer;
    }
    public virtual void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
       // CanUse();
    }
    public abstract void Activate(Vector3 dir, Transform playerPos);  // 启动技能，子类必须实现
}
