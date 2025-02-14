using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float damage;
    public int per;
    public float moveSpeed;
    public float CD;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector3 dir,Transform playerPos)
    {
        rb.position = playerPos.position;
        rb.velocity =  dir* moveSpeed;
        sr.flipX = dir.x > 0 ? true : false; // 使用三元运算符
    }
    
}
