using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{

    [SerializeField] private PlayerScript player;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private GameObject thisCanvas;
    [SerializeField] private Clock clock;

    public void startgame()
    {
        clock.StartTimer();
        player.InitiateCombat();
        enemy.InitiateCombat();
        thisCanvas.SetActive(false);
    }
}
