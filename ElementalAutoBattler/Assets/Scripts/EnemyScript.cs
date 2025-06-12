using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Elements;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private string name;
    public TMP_Text nameText;

    [SerializeField] private PlayerScript player;

    #region stats
    [SerializeField] public float AttackDamage, Defense, AttackSpeed, CriticalChance, HealthPoints;
    #endregion

    #region BattleAttributes
    [SerializeField] private float offense, defense, agility, luck;
    #endregion

    public TMP_Text HealthText;

    [SerializeField] public ArmorScript activeArmor;
    [SerializeField] public WeaponScript activeWeapon;

    public bool weaponChangeAvailable = true;
    public bool armorChangeAvailable = true;
    [SerializeField] private string sceneName;

    [SerializeField] private List<ArmorScript> armorsInventory;
    [SerializeField] private List <WeaponScript> weaponsInventory;
    public void Start()
    {        nameText.text = name;

        HealthText.text = HealthPoints.ToString();
    }
    public void InitiateCombat()
    {

        Debug.Log("startedEverything");
        StartCoroutine(ArmorLoop());
        StartCoroutine(WeaponLoop());
        StartCoroutine(combat());
    }

    public void attack()
    {
        player.receiveAttack(AttackDamage, activeWeapon.weaponElement);
    }

    public void receiveDamage(float damageTaken)
    {
        HealthPoints -= damageTaken;
        HealthText.text = HealthPoints.ToString();
        if(HealthPoints<=0)
        {
            WinGame();
        }

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
            yield return new WaitForSeconds(1.0f / AttackSpeed);

        }

    }
    public void WinGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void switchArmorsRandom()
    {
        if(armorChangeAvailable)
        {
            activeArmor = armorsInventory[Random.Range(0, armorsInventory.Count)];
            StartCoroutine(armorChangeCD());
        }
    }

    private IEnumerator armorChangeCD()
    {
        armorChangeAvailable = false;
        yield return new WaitForSeconds(activeArmor.cooldown);
        armorChangeAvailable = true;
    }
    private IEnumerator ArmorLoop()
    {
        while (true)
        {
            if (armorChangeAvailable)
            {
                switchArmorsRandom();
            }

            yield return new WaitForSeconds(0.1f); // Control de llamada
        }
    }
    public void switchWeaponsRandom()
    {
        if (weaponChangeAvailable)
        {
            activeWeapon = weaponsInventory[Random.Range(0, weaponsInventory.Count)];
            StartCoroutine(weaponChangeCD());
        }
    }

    private IEnumerator weaponChangeCD()
    {
        weaponChangeAvailable = false;
        yield return new WaitForSeconds(activeWeapon.weaponCooldown);
        weaponChangeAvailable = true;
    }
    private IEnumerator WeaponLoop()
    {
        while (true)
        {
            if (weaponChangeAvailable)
            {
                switchWeaponsRandom();
            }

            yield return new WaitForSeconds(0.1f); // Control de llamada
        }
    }


}
