using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Round : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float damage;
    public float CD;
    public float timer;
    float initDamage;
    float initCD;
    public bool canBeatBack;
    public float backForce;
    Player player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        

    }

    void FixedUpdate()
    {
     
            
    }

    public void Fire(Transform playerPos)
    {
        rb.position = playerPos.position;

    }
    public void OnAnimationComplete()
    {
        gameObject.SetActive(false); // 动画播放完毕后销毁对象
    }

}
