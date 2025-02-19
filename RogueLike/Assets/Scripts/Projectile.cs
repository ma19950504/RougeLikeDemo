using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float damage;
    public int per; //穿透次数，为0则无法穿透
    public float moveSpeed;
    public float CD;
    float initDamage;
    int initPer;
    float initMoveSpeed;
    float initCD;

    public Vector3 srInitDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        initPer =  GetComponent<Projectile>().per;
    }
    void Start()
    {
        
    }
    void OnEnable()
    {
        // damage = initDamage;
        per = initPer;
        // moveSpeed = initMoveSpeed;
        // CD = initCD;
    }
    public void Fire(Vector3 dir, Transform playerPos)
    {
        rb.position = playerPos.position;
        rb.velocity = dir * moveSpeed;
        transform.rotation = Quaternion.FromToRotation(srInitDir, dir);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Enemy") || per == -1) return;
        per--;
        if(per == -1){
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

    }

}
