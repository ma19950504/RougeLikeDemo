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

    private Dictionary<int, float> timers = new Dictionary<int, float>();
    private Dictionary<int, float> cds = new Dictionary<int, float>();


    void Start()
    {
        // 初始化每个 prefabsId 对应的冷却时间
        for (int i = 0; i < 2; i++)
        {
            if (GameManager.instance.skillPoolManager.prefabs[i] != null)
            {
                if (i == 0)
                {
                    cds[i] = GameManager.instance.skillPoolManager.prefabs[i].GetComponent<Projectile>().CD;
                }
                else if (i == 1)
                {
                    cds[i] = GameManager.instance.skillPoolManager.prefabs[i].GetComponent<Projectile>().CD;
                }
            }
        }

        // 初始化 timers 字典
        for (int i = 0; i < 2; i++)
        {
            timers[i] = 0f;
        }
    }
    void FixedUpdate()
    {
        Debug.Log(timers[0]+"=================="+timers[1]);
        // 当前对象的位置，射线范围，射线方向（全方向），最大距离（0为整个半径），检测图层
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        nearestTarget = GetNearest();
         if (nearestTarget != null)
        {
            foreach (var prefabsId in new int[] { 0, 1 })
            {
                timers[prefabsId] += Time.deltaTime;

                if (timers[prefabsId] > cds[prefabsId])
                {
                    timers[prefabsId] = 0f;
                    Fire(prefabsId);
                }
            }
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
        Gizmos.color = Color.red; // 设置Gizmo颜色
        Gizmos.DrawWireSphere(transform.position, scanRange); // 绘制scanRange的圆
    }

    public void Fire(int prefabsId)
    {
        Vector3 targetPos = nearestTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;
<<<<<<< Updated upstream
        if (prefabsId == 0)
        {
            GameObject fireBall = GameManager.instance.skillPoolManager.Get(prefabsId);
            fireBall.GetComponent<Projectile>().Move(dir, transform);
        }
        else if (prefabsId == 1)
        {
            GameObject bullet = GameManager.instance.skillPoolManager.Get(prefabsId);
            bullet.GetComponent<Projectile>().Move(dir, transform);
        }

=======
        GameObject fireBall =  GameManager.instance.skillPoolManager.Get(prefabsId);
        fireBall.GetComponent<Projectile>().Move(dir,transform);
>>>>>>> Stashed changes
    }

    //todo 定义一个projectile 发射体  然后所有skill使用这个脚本定义不同操作
}
