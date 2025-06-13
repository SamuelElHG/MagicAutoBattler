using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Elements;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private string name;
    public TMP_Text nameText;
    public TMP_Text damageReceivedText;
    public TMP_Text armorSwitchReady, weaponSwitchReady;
    [SerializeField] public SpriteRenderer activeArmorSprite, activeWeaponSprite;


    [SerializeField] private EnemyScript enemy;
    #region stats
    [SerializeField] public float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
    #endregion

    #region BattleAttributes
    [SerializeField] private float offense, defensive, agility, luck;
    public int pointsToSpend = 10;
    #endregion

    public TMP_Text HealthText;
    public TMP_Text BuffApplyed;

    [SerializeField] public WeaponScript activeWeapon;
    [SerializeField] public ArmorScript activeArmor;

    public bool weaponChangeAvailable = true;
    public bool armorChangeAvailable = true;

    public bool thorns = false;
    public bool canAttack = false;

    public TMP_Text AvailablePointsText;

    public void Start()
    {
        AvailablePointsText.text = pointsToSpend.ToString(); 
        nameText.text = name;
        armorSwitchReady.text = "Armor change Avaiable";
        weaponSwitchReady.text = "Weapon Switch Available";
        BuffApplyed.text = "";
        HealthText.text = HealthPoints.ToString();
    }
    public void InitiateCombat()
    {


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
            yield return new WaitForSeconds(1.0f/(AttackSpeed+activeWeapon.weaponSpeed));

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
        damageReceivedText.text = damageTaken.ToString();   
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
        armorSwitchReady.text = "Armor on CoolDown";
        yield return new WaitForSeconds(cooldown);
        armorChangeAvailable = true;
        armorSwitchReady.text = "Armor change Avaiable";

    }

    public IEnumerator changeWeaponCD(float cooldown)
    {
        weaponChangeAvailable = false;
        weaponSwitchReady.text = "Weapon on CoolDown";
        yield return new WaitForSeconds(cooldown);
        weaponChangeAvailable = true;
        weaponSwitchReady.text = "Weapon Switch Available";

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
        AvailablePointsText.text = pointsToSpend.ToString();
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
                    AvailablePointsText.text = pointsToSpend.ToString();
                }
                break;
            case "Defense":
                if (defensive > 0)
                {
                    defensive--;
                    pointsToSpend++; AvailablePointsText.text = pointsToSpend.ToString();

                }
                break;
            case "Agility":
                if (agility > 0)
                {
                    agility--;
                    pointsToSpend++; AvailablePointsText.text = pointsToSpend.ToString();

                }
                break;
            case "Luck":
                if (luck > 0)
                {
                    luck--;
                    pointsToSpend++; AvailablePointsText.text = pointsToSpend.ToString();

                }
                break;
            default:
                Debug.LogWarning("Stat no reconocido: " + statName);
                break;
        }
    }
}
