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

    public void switchArmor()
    {
        playerObject.activeArmor = gameObject.GetComponent<ArmorScript>();
    }

}
