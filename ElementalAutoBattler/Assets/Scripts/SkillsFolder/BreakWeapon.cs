using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWeapon : BasicSkillScript
{
    public override void SkillAttack()
    {
        if (Available)
        {
            StartCoroutine(EnemyWeaponBreak());
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }

    public IEnumerator EnemyWeaponBreak()
    {
        enemy.weaponChangeAvailable = false;
        yield return new WaitForSeconds(10);
        enemy.weaponChangeAvailable = true;

    }
}
