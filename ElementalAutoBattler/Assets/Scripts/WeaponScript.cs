using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Elements;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] public string weaponName;
    [SerializeField] public float weaponDamage;
    [SerializeField] public float weaponSpeed;
    [SerializeField] public float weaponCrit;
    [SerializeField] public float weaponCooldown;
    [SerializeField] public Element weaponElement;

    [SerializeField] private PlayerScript playerObject;

    public void switchWeapon()
    {
        playerObject.activeWeapon = gameObject.GetComponent<WeaponScript>();
    }
}
