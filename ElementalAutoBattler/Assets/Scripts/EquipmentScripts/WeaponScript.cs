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

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                switchWeapon();
            }
        }
    }

    public void switchWeapon()
    {
        if(playerObject.weaponChangeAvailable) {

            playerObject.activeWeapon = gameObject.GetComponent<WeaponScript>();
            StartCoroutine(playerObject.changeWeaponCD(weaponCooldown));
        }
    }
}
