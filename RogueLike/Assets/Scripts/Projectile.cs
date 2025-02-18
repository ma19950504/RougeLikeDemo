using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float damage;
    public int per;
    public float moveSpeed;
    public float CD;
    public Vector3 originalDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector3 dir, Transform playerPos)
    {
        rb.position = playerPos.position;
        rb.velocity = dir * moveSpeed;
        transform.rotation = Quaternion.FromToRotation(Vector3.left,dir);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(!collider.CompareTag("Enemy")) return;
        
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
    }
}
