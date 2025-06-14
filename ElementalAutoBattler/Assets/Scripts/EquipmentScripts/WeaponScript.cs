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

    [SerializeField] public GameObject fondoSeleccionado;
    public GameObject infoPanel;
    public string infoText;

    [SerializeField] private PlayerScript playerObject; 
    public WeaponsInventory weaponSelector;


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
            playerObject.activeWeaponSprite.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            StartCoroutine(playerObject.changeWeaponCD(weaponCooldown));
        }
    }


    void OnMouseDown()
    {
        weaponSelector.SelectWeapon(gameObject.GetComponent<WeaponScript>());
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
