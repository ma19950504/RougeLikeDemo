using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public Vector2 moveDir;
    public Vector2 faceDir;
    public float speed;

    public GameObject FireBall; // 技能预制体


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        faceDir.x = 1;
    }
    void Update()
    {
        Move();
        //SkillSpawn();
    }
    void FixedUpdate()
    {
    }
    public void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = moveDir * speed;
        if(moveDir != Vector2.zero){
            faceDir.x = moveDir.x;
        }
        sr.flipX = faceDir.x < 0;
        anim.SetBool("isMove", moveDir != Vector2.zero);
        
    }

}
