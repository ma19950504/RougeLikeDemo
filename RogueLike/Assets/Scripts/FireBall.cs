using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Skill
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float speed = 10f;

    protected override void ActivateSkill()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
}
