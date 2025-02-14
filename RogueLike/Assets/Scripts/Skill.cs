using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    // public float cooldown;
    // protected bool isOnCooldown = false;
    // public virtual void UseSkill()
    // {
    //     if (isOnCooldown) return;
    //     StartCoroutine(CooldownRoutine());
    //     ActivateSkill();
    // }

    // protected abstract void ActivateSkill();

    // private IEnumerator CooldownRoutine()
    // {
    //     isOnCooldown = true;
    //     yield return new WaitForSeconds(cooldown);
    //     isOnCooldown = false;
    // }
Player player;
    public int id; //第n种技能 
   public int prefabsId; //预制件id
   public float damage;
   public int count;  //数量
   public float speed; //旋转速度，射速
   public float timer; //weapon1的间隔

 void Awake()
   {
        player = GameManager.instance.player;
   }
   void FixedUpdate()
   {            
    Debug.Log("进入SKill");
                timer += Time.deltaTime;
                if(timer>speed){  //speed为发射间隔，射速
                    timer = 0f;
                    Fire();
                }
                
   }
   public void Fire()
    {
        if(!player.scanner.nearestTarget) return; //是否有目标
        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;
        Transform skill= GameManager.instance.skillPoolManager.Get(0).transform;
        Debug.Log("jinrui");
        skill.position = transform.position;
        skill.rotation = Quaternion.FromToRotation(Vector3.up,dir);
        skill.GetComponent<FireBall>().Init(damage,count,dir); 

    }
}
