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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                SkillAttack();
            }
        }
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
        yield return new WaitForSeconds(5);
        player.CriticalChance = playerBaseCrit;

    }

}
