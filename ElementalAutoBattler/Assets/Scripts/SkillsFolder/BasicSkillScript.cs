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
    [SerializeField] public bool Available = false;
    public SkillsInventory SkillSelector;
    [SerializeField] private GameObject availableShower;

    [SerializeField] public GameObject fondoSeleccionado;


    public GameObject infoPanel;
    public string infoText;
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
        availableShower.gameObject.SetActive(Available);
        yield return new WaitForSeconds(cooldown);
        Available = true;
        availableShower.gameObject.SetActive(Available);
    }


    void OnMouseDown()
    {
        SkillSelector.SelectSkill(gameObject.GetComponent<BasicSkillScript>());
    }

    private void OnMouseEnter()
    {
        infoPanel.SetActive(true);
    }

    private void OnMouseExit()
    {
        infoPanel.SetActive(false);
    }
}
