using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luck : BasicSkillScript
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private float playerBaseCrit;
    // Start is called before the first frame update
    void Start()
    {
        playerBaseCrit = player.CriticalChance;
    }

    public override void SkillAttack()
    {
        if(Available)
        {
            StartCoroutine(SwitchLuck());
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }

    IEnumerator SwitchLuck()
    {

        player.CriticalChance = 100;
        player.BuffApplyed.text = "Lucky";
        yield return new WaitForSeconds(5);
        player.CriticalChance = playerBaseCrit;
        player.BuffApplyed.text = "";


    }

}
