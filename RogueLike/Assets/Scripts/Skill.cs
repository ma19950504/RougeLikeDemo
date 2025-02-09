using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{

    public float cooldown;
    protected bool isOnCooldown = false;
    public virtual void UseSkill()
    {
        if (isOnCooldown) return;
        StartCoroutine(CooldownRoutine());
        ActivateSkill();
    }

    protected abstract void ActivateSkill();

    private IEnumerator CooldownRoutine()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }
}
