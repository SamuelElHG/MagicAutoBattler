using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakArmor : BasicSkillScript
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
        enemy.armorChangeAvailable = false;
        yield return new WaitForSeconds(10);
        enemy.armorChangeAvailable = true;

    }
}
