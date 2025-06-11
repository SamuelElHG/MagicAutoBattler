using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icebolt : BasicSkillScript
{
    private float enemyBaseAttackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        enemyBaseAttackSpeed = enemy.AttackSpeed;
    }


    public override void SkillAttack()
    {
        if (Available)
        {
            enemy.receiveAttack(Damage, SkillElement);
            StartCoroutine(SlowAttackSpeed());
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }

    IEnumerator SlowAttackSpeed()
    {

        enemy.AttackSpeed *=0.7f;
        yield return new WaitForSeconds(5);
        enemy.AttackSpeed = enemyBaseAttackSpeed;

    }
}
