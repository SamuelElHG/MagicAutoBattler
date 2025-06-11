using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Elements;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private PlayerScript player;

    #region stats
    [SerializeField] private float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
    #endregion

    #region BattleAttributes
    [SerializeField] private float offense, defense, agility, luck;
    #endregion

    public TMP_Text HealthText;

    [SerializeField] public ArmorScript activeArmor;
    //[SerializeField] public ArmorScript activeWeapon;



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

    public void attack()
    {
        player.receiveAttack(AttackDamage, activeArmor.ArmorElement);
    }

    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();

    }
    public void receiveAttack(float attackDamag, Element attackElement)
    {
        float multiplier = ElementalRules.GetMultiplier(activeArmor.ArmorElement, attackElement);
        float adjustedDamage = (attackDamag * multiplier) - Defense+activeArmor.defense;
        adjustedDamage = Mathf.Max(adjustedDamage, 0);
        receiveDamage(adjustedDamage);
    }

    IEnumerator combat()
    {
        while (true)
        {
            Debug.Log("attack");

            attack();
            yield return new WaitForSeconds(10.0f / AttackSpeed);

        }

    }
}
