using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Elements;

public class BasicSkillScript : MonoBehaviour
{
    [SerializeField] protected Element SkillElement;
    [SerializeField] protected EnemyScript enemy;
    [SerializeField] protected float Damage;
    [SerializeField] protected float cooldown;
    [SerializeField] protected bool Available = true;

    public virtual void SkillAttack()
    {
        if (Available)
        {
            enemy.receiveAttack(Damage,SkillElement);
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }

    public IEnumerator cdSkill()
    {
        Available = false;
        yield return new WaitForSeconds(cooldown);
        Available = true;
    }
}
