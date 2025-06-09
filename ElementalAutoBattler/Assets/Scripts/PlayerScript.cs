using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private EnemyScript enemy;
    #region stats
    [SerializeField] private float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
    #endregion

    #region BattleAttributes
    [SerializeField] private float offense, defense, agility, luck;
    #endregion

    public TMP_Text HealthText;


    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = HealthPoints.ToString();

        Debug.Log("startedEverything");
        StartCoroutine(combat());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator combat()
    {
        while (true) {
            Debug.Log("attack");

            attack();
            yield return new WaitForSeconds(10.0f/AttackSpeed);

        }

    }

    private void attack()
    {
        Debug.Log("attacked");

        enemy.receiveAttack(AttackDamage);

    }
    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();

    }
    public void receiveAttack(float attackDamag)
    {
        Debug.Log("i am being attacked");
        float damageReceived;
        damageReceived = attackDamag - defense;
        receiveDamage(damageReceived);
    }
}
