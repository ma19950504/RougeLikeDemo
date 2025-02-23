using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Skill
{
    
    public override void Activate(Vector3 dir, Transform playerPos)
    {
        rb.position = playerPos.position;
        rb.velocity = dir * speed;
        transform.rotation = Quaternion.FromToRotation(srInitDir, dir);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Enemy") || per == -1) return;
        per--;
        if (per == -1)
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

    }
  
}
