using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsInventory : MonoBehaviour
{
    public List<WeaponScript> allWeapons; // Todas las armas (11)
    public List<WeaponScript> selectedWeapons = new List<WeaponScript>(); // Las que elige el jugador (máx 4)

    public int maxWeapons = 4;

    public void SelectWeapon(WeaponScript weapon)
    {
        if (selectedWeapons.Contains(weapon))
        {
            // Ya estaba seleccionada: la quitamos
            selectedWeapons.Remove(weapon);
            Debug.Log("Arma deseleccionada: " + weapon.name);
        }
        else if (selectedWeapons.Count < maxWeapons)
        {
            selectedWeapons.Add(weapon);
            Debug.Log("Arma seleccionada: " + weapon.name);
        }
        else
        {
            Debug.Log("Ya seleccionaste 4 armas.");
        }
    }

    public void ConfirmSelection()
    {
        foreach (WeaponScript weapon in allWeapons)
        {
            bool isActive = selectedWeapons.Contains(weapon);
            weapon.gameObject.SetActive(isActive);
        }

        Debug.Log("Selección confirmada. Armas activas: " + selectedWeapons.Count);
    }
}
