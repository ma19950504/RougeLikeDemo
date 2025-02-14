using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Collider2D col;
    public float maxHP;
    public float HP;
    public float speed;
    public float spawnTime;


    public Rigidbody2D target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            
            target = GameManager.instance.player.GetComponent<Rigidbody2D>();
            if (target == null)
            {
                Debug.LogError("Player does not have a Rigidbody2D component.");
            }
        }
        else
        {
            Debug.LogError("GameManager or Player not found!");
        }

    }
    void FixedUpdate()
    {
        Vector2 targetDir = (target.transform.position - transform.position).normalized;
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        float threshold = 0.1f; // 设置最近距离

        if (distanceToTarget > threshold)
        {
            Vector2 moveDir = targetDir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + moveDir);
        }
        else
        {
            // 当敌人接近目标时，停止移动
            rb.MovePosition(rb.position);
        }

        sr.flipX = targetDir.x < 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

    }
}