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
    public Vector3 srOriginallyDir;
    
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void Fire(Vector3 dir,Transform playerPos)
    {
        rb.position = playerPos.position;
        rb.velocity =  dir* moveSpeed;
        transform.rotation = Quaternion.FromToRotation(srOriginallyDir,dir);
    }
}
