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
    [SerializeField] public WeaponScript activeWeapon;
    [SerializeField] public ArmorScript activeArmor;


    // Start is called before the first frame update
    void Start()
    {
        HealthText.text = HealthPoints.ToString();

        Debug.Log("startedEverything");
        StartCoroutine(combat());
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
        float finalAttack = AttackDamage + activeWeapon.weaponDamage;
        Debug.Log(finalAttack);
        /*  if(Random.Range(1,100)<=CriticalChance) 
          {
              enemy.receiveAttack(finalAttack * 2);
          }
          else
          {
              enemy.receiveAttack(finalAttack);
          }*/
        enemy.receiveAttack(finalAttack);

    }
    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();

    }
    public void receiveAttack(float attackDamag)
    {
        float finalDefense = defense;
        Debug.Log("i am being attacked");
        float damageReceived;
        damageReceived = attackDamag - defense;
        receiveDamage(damageReceived);
    }

}
