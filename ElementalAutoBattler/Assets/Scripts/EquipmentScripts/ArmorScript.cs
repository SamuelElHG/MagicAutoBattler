using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Elements;

public class ArmorScript : MonoBehaviour
{
    [SerializeField] public Element ArmorElement;
    [SerializeField] public float defense;
    [SerializeField] public float cooldown;

    [SerializeField] private PlayerScript playerObject;
    public ArmorsInventory ArmorSelector;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                switchArmor();
            }
        }
    }


    public void switchArmor()
    {
        if(playerObject.armorChangeAvailable) {
            playerObject.activeArmor = gameObject.GetComponent<ArmorScript>();
            StartCoroutine(playerObject.changeArmorCD(cooldown));
        }
    }

    void OnMouseDown()
    {
        ArmorSelector.SelectArmor(gameObject.GetComponent<ArmorScript>());
    }
}
