using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : BasicSkillScript
{
    [SerializeField] private PlayerScript player;
    [SerializeField] private float playerBaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerBaseSpeed=player.AttackSpeed;
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
        if (Available)
        {
            StartCoroutine(SwitchAttackSpeed());
            StartCoroutine(cdSkill());
        }
        else
        {
            Debug.Log("NotAvailable");
        }
    }


    IEnumerator SwitchAttackSpeed()
    {

        player.AttackSpeed = playerBaseSpeed*2;
        yield return new WaitForSeconds(5);
        player.AttackSpeed = playerBaseSpeed;

    }
}
