using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Orbit : Skill
{


    public override void Activate(Vector3 dir, Transform playerPos)
    {
        rb.position = playerPos.position;

    }
    public void OnAnimationComplete()
    {
        gameObject.SetActive(false); // 动画播放完毕后销毁对象
    }

}
