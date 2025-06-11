using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : BasicSkillScript
{
    [SerializeField] private PlayerScript player;
    public override void SkillAttack()
    {
        if (Available)
        {
            StartCoroutine(ActivateThorns());
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }

    IEnumerator ActivateThorns()
    {

        player.thorns = true;
        yield return new WaitForSeconds(5);
            player.thorns = false;

    }
}
