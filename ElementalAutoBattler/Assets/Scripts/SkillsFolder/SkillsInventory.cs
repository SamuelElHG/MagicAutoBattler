using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsInventory : MonoBehaviour
{
    public List<BasicSkillScript> allSkills; // Todas las armas (11)
    public List<BasicSkillScript> selectedSkills = new List<BasicSkillScript>(); // Las que elige el jugador (m�x 4)

    public int maxWeapons = 4;

    public void SelectSkill(BasicSkillScript skill)
    {
        if (selectedSkills.Contains(skill))
        {
            // Ya estaba seleccionada: la quitamos
            selectedSkills.Remove(skill);
            Debug.Log("Arma deseleccionada: " + skill.name);
        }
        else if (selectedSkills.Count < maxWeapons)
        {
            selectedSkills.Add(skill);
            Debug.Log("Arma seleccionada: " + skill.name);
        }
        else
        {
            Debug.Log("Ya seleccionaste 4 armas.");
        }
    }

    public void ConfirmSelection()
    {
        foreach (BasicSkillScript skill in allSkills)
        {
            bool isActive = selectedSkills.Contains(skill);
            skill.gameObject.SetActive(isActive);
            skill.Available = true;
        }

        Debug.Log("Selecci�n confirmada. Armas activas: " + selectedSkills.Count);
    }
}
