using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsInventory : MonoBehaviour
{
    public List<BasicSkillScript> allSkills; // Todas las armas (11)
    public List<BasicSkillScript> selectedSkills = new List<BasicSkillScript>(); // Las que elige el jugador (máx 4)
    public bool selectingSkills = true;

    public int maxWeapons = 4;

    public void SelectSkill(BasicSkillScript skill)
    {
        if (selectingSkills)
        {
            if (selectedSkills.Contains(skill))
            {
                // Ya estaba seleccionada: la quitamos
                selectedSkills.Remove(skill);
                skill.fondoSeleccionado.gameObject.SetActive(false);
                Debug.Log("Arma deseleccionada: " + skill.name);
            }
            else if (selectedSkills.Count < maxWeapons)
            {
                selectedSkills.Add(skill);
                Debug.Log("Arma seleccionada: " + skill.name); 
                skill.fondoSeleccionado.gameObject.SetActive(true);

            }
            else
            {
                Debug.Log("Ya seleccionaste 4 armas.");
            }
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
        selectingSkills=false;
        Debug.Log("Selección confirmada. Armas activas: " + selectedSkills.Count);
    }
}
