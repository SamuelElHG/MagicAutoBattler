using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int attack = 1;
    public int defense = 1;
    public int agility = 1;
    public int luck = 1;

    public int pointsToSpend = 0;

    public void AddPointToStat(string statName)
    {
        if (pointsToSpend <= 0) return;

        switch (statName)
        {
            case "Attack":
                attack++;
                break;
            case "Defense":
                defense++;
                break;
            case "Agility":
                agility++;
                break;
            case "Luck":
                luck++;
                break;
            default:
                Debug.LogWarning("Stat not recognized: " + statName);
                return;
        }

        pointsToSpend--;
    }

    public void AddPoints(int amount)
    {
        pointsToSpend += amount;
    }
}
