using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public Scanner scanner;

    public Vector2 moveDir;
    public Vector2 faceDir;
    public float HP;
    public float maxHP;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        faceDir.x = 1;
    }
    void OnEnable()
    {
        HP = maxHP;
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HP -= collision.GetComponent<Enemy>().damage;
            if (HP <=0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
