using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Elements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private EnemyScript enemy;
    #region stats
    [SerializeField] public float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
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
            yield return new WaitForSeconds(1f/(AttackSpeed+activeWeapon.weaponSpeed));

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
        enemy.receiveAttack(finalAttack, activeWeapon.weaponElement);

    }
    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();

    }
    public void receiveAttack(float attackDamag, Element attackElement)
    {
        float multiplier = ElementalRules.GetMultiplier(activeArmor.ArmorElement, attackElement);
        float adjustedDamage = (attackDamag * multiplier) - Defense + activeArmor.defense;
        adjustedDamage = Mathf.Max(adjustedDamage, 0);
        receiveDamage(adjustedDamage);
    }

}
