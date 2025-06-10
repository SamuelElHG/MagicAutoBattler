using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Elements;

public class BasicSkillScript : MonoBehaviour
{
    [SerializeField] private Element SkillElement;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private float Damage;
    [SerializeField] private float cooldown;
    [SerializeField] private bool Available = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SkillAttack()
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

    IEnumerator cdSkill()
    {
        Available = false;
        yield return new WaitForSeconds(cooldown);
        Available = true;
    }
}
