using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets; //射线命中,检测范围内怪物成功时返回命中的object
    public Transform nearestTarget;
    SkillPoolManager skillPoolManager;

    void Start()
    {
        skillPoolManager = GameManager.instance.skillPoolManager;
    }


    void FixedUpdate()
    {
        // 当前对象的位置，射线范围，射线方向（全方向），最大距离（0为整个半径），检测图层
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
        if (nearestTarget != null)
        {
            skillPoolManager.GetEnemyPos(nearestTarget.position, transform.position);
        }
    }

    Transform GetNearest()
    {
        Transform result = null;
        float distance = scanRange;  //检测距离
        foreach (RaycastHit2D target in targets)
        {  //遍历更新最近的目标
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDis = Vector3.Distance(myPos, targetPos);
            if (curDis < distance)
            {
                distance = curDis;
                result = target.transform;
            }
        }
        return result;
    }
    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red; // 设置Gizmo颜色
            Gizmos.DrawWireSphere(transform.position, scanRange); // 绘制scanRange的圆
        }

    }

    // public void Activate(int prefabsId)
    // {
    //     Vector3 targetPos = nearestTarget.position;
    //     Vector3 dir = (targetPos - transform.position).normalized;
    //     GameObject projectile = skillPoolManager.Get(prefabsId);
    //     if (projectile.GetComponent<Projectile>())
    //     {
    //         projectile.GetComponent<Projectile>().Activate(dir, transform);

    //     }
    //     else if (projectile.GetComponent<Round>())
    //     {
    //         projectile.GetComponent<Round>().Fire(transform);
    //     }
    // }
}
