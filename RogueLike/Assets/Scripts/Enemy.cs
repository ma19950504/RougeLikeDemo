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
    public float damage;
    public float speed;
    public float spawnTime;
    public bool beatBack;

    WaitForFixedUpdate wait;
    public Rigidbody2D target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        wait = new WaitForFixedUpdate();
    }
    void OnEnable()
    {
        HP = maxHP;
    }
    void Start()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        }


    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            beatBack = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 targetDir = (target.transform.position - transform.position).normalized;
        float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
        float threshold = 0.1f; // 设置最近距离
        Vector2 moveDir = (targetDir * speed * Time.fixedDeltaTime - rb.position).normalized;
        if (beatBack)
        {
            rb.AddForce(-moveDir * 5, ForceMode2D.Impulse);
            beatBack = false;
        }
        else
        {
            if (distanceToTarget > threshold)
            {

                rb.velocity = moveDir;
            }
            else
            {
                // 当敌人接近目标时，停止移动
                rb.velocity = (rb.position);
            }
        }


        sr.flipX = targetDir.x < 0;

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Skill"))
        {
            if (HP > 0)
            {
                HP -= collider.GetComponent<Projectile>().damage;
                //StartCoroutine(KnockBack());
                beatBack = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator KnockBack() //击退 
    {
        yield return wait;
        Vector3 playPos = GameManager.instance.player.transform.position;
        Vector3 dir = (transform.position - playPos).normalized;
        // rb.AddForce(dir * 100, ForceMode2D.Impulse);
    }
}