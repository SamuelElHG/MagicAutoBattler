using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Elements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private EnemyScript enemy;
    #region stats
    [SerializeField] public float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
    #endregion

    #region BattleAttributes
    [SerializeField] private float offense, defensive, agility, luck;
    public int pointsToSpend = 0;
    #endregion

    public TMP_Text HealthText;
    [SerializeField] public WeaponScript activeWeapon;
    [SerializeField] public ArmorScript activeArmor;

    public bool weaponChangeAvailable = true;
    public bool armorChangeAvailable = true;

    public bool thorns = false;
    public bool canAttack = false;


    public void InitiateCombat()
    {
        HealthText.text = HealthPoints.ToString();

        AttackDamage += offense;
        Defense += defensive;
        AttackSpeed += agility*0.1f;
        CriticalChance += luck;
        Debug.Log("startedEverything");
        StartCoroutine(combat());
    }

    IEnumerator combat()
    {
        while (true) {
            Debug.Log("attack");

            attack();
            yield return new WaitForSeconds(15f/(AttackSpeed+activeWeapon.weaponSpeed));

        }

    }

    private void attack()
    {
        float finalAttack = AttackDamage + activeWeapon.weaponDamage;
        Debug.Log(finalAttack);
         if(Random.Range(1,100)<=CriticalChance+activeWeapon.weaponCrit) 
          {
              enemy.receiveAttack(finalAttack * 2, activeWeapon.weaponElement);
          }
          else
          {
              enemy.receiveAttack(finalAttack, activeWeapon.weaponElement);
          }
        enemy.receiveAttack(finalAttack, activeWeapon.weaponElement);

    }
    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();
        if(HealthPoints <= 0)
        {
            GameOver();
        }

    }
    public void receiveAttack(float attackDamag, Element attackElement)
    {
        float multiplier = ElementalRules.GetMultiplier(activeArmor.ArmorElement, attackElement);
        float adjustedDamage = (attackDamag * multiplier) - Defense + activeArmor.defense;
        adjustedDamage = Mathf.Max(adjustedDamage, 0);
        receiveDamage(adjustedDamage);

        if(thorns)
        {
            enemy.receiveAttack(attackDamag, attackElement);
        }
    }

    public IEnumerator changeArmorCD(float cooldown)
    {
        armorChangeAvailable = false;
        yield return new WaitForSeconds(cooldown);
        armorChangeAvailable = true;
    }

    public IEnumerator changeWeaponCD(float cooldown)
    {
        weaponChangeAvailable = false;
        yield return new WaitForSeconds(cooldown);
        weaponChangeAvailable = true;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void AddPointToStat(string statName)
    {
        if (pointsToSpend <= 0) return;

        switch (statName)
        {
            case "Attack":
                offense++;
                break;
            case "Defense":
                defensive++;
                break;
            case "Agility":
                agility++;
                break;
            case "Luck":
                luck++;
                break;
            default:
                Debug.LogWarning("Stat not recognized: " + statName);
                return;
        }

        pointsToSpend--;
    }

    public void RemovePointFromStat(string statName)
    {
        switch (statName)
        {
            case "Attack":
                if (offense > 0)
                {
                    offense--;
                    pointsToSpend++;
                }
                break;
            case "Defense":
                if (defensive > 0)
                {
                    defensive--;
                    pointsToSpend++;
                }
                break;
            case "Agility":
                if (agility > 0)
                {
                    agility--;
                    pointsToSpend++;
                }
                break;
            case "Luck":
                if (luck > 0)
                {
                    luck--;
                    pointsToSpend++;
                }
                break;
            default:
                Debug.LogWarning("Stat no reconocido: " + statName);
                break;
        }
    }
}
