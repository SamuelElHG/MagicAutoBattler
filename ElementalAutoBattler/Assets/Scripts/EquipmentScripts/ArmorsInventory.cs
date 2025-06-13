using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorsInventory : MonoBehaviour
{
    public List<ArmorScript> allArmors; // Todas las armas (11)
    public List<ArmorScript> selectedArmors = new List<ArmorScript>(); // Las que elige el jugador (máx 4)
    public bool selectingArmors = true;

    public int maxWeapons = 4;

    public void SelectArmor(ArmorScript armor)
    {
        if (selectingArmors)
        {

            if (selectedArmors.Contains(armor))
            {
                // Ya estaba seleccionada: la quitamos
                selectedArmors.Remove(armor);
                armor.fondoSeleccionado.gameObject.SetActive(false);
                Debug.Log("Arma deseleccionada: " + armor.name);
            }
            else if (selectedArmors.Count < maxWeapons)
            {
                selectedArmors.Add(armor);
                armor.fondoSeleccionado.gameObject.SetActive(true);
                Debug.Log("Arma seleccionada: " + armor.name);
            }
            else
            {
                Debug.Log("Ya seleccionaste 4 armas.");
            }
        }
    }

    public void ConfirmSelection()
    {
        foreach (ArmorScript armor in allArmors)
        {
            bool isActive = selectedArmors.Contains(armor);
            armor.gameObject.SetActive(isActive);
        }
        selectingArmors = false;
        Debug.Log("Selección confirmada. Armas activas: " + selectedArmors.Count);
    }
}
